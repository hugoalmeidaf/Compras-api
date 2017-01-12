using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Pessoa
    {
        public Guid ID { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? UltimoAcesso { get; set; }

        public virtual ICollection<Lista> Listas { get; set; }

        public Pessoa()
        {
            this.ID = Guid.NewGuid();
            this.DataCadastro = DateTime.Now;
            this.Listas = new HashSet<Lista>();
        }
    }
}