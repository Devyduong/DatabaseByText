using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBlog.DataAccess;
using FBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBlog.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryDataAccess _category;
        public CategoryController(ICategoryDataAccess category)
        {
            _category = category;
        }
        // GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<Category> GetAllCategories()
        //{
        //    return _category.SelectAllCategory();
        //}

        [HttpPost("[action]")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            string entity = "{\"ID\":\"" + category.ID + "\",\"Title\":\"" + category.Title + "\"" + ",\"Status\":\"" + category.Status + "\"},";
            var category1 = JsonConvert.DeserializeObject<Category>(entity);
            _category.AddCategory(entity);
            return Ok();
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
