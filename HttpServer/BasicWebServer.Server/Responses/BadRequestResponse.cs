﻿using BasicWebServer.Server.HTTP.Enums;
using BasicWebServer.Server.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {
        }
    }
}