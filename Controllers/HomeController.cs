using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission7_ejake370.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_ejake370.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmissionContext _movieContext { get; set; }

        public HomeController(MovieSubmissionContext temp)
        {

            _movieContext = temp;
        }
        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _movieContext.categories.ToList();
            return View("MovieSubmission", new Movie());
        }
        [HttpPost]
        public IActionResult EnterMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                return View("Confirmation", movie);
            }
            else
            {
                ViewBag.Categories = _movieContext.categories.ToList();
                return View("MovieSubmission", movie);
            }
        }

        public IActionResult MyPodcasts()
        {
            return View("MyPodcasts");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var applications = _movieContext.movies
                .Include(x => x.Category)
                .OrderBy(x => x.title).ToList();

            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _movieContext.categories.ToList();

            var movie = _movieContext.movies.Single(x => x.MovieId == id);
            return View("MovieSubmission", movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie blah)
        {
            _movieContext.Update(blah);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _movieContext.movies.Single(x => x.MovieId == id);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _movieContext.movies.Remove(movie);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
