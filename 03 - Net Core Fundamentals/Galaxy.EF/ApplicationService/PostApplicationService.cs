using Galaxy.EF.CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galaxy.EF.ApplicationService
{
    
    public class PostApplicationService
    {
        private GalaxyDatabaseContext _galaxyContext;
        public PostApplicationService(GalaxyDatabaseContext galaxyContext)
        {
            _galaxyContext = galaxyContext;

        }

        public Post Get(int id)
        {
            var post = _galaxyContext.Posts.Find(id);

            return post;
        }

        public List<Post> List()
        {
            var posts = _galaxyContext.Posts.ToList();

            return posts;
        }

        public void Update(Post post)
        {
            Usuario usuario = _galaxyContext.Usuarios.Find(1);
            Post postUpdate = _galaxyContext.Posts.Find(post.PostId);

            postUpdate.UsuarioIdActualizacionNavigation = usuario;
            postUpdate.Titulo = post.Titulo;
            postUpdate.Contenido = post.Contenido;

            _galaxyContext.Posts.Update(postUpdate);
            _galaxyContext.SaveChanges();
        }

        public Post Insert(Post post)
        {
            Usuario usuario = _galaxyContext.Usuarios.Find(1);
            post.UsuarioIdPropietarioNavigation = usuario;
            post.UsuarioIdActualizacionNavigation = usuario;
            post.UsuarioIdCreacionNavigation = usuario;

            _galaxyContext.Posts.Add(post);
            _galaxyContext.SaveChanges();

            return _galaxyContext.Posts.Find(post.PostId);
        }

        public Post Delete(int id)
        {
            Post post = _galaxyContext.Posts.Find(id);
            _galaxyContext.Posts.Remove(post);
            _galaxyContext.SaveChanges();

            return post;
        }
    }
}
