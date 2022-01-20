﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Common
{
    public class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null) 
            {
                name ??= "Value";

                throw new ArgumentNullException($"{name} cannot be null");
            }
        }
    }
}
