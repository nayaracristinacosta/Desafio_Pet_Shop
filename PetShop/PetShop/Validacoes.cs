using System;
using System.Collections.Generic;
using System.Globalization;
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
            string nomeErro = "***CADASTRO NÃO PERMITIDO!***\nNão é possível incluir nome do cliente com caracteres especiais, números e espaços em branco.\nPressione ENTER para retornar ao menu anterior...";
            string erroNumeroDeCaracteres = "***CADASTRO NÃO PERMITIDO!***\nFavor digitar de 3 a 80 caracteres.\nPressione ENTER para retornar ao menu anterior...";
            
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
        public static bool ValidaCpf(string cpf)
        {
       
            string valor = cpf.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
            {
                ObterErroCpf();
                return false;
            }    

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")
            {
                ObterErroCpf();
                return false;
            }

            int[] numeros = new int[11];

            bool isNumeric = long.TryParse(cpf, out _);

            if (!isNumeric)
            {
                ObterErroCpf();
                return false;
            }

            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(valor[i].ToString());
            }
              
            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {

                if (numeros[9] != 0)
                {
                    ObterErroCpf();
                    return false;
                }

            }

            else if (numeros[9] != 11 - resultado)
            {
                ObterErroCpf();
                return false;
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
         
                soma += (11 - i) * numeros[i];
             
            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {

                if (numeros[10] != 0)
                {
                    ObterErroCpf();
                    return false;

                }

            }

            else if (numeros[10] != 11 - resultado)
            {
                ObterErroCpf();
                return false;
            }
               

            return true;

        }

        public static void ObterErroCpf()
        {
            Console.Clear();
            Console.WriteLine("***CADASTRO NÃO PERMITIDO!***\nCPF INVÁLIDO\nPressione ENTER para retornar ao menu anterior...");
            Console.ReadLine();
        }


        public static bool ValidaDataDeNascimento(string dataDeNascimento)
        {
            string mensagemDeErroParaData1 = "***CADASTRO NÃO PERMITIDO!***\nVocê tem idade inferior a 16 anos!\nPressione ENTER para retornar ao menu anterior...";
            string mensagemDeErroParaData2 = "***CADASTRO NÃO PERMITIDO!***\nVocê tem idade superior a 120 anos!\nPressione ENTER para retornar ao menu anterior...";
            string mensagemDeErroParaData3 = "***CADASTRO NÃO PERMITIDO!***\nFormato da data incorreta, favor seguir o formato de data dd/mm/aaaa.\nPressione ENTER para retornar ao menu anterior...";

            if(dataDeNascimento.Contains('-'))
            {
                Console.Clear();
                Console.WriteLine(mensagemDeErroParaData3);
                Console.ReadLine();
                return false;
            }

            var validaFormatoData = DateTime.TryParse(dataDeNascimento, out _);
            if (!validaFormatoData)
            {
                Console.Clear();
                Console.WriteLine(mensagemDeErroParaData3);
                Console.ReadLine();
                return false;
            }

            var dataDeNascimentoConvertida = DateTime.Parse(dataDeNascimento, new CultureInfo("en-US"));
            var calculoData = DateTime.Now.Year - dataDeNascimentoConvertida.Year;

            if (calculoData <= 16)
            {
                Console.Clear();
                Console.WriteLine(mensagemDeErroParaData1);
                Console.ReadLine();
                return false;
            }

            if (calculoData >= 120)
            {
                Console.Clear();
                Console.WriteLine(mensagemDeErroParaData2);
                Console.ReadLine();
                return false;
            }

            return true;
        }
    }
}
