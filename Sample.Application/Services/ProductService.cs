using Sample.Domain;
using Sample.Persistence.Context;

namespace Sample.Application.Services
{
    public class ProductService
    {
        private ApplicationContext _context;

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Product> GetProduct()
        {
            return _context.Products.ToList();
        }
    }
}
