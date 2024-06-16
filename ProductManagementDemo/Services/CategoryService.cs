using BusinessObjects;
using Repositories;
using System.Collections.Generic;
namespace Services
{
    public class CategoryService : ICatergoryService
    {
        private readonly ICatergoryRepository iCategoryRepository;

        public CategoryService()
        {
            iCategoryRepository = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return iCategoryRepository.GetCategories();
        }
    }
}