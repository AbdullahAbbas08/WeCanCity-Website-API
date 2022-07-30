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
    public class PortofolioController : ControllerBase
    {
        private readonly Db_Context db_Context;
        private readonly Helper helper;

        public PortofolioController(Db_Context db_Context, IOptions<Helper> helper)
        {
            this.db_Context = db_Context;
            this.helper = helper.Value;
        }

        [HttpGet]
        public ActionResult<List<Portofolio>> get()
        {
            return db_Context.Portofolio.Include(x=>x.ServiceCategories).OrderBy(x=>x.Order).ToList();
        }

        [HttpPost]
        public ActionResult<Portofolio> post([FromForm] PortofolioDTO model)
        {
            var entity = new Portofolio()
            {
                Order = (int)model.Order,
                ImagePath = helper.UploadImage(model.image),
                Description = model.Description,
                ProjectName = model.ProjectName,
                Service_Category_ID = (int)model.Service_Category_ID,
            };

            db_Context.Portofolio.Add(entity);
            db_Context.SaveChanges();
            return entity;
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, [FromForm] PortofolioDTO model)
        {

            if (model != null)
            {
                var old = db_Context.Portofolio.Find(id);
                old.Order = model.Order ?? old.Order;
                old.ImagePath = model.image != null ? helper.UploadImage(model.image) : old.ImagePath;
                old.Description = model.Description ?? old.Description;
                old.ProjectName = model.ProjectName ?? old.ProjectName;
                old.Service_Category_ID = model.Service_Category_ID ?? old.Service_Category_ID;
                db_Context.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Portofolio> delete(int id)
        {
            var obj = db_Context.Portofolio.Find(id);
            db_Context.Portofolio.Remove(obj);
            db_Context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
