using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Models;
using CoreAPI.Models.DTO;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ClassDbContext _context;

        public CategoriesController(ClassDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpotCategoryDTO>>> GetCategories()
        {
            var categoriesDTO = await _context.SpotsCategories.Select(c=>new SpotCategoryDTO
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName   
            }).ToListAsync();
            return Ok(categoriesDTO);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpotCategoryDTO>> GetCategory(int id)
        {
            var category = await _context.SpotsCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            var categoryDTO = new SpotCategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };

            return Ok(categoryDTO);
        }

      
    }
}
