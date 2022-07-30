using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WeCanCityWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortofolioItemsController : ControllerBase
    {
        private readonly Db_Context db_Context;
        private readonly Helper helper;

        public PortofolioItemsController(Db_Context db_Context, IOptions<Helper> helper)
        {
            this.db_Context = db_Context;
            this.helper = helper.Value;
        }

        [HttpGet]
        public ActionResult<List<PortofolioItems>> get()
        {
            return db_Context.PortofolioItems.Include(x=>x.Portofolio).OrderBy(x=>x.Order).ToList();
        }

        [HttpPost]
        public ActionResult<PortofolioItems> post([FromForm] PortofolioItemsDTO model)
        {
            var entity = new PortofolioItems()
            {
                Order = (int)model.Order,
                ImagePath = helper.UploadImage(model.image),
               Portfolio_ID =(int)model.Portfolio_ID
            };
            db_Context.PortofolioItems.Add(entity);
            db_Context.SaveChanges();
            return entity;
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, [FromForm] PortofolioItemsDTO model)
        {

            if (model != null)
            {
                var old = db_Context.PortofolioItems.Find(id);
                old.Order = model.Order ?? old.Order;
                old.ImagePath = model.image != null ? helper.UploadImage(model.image) : old.ImagePath;
                old.Portfolio_ID = (int)model.Portfolio_ID ;
                db_Context.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<PortofolioItems> delete(int id)
        {
            var obj = db_Context.PortofolioItems.Find(id);
            db_Context.PortofolioItems.Remove(obj);
            db_Context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
