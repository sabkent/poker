﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poker.Api.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}