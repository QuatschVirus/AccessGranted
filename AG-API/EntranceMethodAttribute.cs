﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG_API
{
    /// <summary>
    /// Annotate one entrance method candidate to make it the entrance method
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class EntranceMethodAttribute : Attribute
    {
    }
}
