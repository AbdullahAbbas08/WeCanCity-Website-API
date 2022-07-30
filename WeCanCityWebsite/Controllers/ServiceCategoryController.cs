using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WeCanCityWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly Db_Context db_Context;
        private readonly Helper helper;

        public ServiceCategoryController(Db_Context db_Context, IOptions<Helper> helper )
        {
            this.db_Context = db_Context;
            this.helper = helper.Value;
        }

        [HttpGet]
        public ActionResult<List<ServiceCategories>> get()
        {
            return db_Context.ServiceCategories.OrderBy(x => x.Order).ToList();
        }

        [HttpPost]
        public ActionResult<ServiceCategories> post([FromForm]ServiceCategoriesDTO model)
        {
            var _ServiceCategories = new ServiceCategories()
            {
                ImagePath = helper.UploadImage(model.image),
                Order = (int)model.Order,
                Title = model.Title
            };

            if (_ServiceCategories != null)
            {
                db_Context.ServiceCategories.Add(_ServiceCategories);
                db_Context.SaveChanges();
            }
            return _ServiceCategories;
        }

        [HttpPut("{id}")]
        public ActionResult<ServiceCategories> put(int id , [FromForm] ServiceCategoriesDTO model)
        {
            var old = db_Context.ServiceCategories.Find(id);
            old.Order = model.Order??old.Order;
            old.Title = model.Title??old.Title;
            if(model.image !=null) old.ImagePath =helper.UploadImage(model.image);
             db_Context.SaveChanges();
            
            return old;
        }

        [HttpDelete("{id}")]
        public ActionResult<ServiceCategories> delete(int id)
        {
            var obj = db_Context.ServiceCategories.Find(id);
            db_Context.ServiceCategories.Remove(obj);
            db_Context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
