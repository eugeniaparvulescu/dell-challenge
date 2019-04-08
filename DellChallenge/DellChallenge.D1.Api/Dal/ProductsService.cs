using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;
using DellChallenge.D1.Api.Exceptions;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Update(string id, UpdateProductDto value)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ProductException("Invalid id.");
            }
            if (value == null)
            {
                throw new ProductException("Invalid request.");
            }

            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new ProductException($"The product with id { id } does not exist.");
            }

            MapToData(value, product);
            _context.SaveChanges();
            var updatedDto = MapToDto(product);

            return updatedDto;
        }

        public ProductDto Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ProductException("Invalid id.");
            }

            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new ProductException($"The product with id { id } does not exist.");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            var deletedDto = MapToDto(product);

            return deletedDto;
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private void MapToData(UpdateProductDto source, Product destination)
        {
            destination.Category = source.Category;
            destination.Name = source.Name;
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
