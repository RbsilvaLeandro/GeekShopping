using AutoMapper;
using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Model;
using GeekShopping.Product.API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Products> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Products product = await _context.Products.Where(p => p.id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO product)
        {
            Products createProduct = _mapper.Map<Products>(product);
            _context.Products.Add(createProduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(createProduct);
        }
        public async Task<ProductVO> Update(ProductVO product)
        {
            Products updateProduct = _mapper.Map<Products>(product);
            _context.Products.Add(updateProduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(updateProduct);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Products product = await _context.Products.Where(p => p.id == id).FirstOrDefaultAsync();
                if (product == null) return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }          
    }
}
