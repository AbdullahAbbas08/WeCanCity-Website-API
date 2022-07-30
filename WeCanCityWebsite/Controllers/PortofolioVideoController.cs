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
    public class PortofolioVideoController : ControllerBase
    {
        private readonly Db_Context db_Context;
        private readonly Helper helper;

        public PortofolioVideoController(Db_Context db_Context, IOptions<Helper> helper)
        {
            this.db_Context = db_Context;
            this.helper = helper.Value;
        }

        [HttpGet]
        public ActionResult<List<PortofolioVideo>> get()
        {
            return db_Context.PortofolioVideo.Include(x => x.ServiceCategories).OrderBy(x => x.Order).ToList();
        }

        [HttpPost]
        public ActionResult<PortofolioVideo> post([FromForm] PortofolioVideoDTO model)
        {
            var entity = new PortofolioVideo()
            {
                Service_Category_ID = (int)model.Service_Category_ID,
                Order = (int)model.Order,
                ImagePath = helper.UploadImage(model.image),
                Description = model.Description.ToString(),
                ProjectName = model.ProjectName.ToString(),
                VideoUrl = model.VideoUrl.ToString(),
            };

            db_Context.PortofolioVideo.Add(entity);
            db_Context.SaveChanges();
            return entity;
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, [FromForm] PortofolioVideoDTO model)
        {

            if (model != null)
            {
                var old = db_Context.PortofolioVideo.Find(id);
                old.Description = model.Description ?? old.Description;
                old.ImagePath = model.image != null ? helper.UploadImage(model.image) : old.ImagePath;
                old.Order = model.Order ?? old.Order;
                old.VideoUrl = model.VideoUrl ?? old.VideoUrl;
                old.ProjectName = model.ProjectName ?? old.ProjectName;
                old.Service_Category_ID = model.Service_Category_ID ?? old.Service_Category_ID;
                db_Context.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<PortofolioVideo> delete(int id)
        {
            var obj = db_Context.PortofolioVideo.Find(id);
            db_Context.PortofolioVideo.Remove(obj);
            db_Context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
