using System.Collections.Generic;
using System.Linq;
using ParisSirap.Entities;

namespace ParisSirap
{
    public static class CategoryInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CategoryInfoContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Basket",
                    Description = "The sport where Lebron is the king."
                },
                new Category()
                {
                    Name = "Football",
                    Description = "The sport where Christiano Ronaldo is a winner."
                },
                new Category()
                {
                    Name = "Boxing",
                    Description = "The sport where Tyson was the best"
                }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
