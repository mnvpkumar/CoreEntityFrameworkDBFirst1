﻿using System;
using System.Collections.Generic;

namespace CoreEntityFrameworkDBFirst1.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}
