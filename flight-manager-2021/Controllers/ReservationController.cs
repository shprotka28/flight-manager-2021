using Microsoft.AspNetCore.Mvc;
using System;
using flight_manager_2021.Models.Reservations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flight_manager_2021.Shared;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;

namespace flight_manager_2021.Controllers
{
    public class ReservationController : Controller
    {
        private const int PageSize = 10;
        private readonly ConnectionDB _context;

        public ReservationController()
        {
            _context = new ConnectionDB();
        }

        //GET : Reservation
        public async Task<IActionResult> Index(ReservationsIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            ReservationsViewModel[] items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ReservationsViewModel()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                SecondName = c.SecondName,
                LastName = c.LastName,
                EGN = c.EGN,
                PhoneNumber = c.PhoneNumber,
                Nationality = c.Nationality,
                TypeOfTicket = c.TypeOfTicket,
                Email = c.Email

            }).ToArrayAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Reservations.CountAsync() / (double)PageSize);

            return View(model);
        }

        //GET: Reservation/Create
        [Route("/Reservation/Create", Name = "create")]
        public IActionResult Create(int id, string from, string to, DateTime takeOffTime, DateTime landingTime, int bCapacity, int bCount, int sCapacity, int sCount)
        {
            ReservationsCreateViewModel model = new ReservationsCreateViewModel();

            Flight flightInformation = new Flight()
            {
                LocationFrom = from,
                LocationTo = to,
                TakeOffTime = takeOffTime,
                LandingTime = landingTime,
                CapacityOfBusinessClass = bCapacity,
                CountOfBusinessClass = bCount,
                CapacityOfEconomyClass = sCapacity,
                CountOfEconomyClass = sCount,
            };

            model.FlightInformation = flightInformation;
            model.PlaneId = id;

            return View(model);
        }

        /*//Post: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation(ReservationsCreateViewModel createModel)
        {
            //For some reason the form doesn't want to parse in the id of the plane.
            throw new NotImplementedException("CreateReservation via BodyBinding isn't fully implemented yet...");

            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    FirstName = ((ReservationsCreateViewModel)createModel).FirstName,
                    SecondName = ((ReservationsCreateViewModel)createModel).SecondName,
                    LastName = ((ReservationsCreateViewModel)createModel).LastName,
                    EGN = ((ReservationsCreateViewModel)createModel).EGN,
                    PhoneNumber = ((ReservationsCreateViewModel)createModel).PhoneNumber,
                    Nationality = ((ReservationsCreateViewModel)createModel).Nationality,
                    TypeOfTicket = ((ReservationsCreateViewModel)createModel).TypeOfTicket,
                    Email = ((ReservationsCreateViewModel)createModel).Email
                };

                _context.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToAction("privacy");
            }

            ReservationsCreateViewModel model = new ReservationsCreateViewModel
            {
                FlightInformation = createModel.FlightInformation
            };

            return View(model);
        }*/

        //Post: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation(string FirstName, string SecondName, string LastName, string EGN, string PhoneNumber, string Nationality, string TypeOfTicket, string Email, int PlaneId)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    FirstName = FirstName,
                    SecondName = SecondName,
                    LastName = LastName,
                    EGN = EGN,
                    PhoneNumber = PhoneNumber,
                    Nationality = Nationality,
                    TypeOfTicket = TypeOfTicket,
                    Email = Email,
                    PlaneId = PlaneId
                };

                if (reservation.IsNotNull() && await CanOrderTickets(PlaneId, TypeOfTicket))
                {
                    IncrementFlightCount(PlaneId, TypeOfTicket);
                    _context.Add(reservation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Success");
                }
            }

            return RedirectToAction("Failed");
        }


        public IActionResult Failed()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        //GET: Reservation/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Reservation reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ReservationsEditViewModel model = new ReservationsEditViewModel
            {
                Id = reservation.Id,
                FirstName = reservation.FirstName,
                SecondName = reservation.SecondName,
                LastName = reservation.LastName,
                EGN = reservation.EGN,
                PhoneNumber = reservation.PhoneNumber,
                Nationality = reservation.Nationality,
                TypeOfTicket = reservation.TypeOfTicket,
                Email = reservation.Email
            };
            return View(model);
        }
       
        //POST : Reservation/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationsEditViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation()
                {
                    Id = editModel.Id,
                    FirstName = editModel.FirstName,
                    SecondName = editModel.SecondName,
                    LastName = editModel.LastName,
                    EGN = editModel.EGN,
                    PhoneNumber = editModel.PhoneNumber,
                    Nationality = editModel.Nationality,
                    TypeOfTicket = editModel.TypeOfTicket,
                    Email = editModel.Email
                };
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editModel);
        }

        //GET : Reservation/Delete
        public async Task<IActionResult> Delete(int id)
        {
            Reservation reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }

        private async void IncrementFlightCount(int id, string typeOfTicket)
        {
            var flight = await _context.Flights.FindAsync(id);

            if (typeOfTicket == "Standart Ticket")
            {
                flight.CountOfEconomyClass++;

            }
            else if (typeOfTicket == "Business Ticket")
            {
                flight.CountOfBusinessClass++;
            }

            _context.Update(flight);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CanOrderTickets(int id, string typeOfticket)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (typeOfticket == "Standart Ticket" && flight.CountOfEconomyClass < flight.CapacityOfEconomyClass)
            {
                return true;
            }
            else if (typeOfticket == "Business Ticket" && flight.CountOfBusinessClass < flight.CapacityOfBusinessClass)
            {
                return true;
            }
            return false;
        }
    }
}
