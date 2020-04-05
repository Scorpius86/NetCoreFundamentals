using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCore.Fundamentals.Client.Web.Data.Context;
using NetCore.Fundamentals.Client.Web.Data.Entities;
using NetCore.Fundamentals.Client.Web.Models;

namespace NetCore.Fundamentals.Client.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly GalaxyContext _context;

        public PostsController(GalaxyContext context)
        {
            _context = context;
        }

        // GET: Posts
        public IActionResult Index()
        {
            //var galaxyContext = _context.Posts.Include(p => p.UsuarioIdActualizacionNavigation).Include(p => p.UsuarioIdCreacionNavigation).Include(p => p.UsuarioIdPropietarioNavigation);
            //return View(await galaxyContext.ToListAsync());

            var query = from p in _context.Posts
                        select new PostViewModel
                        {
                            Contenido = p.Contenido,
                            FechaActualizacion = p.FechaActualizacion,
                            FechaCreacion=p.FechaCreacion,
                            PostId = p.PostId,
                            Titulo = p.Titulo,
                            UsuarioIdActualizacion = p.UsuarioIdActualizacion,
                            UsuarioIdCreacion   = p.UsuarioIdCreacion,
                            UsuarioIdPropietario = p.UsuarioIdPropietario,
                            UsuarioActualizacion = new UsuarioViewModel
                            {
                                UsuarioId = p.UsuarioIdActualizacionNavigation.UsuarioId,
                                NombreUsuario = p.UsuarioIdActualizacionNavigation.NombreUsuario,
                                ApellidoMaterno = p.UsuarioIdActualizacionNavigation.ApellidoMaterno,
                                ApellidoPaterno = p.UsuarioIdActualizacionNavigation.ApellidoPaterno
                            } ,
                            UsuarioCreacion = new UsuarioViewModel
                            {
                                UsuarioId = p.UsuarioIdCreacionNavigation.UsuarioId,
                                NombreUsuario = p.UsuarioIdCreacionNavigation.NombreUsuario,
                                ApellidoMaterno = p.UsuarioIdCreacionNavigation.ApellidoMaterno,
                                ApellidoPaterno = p.UsuarioIdCreacionNavigation.ApellidoPaterno
                            },
                            UsuarioPropietario = new UsuarioViewModel
                            {
                                UsuarioId = p.UsuarioIdPropietarioNavigation.UsuarioId,
                                NombreUsuario = p.UsuarioIdPropietarioNavigation.NombreUsuario,
                                ApellidoMaterno = p.UsuarioIdPropietarioNavigation.ApellidoMaterno,
                                ApellidoPaterno = p.UsuarioIdPropietarioNavigation.ApellidoPaterno
                            }
                        };

            //var queryFilter = query.Where(w => w.UsuarioPropietario.UsuarioId == 1);
            //var queryFilter = query.Where(w => EF.Functions.Like(w.UsuarioPropietario.NombreUsuario, "%Mart%"));
            var queryFilter = from q in query
                              where EF.Functions.Like(q.UsuarioPropietario.NombreUsuario, "%Mar%")
                              select q;

            List < PostViewModel > posts = queryFilter.ToList();

            return View(posts);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
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
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombre");
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombre");
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombre");
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
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdPropietario);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdPropietario);
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
            ViewData["UsuarioIdActualizacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdActualizacion);
            ViewData["UsuarioIdCreacion"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdCreacion);
            ViewData["UsuarioIdPropietario"] = new SelectList(_context.Usuarios, "UsuarioId", "ApellidoMaterno", post.UsuarioIdPropietario);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
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
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
