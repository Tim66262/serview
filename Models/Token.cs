﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serview.Models
{
    public class Token
    {
        public string token { get; set; }

        public DateTime expiration { get; set; }
    }
}
