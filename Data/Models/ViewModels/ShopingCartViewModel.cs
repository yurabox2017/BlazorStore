﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Data.Models.ViewModels
{
    public class ShopingCartViewModel
    {
        public Appointment Appointment { get; set; }
        public List<Product> Products { get; set; }
    }
}
