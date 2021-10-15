using flight_manager_2021.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight_manager_2021.Models.Users
{
    public class UsersIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public ICollection<UsersViewModel> Items { get; set; }
    }
}
