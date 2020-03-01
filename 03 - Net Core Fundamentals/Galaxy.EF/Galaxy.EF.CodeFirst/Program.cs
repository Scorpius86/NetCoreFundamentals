using Galaxy.EF.CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Galaxy.EF.CodeFirst
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

            using (var cntx = new GalaxyDatabaseContext(optionsBuilder.Options))
            {
                var posts = cntx.Posts.ToList();

                Console.WriteLine("Lista de Post con Repository");
                Console.WriteLine("============================");

                posts.ForEach(post =>
                {
                    Console.WriteLine(post.Titulo);
                });

                //-----------------------------------------------------------------------------------------------
                posts = cntx.Posts.FromSql("uspListPost").ToList();

                Console.WriteLine("\nLista de Post con SP");
                Console.WriteLine("====================");

                posts.ForEach(post =>
                {
                    Console.WriteLine(post.Titulo);
                });

                //-----------------------------------------------------------------------------------------------
                Console.WriteLine("\nLista de Post con Command");
                Console.WriteLine("===========================");
                using (var command = cntx.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Post";
                    cntx.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                Console.WriteLine(result.GetString(1));
                            }
                        }
                        
                    }
                }
            }


            Console.ReadKey();
        }
    }
}
