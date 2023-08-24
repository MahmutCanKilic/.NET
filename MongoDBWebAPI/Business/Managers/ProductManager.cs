using AutoMapper;
using Data.Dto;
using Data.Entity;
using DataAccess.Interfaces;
using DataAccess.Repos;

namespace Business.Managers
{
    public class ProductManager
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;
        public ProductManager(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(ProductCreateDto productCreateDto)
        {

           var product = mapper.Map<Product>(productCreateDto);

            repository.Add(product);
        }
        public void Update(ProductUpdateDto productUpdateDto)
        {
            var product = mapper.Map<Product>(productUpdateDto);
            repository.Update(product);
        }
        public void Delete(string id)
        {
            repository.Delete(id);
        }
        public async Task<List<ProductDto>> GetAll()
        {
            var products = await repository.GetAll();
            var productDtos = products.Select(product => mapper.Map<ProductDto>(product)).ToList();
            return productDtos;
        }
        public async Task AddRange(List<ProductCreateDto> productsDto)
        {

            var products = productsDto.Select(dto => mapper.Map<Product>(dto)).ToList();
            await repository.AddRange(products);
        }
    }
}