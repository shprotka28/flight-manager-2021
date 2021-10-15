using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using flight_manager_2021.Models.Users;
using System.Threading.Tasks;
using flight_manager_2021.Shared;
using Microsoft.EntityFrameworkCore;
using Data.Entity;
using Data;

namespace flight_manager_2021.Controllers
{
    public class UserController : Controller
    {
        private const int PageSize = 10;
        private readonly ConnectionDB _context;

        public UserController()
        {
            _context = new ConnectionDB();
        }
        //GET : Users
        public async Task<IActionResult> Index(UsersIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<UsersViewModel> items = await _context.Users.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new UsersViewModel()
            {
                Id = c.Id,
                UserName = c.UserName,
                Password = c.Password,
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                EGN = c.EGN,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Role = c.Role

            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Users.CountAsync() / (double)PageSize);

            return View(model);
        }
        //GET: Users/Create

        public IActionResult Create()
        {
            UsersCreateViewModel model = new UsersCreateViewModel();

            return View(model);
        }
        //Post: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersCreateViewModel createModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = createModel.UserName,
                    Password = createModel.Password,
                    Email = createModel.Email,
                    FirstName = createModel.FirstName,
                    LastName = createModel.LastName,
                    EGN = createModel.EGN,
                    Address = createModel.Address,
                    PhoneNumber = createModel.PhoneNumber,
                    Role = createModel.Role
                };
                _context.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(createModel);
        }
        //GET: Users/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            UsersEditViewModel model = new UsersEditViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EGN = user.EGN,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };
            return View(model);
        }
        //POST : Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsersEditViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Id = editModel.Id,
                    UserName = editModel.UserName,
                    Password = editModel.Password,
                    Email = editModel.Email,
                    FirstName = editModel.FirstName,
                    LastName = editModel.LastName,
                    EGN = editModel.EGN,
                    Address = editModel.Address,
                    PhoneNumber = editModel.PhoneNumber,
                    Role = editModel.Role
                };
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExist(user.Id))
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
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool UserExist(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
