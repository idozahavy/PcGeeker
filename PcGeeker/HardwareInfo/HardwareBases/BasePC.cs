﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInfo.HardwareBases
{
    public class BasePC<T> : BaseHardware
    {

        public enum PCField
        {
            CPU = 1,
            GPU = 2,
            RAM = 3,
            Drive = 4,
            Motherboard = 5,
        }

        public T CPU { get; internal set; }
        public T GPU { get; internal set; }
        public List<T> RAM { get; internal set; }
        public List<T> Drive { get; internal set; }
        public T Motherboard { get; internal set; }
    }
}
