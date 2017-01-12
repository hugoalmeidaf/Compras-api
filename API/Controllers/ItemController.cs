using API.Data;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ItemController : ApiController
    {
        private CompraContext _db;

        public ItemController()
        {
            _db = new CompraContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }

        public IEnumerable<Item> Get()
        {
            return _db.Itens.ToList();
        }

        public void Post([FromBody]Item item)
        {
            _db.Itens.Add(item);
            _db.SaveChanges();
        }
    }
}
