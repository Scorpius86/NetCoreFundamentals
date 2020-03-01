
using Galaxy.EF.ApplicationService;
using Galaxy.EF.CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Galaxy.EF.TestService
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();


            var optionsBuilder = new DbContextOptionsBuilder<GalaxyDatabaseContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("GalaxyDatabase"));

            PostApplicationService postApplicationService = new PostApplicationService(new GalaxyDatabaseContext(optionsBuilder.Options));

            //---------------------------------------------------------------------------------------------------
            Console.WriteLine("List Post");
            Console.WriteLine("=========");

            List<Post> posts = postApplicationService.List();
            posts.ForEach(item =>
            {
                Console.WriteLine(item.Titulo);
            });
            //---------------------------------------------------------------------------------------------------
            Console.WriteLine("\nGet Post");
            Console.WriteLine("=========");

            Post post = postApplicationService.Get(1);
            Console.WriteLine(post.Titulo);
            //---------------------------------------------------------------------------------------------------
            Console.WriteLine("\nInsert Post");
            Console.WriteLine("=========");

            Post postNew = new Post();
            postNew.Titulo = "Test";
            postNew.Contenido = "Test";
            postNew = postApplicationService.Insert(postNew);
            Console.WriteLine(postNew.Titulo);
            //---------------------------------------------------------------------------------------------------
            Console.WriteLine("\nUpdate Post");
            Console.WriteLine("=========");

            Post postUpdate = postApplicationService.Get(postNew.PostId);
            postUpdate.Titulo = "TestUpdate";
            postUpdate.Contenido = "TestUpdate";
            postApplicationService.Update(postUpdate);
            Console.WriteLine(postUpdate.Titulo);
            //---------------------------------------------------------------------------------------------------
            Console.WriteLine("\nDelete Post");
            Console.WriteLine("=========");

            Post postDelete = postApplicationService.Delete(postNew.PostId);
            Console.WriteLine(postDelete.Titulo);

            Console.ReadKey();
        }
    }
}
