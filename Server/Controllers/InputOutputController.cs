using BlazorTest.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Controllers
{
    public class InputOutputController : ControllerBase
    {
        private readonly B_InputOutput _io;

        public InputOutputController(B_InputOutput io)
        {
            _io = io;
        }
    }
}
