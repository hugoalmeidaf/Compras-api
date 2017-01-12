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
    public class PessoaController : ApiController
    {
        private CompraContext _db;

        public PessoaController()
        {
            _db = new CompraContext();
        }

        public Pessoa Get()
        {
            var p = new Pessoa();

            _db.Pessoas.Add(p);
            _db.SaveChanges();

            return p;
        }

        public Pessoa Get(Guid ID)
        {
            var p = _db.Pessoas.Find(ID);
            p.UltimoAcesso = DateTime.Now;

            _db.Entry<Pessoa>(p).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return _db.Pessoas.Find(ID);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
    }
}
