using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Product
{
    public class CreateProductViewModel
    {
        public string Title { get; set; }
        public decimal? Price { get; set; }
    }
}