using Data.Dto;
using Data.Entity;
using DataAccess.Repos;

namespace Business.Managers
{
    public class ProductManager
    {
        private readonly ProductRepository repository;
        public ProductManager(ProductRepository repository)
        {
            this.repository = repository;
        }

        public void Add(ProductCreateDto productCreateDto)
        {
            Product product = new()
            {
                Name = productCreateDto.Name,
                Description = productCreateDto.Description,
                Price = productCreateDto.Price
            };


            repository.Add(product);
        }
        public void Update(ProductUpdateDto productUpdateDto)
        {
            Product product = new()
            {
                Id = productUpdateDto.Id,
                Name = productUpdateDto.Name,
                Description = productUpdateDto.Description,
                Price = productUpdateDto.Price
            };
            repository.Update(product);
        }
        public void Delete(string id)
        {
            repository?.Delete(id);
        }
        public async Task<List<ProductDto>> GetAll()
        {
            var list = (await repository.GetAll()).Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).ToList();
            return list;
        }

    }
}