using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Models
{
    class CompraProduto
    {
        //relação de compra e produtoW
        public int CompraProdutoId { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorTotal { get; set; }

        public int CompraId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
