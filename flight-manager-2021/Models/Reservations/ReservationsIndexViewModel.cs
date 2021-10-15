using flight_manager_2021.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight_manager_2021.Models.Reservations
{
    public class ReservationsIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public ReservationsViewModel[] Items { get; set; }
    }
}
