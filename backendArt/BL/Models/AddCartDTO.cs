﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class AddCartDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
