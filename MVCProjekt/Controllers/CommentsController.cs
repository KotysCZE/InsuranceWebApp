using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProjekt.Data;
using MVCProjekt.Models;
using Newtonsoft.Json.Linq;

namespace MVCProjekt.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Comment.Include(c => c.Client);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comment == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        //GET: Comments/Create
        public async Task<IActionResult> CreateAsync(int value)
        {
            //ViewBag.ClientId = value;
            //ViewData["ClientId"] = new SelectList(_context.Client, "ClientId"); //sem se může dopsat city
            ViewBag.ClientId = value;
            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientId == value);


            return View();
        }



        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,ClientId,CommentText,DateOfInsert")] Comment comment, int value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Clients", new { @id = value });
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "City", comment.ClientId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comment == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "City", comment.ClientId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,ClientId,CommentText,DateOfInsert")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "City", comment.ClientId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comment == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }
            if (comment != null)
            {
                _context.Comment.Remove(comment); //Pro komentáře nepotřebujeme potvrzení, takže ho smažeme rovnou
            }

            await _context.SaveChangesAsync();
            return Redirect($"/Clients/Details/{comment.ClientId}");
            //return View(comment);
        }

        private bool CommentExists(int id)
        {
          return (_context.Comment?.Any(e => e.CommentId == id)).GetValueOrDefault();
        }
    }
}
