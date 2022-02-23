//we need to use the models here to
using labb2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace labb2.Controllers
{
    public class HomeController : Controller
    {
        //shows the index page connects back to program.cs and  pattern: "{controller=home}/{action=index}/{id?}"
        public IActionResult Index()
        {
            //Reads in everything from a file named movies.json
            var JsonStr = System.IO.File.ReadAllText("movies.json");
            //then converts to this model as a list
            var JsonObj = JsonConvert.DeserializeObject<List<Model>>(JsonStr);
            // we send the the visiotor on to the View page
            //here we can also decide what will happen when someone enters the index page and about page below and so on
            string session = "Text in en sessions variabel";
            HttpContext.Session.SetString("test", session);
            return View(JsonObj);
        }
        //for the about page

        //decides what the about page should be called in the adres bar
        //[HttpGet("/about")]
        public IActionResult About() 
        {
            ViewBag.om = "Om sidan";
            string sesion2 = HttpContext.Session.GetString("test");
            ViewBag.Text = sesion2;
            return View(); 
        }
        // for the third page

        //decides what the about page should be called in the adres bar it overiddes the home path in Program.cs 
        //" pattern: "{controller=home}/{action=index}/{id?}" "
        //[HttpGet("/page3")]
        public IActionResult Page3()
        {
            return View();
        }

        //since this Iaction uses the same name as the one above we need to tell it to use HttpPost
        [HttpPost]
        public IActionResult Page3(Model Model)
        {
            if (ModelState.IsValid)
            {
                //Reads in everything from a file named movies.json
                var JsonStr = System.IO.File.ReadAllText("movies.json");
                //then converts to this model as a list
                var JsonObj = JsonConvert.DeserializeObject<List<Model>>(JsonStr);

                //if its not null add to it
                if (JsonObj != null)
                {
                    JsonObj.Add(Model);
                }
                // converts to a json string and saves it
                System.IO.File.WriteAllText("movies.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                //empties the input fields
                ModelState.Clear();
            }
            return View();
        }

    }
}
