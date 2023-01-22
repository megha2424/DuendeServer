using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movies.Client.ApiServices;
using Movies.Client.Models;

namespace Movies.Client.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieApiServices _movieApiServices;

        public MoviesController(IMovieApiServices movieApiServices)
        {
            LoginAndCallBack();
            _movieApiServices = movieApiServices;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _movieApiServices.GetMovies());
        }

        public async Task LoginAndCallBack()
        {
            var idToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            Debug.WriteLine($"Identity token: {idToken}");
            foreach (var c in User.Claims)
            {
                Debug.WriteLine($"{c.Type} {c.Value}");
            }
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // if (id == null || _context.Movie == null)
            // {
            //     return NotFound();
            // }
            //
            // var movie = await _context.Movie
            //     .FirstOrDefaultAsync(m => m.Id == id);
            // if (movie == null)
            // {
            //     return NotFound();
            // }
        
            return NotFound();
        }
        
        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Genre,Title,Rating,ImageUrl,Owner,ReleaseDate")] Movie movie)
        {
            // if (ModelState.IsValid)
            // {
            //     _context.Add(movie);
            //     await _context.SaveChangesAsync();
            //     return RedirectToAction(nameof(Index));
            // }
            return View(movie);
        }
        
        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // if (id == null || _context.Movie == null)
            // {
            //     return NotFound();
            // }
            //
            // var movie = await _context.Movie.FindAsync(id);
            // if (movie == null)
            // {
            //     return NotFound();
            // }
            // return View(movie);
            return NotFound();
        }
        
        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Genre,Title,Rating,ImageUrl,Owner,ReleaseDate")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }
        
            // if (ModelState.IsValid)
            // {
            //     try
            //     {
            //         _context.Update(movie);
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!MovieExists(movie.Id))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }
            //     return RedirectToAction(nameof(Index));
            // }
            return View(movie);
        }
        
        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // if (id == null || _context.Movie == null)
            // {
            //     return NotFound();
            // }
            //
            // var movie = await _context.Movie
            //     .FirstOrDefaultAsync(m => m.Id == id);
            // if (movie == null)
            // {
            //     return NotFound();
            // }
        
            return NotFound();
        }
        
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // if (_context.Movie == null)
            // {
            //     return Problem("Entity set 'MoviesClientContext.Movie'  is null.");
            // }
            // var movie = await _context.Movie.FindAsync(id);
            // if (movie != null)
            // {
            //     _context.Movie.Remove(movie);
            // }
            //
            // await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        // private bool MovieExists(int id)
        // {
        //   // return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
