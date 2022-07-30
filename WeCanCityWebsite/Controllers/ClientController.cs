using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WeCanCityWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly Db_Context db_Context;
        private readonly Helper helper;

        public ClientController(Db_Context db_Context, IOptions<Helper> helper)
        {
            this.db_Context = db_Context;
            this.helper = helper.Value;
        }

        [HttpGet]
        public ActionResult<List<Client>> get()
        {
            return db_Context.Client.OrderBy(x=>x.Order).ToList();
        }

        [HttpPost]
        public ActionResult<Client> post([FromForm] Client model)
        {
            var _Client = new Client()
            {
                Title = model.Title,
                Logo = helper.UploadImage(model.image),
                Order = (int)model.Order,
            };

            db_Context.Client.Add(_Client);
            db_Context.SaveChanges();
            return _Client;
        }

        [HttpPut("{id}")]
        public ActionResult<Client> put([FromForm] Client Client)
        {
            if (Client != null)
            {
                db_Context.Client.Update(Client);
                db_Context.SaveChanges();
            }
            return Client;
        }

        [HttpDelete]
        public ActionResult<Client> delete(int id)
        {
            var obj = db_Context.Client.Find(id);
            db_Context.Client.Remove(obj);
            db_Context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
