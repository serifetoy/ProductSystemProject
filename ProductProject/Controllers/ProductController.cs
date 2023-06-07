using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductProject.Models;
using ProductProject.Models.Dto;
using ProductProject.Models.Entities;
using ProductProject.Models.Interfaces;

namespace ProductProject.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        
        private readonly IMapper _mapper;
        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts(int page, int pageSize) 
        {
            return Ok(_repository.GetAll(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Product product = _repository.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("search")]
        public IActionResult Search(string name, int? categoryId, double? minPrice)
        {
            return Ok(_repository.Search(name, categoryId, minPrice));
        }


        [HttpPost]
        public IActionResult Create(CreateProductDto productDto)
        {
            _repository.Add(_mapper.Map<Product>(productDto));

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProductDto updateDto)
        {
            var product = _repository.Update(id, _mapper.Map<Product>(updateDto));
            
            return Ok(_mapper.Map<GetProductDto>(product));    //look over
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            return NoContent();
        }

    }
}
