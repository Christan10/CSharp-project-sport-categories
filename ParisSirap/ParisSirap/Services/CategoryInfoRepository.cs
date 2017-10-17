using System.Collections.Generic;
using System.Linq;
using ParisSirap.Entities;

namespace ParisSirap.Services
{
    public class CategoryInfoRepository : ICategoryInfoRepository
    {
        private readonly CategoryInfoContext _context;

        public CategoryInfoRepository(CategoryInfoContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<Category> GetCategoriesByFirstNamesLetter(string letter)
        {
            return _context.Categories.Where(c => c.Name.ToUpperInvariant().StartsWith(letter.ToUpperInvariant()));
        }

        public Category GetCategory(int categoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void DeleteCategory(int categoryId)
        {
            var toDelete =_context.Categories.FirstOrDefault(c => c.Id == categoryId);
            _context.Categories.Remove(toDelete);
        }
    }
}
