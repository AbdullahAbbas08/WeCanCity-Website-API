using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WeCanCityWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly Db_Context db_Context;
        private readonly Helper helper;

        public ServiceController(Db_Context db_Context,IOptions<Helper> helper)
        {
            this.db_Context = db_Context;
            this.helper = helper.Value;
        }

        [HttpGet]
        public ActionResult<List<Service>> get()
        {
            return db_Context.Service.Include(x=>x.ServiceCategories).OrderBy(x=>x.Order).ToList();
        }

        [HttpPost]
        public ActionResult<Service> post([FromForm] ServiceDTO service)
        {
            var _service = new Service()
            {
                Keywords = service.Keywords,
                Description = service.Description,
                Service_Category_ID = (int)service.Service_Category_ID,
                Title = service.Title,
                Video_URL = service.Video_URL,
                ImagePath = helper.UploadImage(service.image),
                Order = (int)service.Order,
            };

            db_Context.Service.Add(_service);
            db_Context.SaveChanges();
            return _service;
        }

        [HttpPut("{id}")]
        public ActionResult put(int id , [FromForm] ServiceDTO service)
        {

            if (service != null)
            {
                var old = db_Context.Service.Find(id);
                old.Keywords = service.Keywords ?? old.Keywords;
                old.Description = service.Description ?? old.Description;
                old.Service_Category_ID = service.Service_Category_ID ?? old.Service_Category_ID;
                old.Title = service.Title ?? old.Title;
                old.Video_URL = service.Video_URL ?? old.Video_URL;
                old.ImagePath = service.image != null ? helper.UploadImage(service.image) : old.ImagePath;
                old.Order = service.Order ?? old.Order;
                db_Context.SaveChanges();
            }
            return Ok() ;
        }

        [HttpDelete("{id}")]
        public ActionResult<Service> delete(int id)
        {
            var obj = db_Context.Service.Find(id);
            db_Context.Service.Remove(obj);
            db_Context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
