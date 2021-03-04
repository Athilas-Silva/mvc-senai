using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Titulo = "When Harry Met Sally",
                        Estreia = DateTime.Parse("1989-2-12"),
                        Genero = "Romantic Comedy",
                        Rating = "R",
                        Preco = 7.99M
                    },

                    new Movie
                    {
                        Titulo = "Ghostbusters ",
                        Estreia = DateTime.Parse("1984-3-13"),
                        Genero = "Comedy",
                        Rating = "R",
                        Preco = 8.99M
                    },

                    new Movie
                    {
                        Titulo = "Ghostbusters 2",
                        Estreia = DateTime.Parse("1986-2-23"),
                        Genero = "Comedy",
                        Rating = "R",
                        Preco = 9.99M
                    },

                    new Movie
                    {
                        Titulo = "Rio Bravo",
                        Estreia = DateTime.Parse("1959-4-15"),
                        Genero = "Western",
                        Rating = "R",
                        Preco = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}