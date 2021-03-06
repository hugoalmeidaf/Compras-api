﻿using API.Data;
using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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

        public IEnumerable<Item> Get()
        {
            return _db.Itens.ToList();
        }

        public IEnumerable<Item> Get(string busca)
        {
            var pattern = $"%{busca}%";
            return _db.Itens.Where(i => SqlFunctions.PatIndex(pattern, i.Nome) > 0).ToList();
        }

        public void Post([FromBody]Item item)
        {
            _db.Itens.Add(item);
            _db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }
    }
}
