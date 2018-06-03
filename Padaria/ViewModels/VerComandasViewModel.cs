using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.ViewModels
{
    class VerComandasViewModel
    {
        public DateTime DataPagamento { get; set; }
        public int ComandaId { get; set; }
        public int CompraId { get; set; }

        public decimal ValorPago { get; set; }

        public decimal ValorTroco { get; set; }

        public decimal PrecoTotal { get; set; }
    }
}
