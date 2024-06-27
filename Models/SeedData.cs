using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAPI.Data;
using System;
using System.Linq;

namespace MyAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyAPIContext(
                      serviceProvider.GetRequiredService<
                          DbContextOptions<MyAPIContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
                context.Movie.AddRange(
                    new Movie { Name = "Iron Man 1", MainLead = "Robert Downey Jr." },
                    new Movie { Name = "Thor: God of Thunder", MainLead = "Chris Hemsworth" },
                    new Movie { Name = "Captain America: The First Avenger", MainLead = "Chris Evans" },
                    new Movie { Name = "The Incredible Hulk", MainLead = "Mark Ruffalo" },
                    new Movie { Name = "Iron Man 2", MainLead = "Robert Downey Jr." },
                    new Movie { Name = "Thor: The Dark World", MainLead = "Chris Hemsworth" },
                    new Movie { Name = "The Avengers", MainLead = "Robert Downey Jr." },
                    new Movie { Name = "Iron Man 3", MainLead = "Robert Downey Jr." },
                    new Movie { Name = "Captain America: The Winter Soldier", MainLead = "Chris Evans" },
                    new Movie { Name = "Avengers: Age of Ultron", MainLead = "Chris Evans" },
                    new Movie { Name = "Thor: Ragnarok", MainLead = "Chris Hemsworth"}
                );
                context.SaveChanges();
            }
        }
    }
}
