using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemiyWebApi.DAL.Context;
using UdemiyWebApi.DAL.Entities;

namespace UdemiyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using var context = new UdemiyWebApiContext();

            return Ok(context.Categories.ToList());


        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var context = new UdemiyWebApiContext();
            var category = context.Categories.Find(id);
            if (category==null)
            {
                return NotFound();
            }

               

            return Ok(category);


        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            using var context = new UdemiyWebApiContext();
            var categoryim = context.Categories.Find(category.Id);
            if (category == null)
            {
                return NotFound();
            }

            categoryim.Name = category.Name;
            context.Update(categoryim);
            context.SaveChanges();

            return NoContent();


        }



        [HttpDelete("{id}")]
        public IActionResult besirDelet(int id)
        {
            using var context = new UdemiyWebApiContext();
            var category = context.Categories.Find(id);

      
            if (category == null)
            {
                return NotFound();
            }

        context.Remove(category);
            context.SaveChanges();

            return Ok(category);


        }



        [HttpPost]
        public IActionResult besirEkle(Category model)
        {
            using var context = new UdemiyWebApiContext();
            var category = context.Categories.Add(model);


            if (category == null)
            {
                return NotFound();
            }

          
            context.SaveChanges();

            return Created("", model);


        }



        [HttpGet("{id}/blogs")]
        public IActionResult GetWithBlogById(int id)
        {
            using var context = new UdemiyWebApiContext();
            var category = context.Categories.Find(id);


            if (category == null)
            {
                return NotFound();
            }

         var categorywithBlos=   context.Categories.Where(I=>I.Id==id).Include(I=>I.Blogs).ToList();

            return Ok(category);


        }




    }
}