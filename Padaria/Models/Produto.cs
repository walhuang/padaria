using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Models
{
    class Produto
    {
        //representa produto
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int CodigoBarra { get; set; }

        public virtual ICollection<CompraProduto> CompraProdutos { get; set; }
    }
}
