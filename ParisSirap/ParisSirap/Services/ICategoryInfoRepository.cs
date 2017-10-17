using System.Collections.Generic;
using ParisSirap.Entities;

namespace ParisSirap.Services
{
    public interface ICategoryInfoRepository
    {
        bool CategoryExists(int categoryId);
        IEnumerable<Category> GetCategories();
        Category GetCategory(int categoryId);
        bool Save();
        void DeleteCategory(int categoryId);
        IEnumerable<Category> GetCategoriesByFirstNamesLetter(string letter);
    }
}
