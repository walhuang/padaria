using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Models
{
    class Compra
    {
        //representa a lista de produtos em um compra.
        public int CompraId { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorTroco { get; set; }
        public DateTime DataPagamento { get; set; }

        public int ComandaId { get; set; }

        public virtual Comanda Comanda { get; set; }

        public virtual ICollection<CompraProduto> CompraProdutos { get; set; }
    }
}
