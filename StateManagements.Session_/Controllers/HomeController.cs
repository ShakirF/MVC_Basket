using Microsoft.AspNetCore.Mvc;
using StateManagements.Session_.Models;
using System.Diagnostics;

namespace StateManagements.Session_.Controllers
{
    public class HomeController : Controller
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult SessionTest()
        {
            DateTime dt = DateTime.UtcNow;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(Keys.SESSION_KEY_NAME)))
            {
                HttpContext.Session.SetString(Keys.SESSION_KEY_NAME, "The Doctor");
                HttpContext.Session.SetInt32(Keys.SESSION_KEY_AGE, 73);
                HttpContext.Session.SetString(Keys.SESSION_KEY_DATE, dt.ToLongTimeString());
            }
            var name = HttpContext.Session.GetString(Keys.SESSION_KEY_NAME);
            var age = HttpContext.Session.GetInt32(Keys.SESSION_KEY_AGE).ToString();
            var date = HttpContext.Session.GetString(Keys.SESSION_KEY_DATE);


            return Json(
                new
                {
                    Name = name,
                    Age = age,
                    CatcheDate = date,
                    Date = dt
                }); 
        }


        public async Task<IActionResult> Index()
        {
            return View();
        }
        public static class Keys
        {
            public const string SESSION_KEY_NAME = "_name";
            public const string SESSION_KEY_AGE = "_age";
            public const string SESSION_KEY_DATE = "_date";
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}