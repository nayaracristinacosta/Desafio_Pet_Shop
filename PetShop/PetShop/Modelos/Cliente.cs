using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Modelos
{
    public class Cliente
    {
        public int IdentificadorCliente { get; set; }
        public string? NomeCliente { get; set; }
        public string Cpf { get; set; }
        public string DataDeNascimento { get; set; }
    }
}
