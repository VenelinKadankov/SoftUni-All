﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class SaleInputModel
    {
        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public decimal Discount { get; set; }
    }
}
