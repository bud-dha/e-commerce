using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace e_Comerce.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public ActionResult Index() // /home
        {
            return View();
        }

        public ActionResult List() // /home/list
        {
            return View();
        }

        public ActionResult Feedback() // /home/feedback
        {
            return View();
        }

    }
}
