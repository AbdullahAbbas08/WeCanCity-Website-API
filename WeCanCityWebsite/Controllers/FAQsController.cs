using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WeCanCityWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQsController : ControllerBase
    {
        private readonly Db_Context db_Context;
        private readonly Helper helper;

        public FAQsController(Db_Context db_Context, IOptions<Helper> helper)
        {
            this.db_Context = db_Context;
            this.helper = helper.Value;
        }

        [HttpGet]
        public ActionResult<List<FAQs>> get()
        {
            return db_Context.FAQs.ToList();
        }

        [HttpPost]
        public ActionResult<FAQs> post([FromForm] FAQsDTO model)
        {
            var entity = new FAQs()
            {
                Order = (int)model.Order,
                Answer = model.Answer,
                Question = model.Question,
            };

            db_Context.FAQs.Add(entity);
            db_Context.SaveChanges();
            return entity;
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, [FromForm] FAQsDTO model)
        {

            if (model != null)
            {
                var old = db_Context.FAQs.Find(id);
                old.Order = model.Order ?? old.Order;
                old.Question = model.Question ?? old.Question;
                old.Answer = model.Answer ?? model.Answer;
                db_Context.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<FAQs> delete(int id)
        {
            var obj = db_Context.FAQs.Find(id);
            db_Context.FAQs.Remove(obj);
            db_Context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
