using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Customer
{
    public class CreateCustomerViewModel
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}