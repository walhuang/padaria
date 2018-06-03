using Padaria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.ViewModels
{
    class CompraProdutosViewModel
    {
        public int CompraProdutoId { get; set; }
        public int CodigoBarra { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
