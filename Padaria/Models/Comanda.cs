using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Models
{
    class Comanda
    {
        //representa comanda
        public int ComandaId { get; set; }
        public int Codigo { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
