using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Galaxy.DI.Client.Web.Context;
using Galaxy.DI.Client.Web.Entities;

namespace Galaxy.DI.Client.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly GalaxyContext _context;

        public PostsController(GalaxyContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var galaxyContext = _context.Post.Include(p => p.UsuarioIdActualizacionNavigation).Include(p => p.UsuarioIdCreacionNavigation).Include(p => p.UsuarioIdPropietarioNavigation);
            return View(await galaxyContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.UsuarioIdActualizacionNavigation)
                .Include(p => p.UsuarioIdCreacionNavigation)
                .Include(p => p.UsuarioIdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuario, "UsuarioId", "Nombre");
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuario, "UsuarioId", "Nombre");
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuario, "UsuarioId", "Nombre");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Titulo,Contenido,UsuarioIdPropietario,UsuarioIdCreacion,FechaCreacion,UsuarioIdActualizacion,FechaActualizacion")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuario, "UsuarioId", "Nombre", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuario, "UsuarioId", "Nombre", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuario, "UsuarioId", "Nombre", post.UsuarioIdPropietario);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuario, "UsuarioId", "ApellidoMaterno", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuario, "UsuarioId", "ApellidoMaterno", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuario, "UsuarioId", "ApellidoMaterno", post.UsuarioIdPropietario);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Titulo,Contenido,UsuarioIdPropietario,UsuarioIdCreacion,FechaCreacion,UsuarioIdActualizacion,FechaActualizacion")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
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
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuario, "UsuarioId", "ApellidoMaterno", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuario, "UsuarioId", "ApellidoMaterno", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuario, "UsuarioId", "ApellidoMaterno", post.UsuarioIdPropietario);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.UsuarioIdActualizacionNavigation)
                .Include(p => p.UsuarioIdCreacionNavigation)
                .Include(p => p.UsuarioIdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.PostId == id);
        }
    }
}
