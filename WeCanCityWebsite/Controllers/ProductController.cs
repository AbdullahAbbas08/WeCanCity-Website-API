using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WeCanCityWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Db_Context db_Context;
        private readonly Helper helper;

        public ProductController(Db_Context db_Context, IOptions<Helper> helper)
        {
            this.db_Context = db_Context;
            this.helper = helper.Value;
        }

        [HttpGet]
        public ActionResult<List<Product>> get()
        {
            return db_Context.Product.OrderBy(x=>x.Order).ToList();
        }

        [HttpPost]
        public ActionResult<Product> post([FromForm] ProductDTO model)
        {
            var entity = new Product()
            {
               Title =model.Title.ToString(),
               Order = (int)model.Order,
               Video_URL = model.Video_URL.ToString(),
               Description = model.Description.ToString(),
               ImagePath = helper.UploadImage(model.image),
               Keywords = model.Keywords.ToString(),
               YEAR =(int)model.YEAR
            };

            db_Context.Product.Add(entity);
            db_Context.SaveChanges();
            return entity;
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, [FromForm] ProductDTO model)
        {

            if (model != null)
            {
                var old = db_Context.Product.Find(id);
                old.Title = model.Title ?? old.Title;
                old.Description = model.Description ?? old.Description;
                old.YEAR = model.YEAR ?? old.YEAR;
                old.Video_URL = model.Video_URL ?? old.Video_URL;
                old.ImagePath = model.image != null ? helper.UploadImage(model.image) : old.ImagePath;
                old.Order = model.Order ?? old.Order;
                db_Context.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> delete(int id)
        {
            var obj = db_Context.Product.Find(id);
            db_Context.Product.Remove(obj);
            db_Context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
