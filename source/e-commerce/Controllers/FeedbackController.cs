﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Comerce.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index() // feedback
        {
            return View();
        }
    }
}