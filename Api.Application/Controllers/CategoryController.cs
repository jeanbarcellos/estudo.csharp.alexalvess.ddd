using Api.Domain.Interfaces;
using Api.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var list = _service.Get();

            return Ok(list);
        }

    }
}