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
    public class ListaController : ApiController
    {
        private CompraContext _db;

        public ListaController()
        {
            _db = new CompraContext();
        }
                
        public IEnumerable<Lista> Get()
        {
            return _db.Listas.ToList();
        }
        
        public void Post([FromBody]Lista lista)
        {
            _db.Listas.Add(lista);
            _db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
    }
}
