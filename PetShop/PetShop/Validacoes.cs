using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetShop
{
    public static class Validacoes
    {
        public static bool ValidaNome(string nome)
        {            
            string nomeErro = "***ERRO!! CAMPO INVÁLIDO***\nNão é possível incluir nome do cliente com caracteres especiais, números e espaços em branco.\nPressione ENTER para retornar ao menu anterior...";
            string erroNumeroDeCaracteres = "***ERRO!! CAMPO INVÁLIDO***\nFavor digitar de 3 a 80 caracteres.\nPressione ENTER para retornar ao menu anterior...";
            
            bool isNumeric = Regex.IsMatch(nome, @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]");

            if (isNumeric)
            {
                Console.Clear();       
                Console.WriteLine(nomeErro);
                Console.ReadLine();
                return false;
            }

            foreach(char c in nome)
            {
                if (c >= '0' && c <= '9')
                {
                    Console.Clear();
                    Console.WriteLine(nomeErro);
                    Console.ReadLine();
                    return false;
                }
            }

            if(nome.Length < 4 || nome.Length >= 80)
            {
                Console.Clear();
                Console.WriteLine(erroNumeroDeCaracteres);
                Console.ReadLine();
                return false;
            }

            if(nome == "")
            {
                Console.Clear();
                Console.WriteLine(erroNumeroDeCaracteres);
                Console.ReadLine();
                return false;
            }
              
            return true;
        }
    }
}
