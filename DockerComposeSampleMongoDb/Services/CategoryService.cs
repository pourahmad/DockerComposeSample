using DockerComposeSampleMongoDb.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace DockerComposeSampleMongoDb.Services
{
    public class CategoryService(MongoDbContext context) : ICategoryService
    {
        private readonly MongoDbContext _context = context;

        public async Task<object> GetByIdAsync(ObjectId id)
        {
            try
            {
                var result = await _context.Categories
                    .Where(w => w._id == id)
                    .FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> GetAllAsync()
        {
            try
            {
                var result = await _context.Categories
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<object> AddAsync(CategoryDto category)
        {
            try
            {
                var newCategory = new Entities.Category
                {
                    Name = category.Name,
                    Description = category.Description,
                    IsActive = category.IsActive,
                };

                await _context.Categories.AddAsync(newCategory);
                await _context.SaveChangesAsync();

                return newCategory;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> UpdateAsync(CategoryDto category)
        {
            try
            {
                var hasCategory = await _context.Categories
                   .FindAsync(category._id);

                hasCategory.Name = category.Name;
                hasCategory.Description = category.Description;
                hasCategory.IsActive = category.IsActive;

                _context.Categories.Update(hasCategory);
                await _context.SaveChangesAsync();

                return hasCategory;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<object> DeleteAsync(ObjectId id)
        {
            try
            {
                var hasCategory = await _context.Categories
                .FindAsync(id);

                _context.Categories.Remove(hasCategory);
                await _context.SaveChangesAsync();

                return "deleted 😎";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}