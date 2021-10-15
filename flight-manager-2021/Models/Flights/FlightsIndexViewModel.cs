using flight_manager_2021.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight_manager_2021.Models.Flights
{
    public class FlightsIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public FlightsViewModel[] Items { get; set; }
    }
}
