﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class Sastav
    {
        public Klub Klub { get; set; }
        public List<Igrac> Igraci { get; set; }


        public Sastav() { }
    }
}