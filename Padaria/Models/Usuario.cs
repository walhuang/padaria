using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Models
{
    class Usuario
    {
        //Entidade Usuário para login do caixa
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool isAdministrador { get; set; }
    }
}
