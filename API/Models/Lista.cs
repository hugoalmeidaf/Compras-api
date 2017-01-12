using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Lista
    {
        public int ID { get; set; }
        public Guid PessoaID { get; set; }

        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Item> Itens { get; set; }

        public Lista()
        {
            this.DataCadastro = DateTime.Now;
            this.Itens = new HashSet<Item>();
        }
    }
}