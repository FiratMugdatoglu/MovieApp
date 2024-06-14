using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult List(int? id,string q)
        {

            //var controller = RouteData.Values("controller");
            //var action = RouteData.Values("action");
            //var genreid = RouteData.Values("id");
            //var kelime = HttpContext.Request.Query["q"].ToString(); 


			var movies = MovieRepository.Movies;

            if(id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i=>
                    i.Title.ToLower().Contains(q.ToLower())   ||  
                    i.Description.ToLower().Contains(q.ToLower())).ToList();
            }
      

            var model = new MoviesViewModel()
            {
                Movies = movies
        
            };


            return View("Movies", model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }

        [HttpGet]
        public ActionResult Create() 
        {
			ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
			return View();


        }


        [HttpPost]
        public ActionResult Create(Movie m)
        {
            //Model Binding

            //var m = new Movie()
            //{
            //    Title = Title,
            //    Description = Description,
            //    Director = Director,
            //    ImageUrl = ImagerUrl,
            //    GenreId = GenreId
            //};


            if (ModelState.IsValid)
            {
				MovieRepository.Add(m);
				TempData["Message"] = $"{m.Title} İsimli Film Eklendi";
				return RedirectToAction("List");
			}

			ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
			return View();

            


            


        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            ViewBag.Genres =new SelectList(GenreRepository.Genres,"GenreId","Name");

            return View(MovieRepository.GetById(id) );


        }




        [HttpPost]
        public ActionResult Edit(Movie m)
        {
			//Model Binding


			if (ModelState.IsValid)
			{
				MovieRepository.Edit(m);


				// /Movies/details/1
				return RedirectToAction("Details", "Movies", new { @id = m.MovieId });

			}

			ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
			return View(m);


		}



        [HttpPost]
        public ActionResult Delete(int MovieId,string Title)
        {



           MovieRepository.Delete(MovieId);
            TempData["Message"] = $"{Title} İsimli Film Silindi";
            return RedirectToAction("List");


        }


    }
}
