﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class AddReviewDTO
    {

        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

    }
}
