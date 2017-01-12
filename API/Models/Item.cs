using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Item
    {
        public int ID { get; set; }
        public int ListaID { get; set; }

        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Realizado { get; set; }

        public virtual Lista Lista { get; set; }

        public Item()
        {
            this.DataCadastro = DateTime.Now;
            this.Realizado = false;
        }
    }
}