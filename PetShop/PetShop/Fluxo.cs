using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Fluxo
    {
        public List<Cliente> clientes = new List<Cliente>();
        public void Executar()
        {
            Menu();
        }

        public void Menu()
        {
            bool FimExecucaoMenu = true;
            bool FimExecucaoSubMenu = true;

            do
            {

                Console.Clear();
                Console.WriteLine("#**************************************#");
                Console.WriteLine("#***************PetShop****************#");
                Console.WriteLine("#**************************************#");
                Console.WriteLine("# ---------- MENU PRINCIPAL ---------- #");              
                Console.WriteLine(" 1 - Cadastrar Clientes ");
                Console.WriteLine(" 2 - Listar Clientes ");
                Console.WriteLine(" 3 - Buscar um cliente por CPF ");
                Console.WriteLine(" 4 - Listar os aniversariantes do mês ");
                Console.WriteLine(" 5 - Sair ");
                Console.WriteLine("#**************************************#");
                Console.WriteLine(Environment.NewLine);
                Console.Write("Digite sua opção: ");

                int opcaoMenuPrincipal = int.Parse(Console.ReadLine());

                switch (opcaoMenuPrincipal)
                {

                    case 1:

                        Console.Clear();

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("#**************************************#");
                            Console.WriteLine("# ------------- Clientes ------------- #");
                            Console.WriteLine("#**************************************#");
                            Console.WriteLine(" 1 - Incluir Cliente ");
                            Console.WriteLine(" 2 - Alterar Cliente ");
                            Console.WriteLine(" 3 - Excluir Cliente ");
                            Console.WriteLine(" 4 - Voltar ao menu principal ");
                            Console.WriteLine("#**************************************#");
                            Console.WriteLine(Environment.NewLine);
                            Console.Write("Digite sua opção: ");

                            int opcaoMenuCliente = int.Parse(Console.ReadLine());

                            switch (opcaoMenuCliente)
                            {
                                case 1:
                                    Console.Clear();
                                    AdcionarCliente();
                                    
                                    break;

                                case 2:
                                    Console.Clear();
                                    break;

                                case 3:
                                    Console.Clear();
                                    break;

                                case 4:
                                    //Console.Clear();
                                    FimExecucaoSubMenu = false;
                                    //FimExecucaoMenu = false;

                                    break;                                  

                                default:
                                    //Console.Clear();
                                    break;

                            }

                        }
                        while (FimExecucaoSubMenu);
                        break;

                    case 2:

                        Console.Clear();
                        int contCliente = 1;
                        foreach (Cliente cliente in clientes)
                        {
                            
                            Console.WriteLine($"Cliente {contCliente}");
                            Console.WriteLine(cliente.NomeCliente);
                            Console.WriteLine(cliente.Cpf);
                            Console.WriteLine(cliente.DataDeNascimento);
                            Console.WriteLine("========================");
                            contCliente++;
                        }
                        Console.ReadLine();

                        break;

                    case 3:
                        Console.WriteLine("Teste!!");
                        break;

                    case 4:
                        Console.WriteLine("Teste!!");
                        break;

                    case 5:
                        FimExecucaoMenu = false;
                        break;

                    default:

                        break;

                }

            } while (FimExecucaoMenu);
  

        }

        public void AdcionarCliente()
        {
            bool sairAdicionarCliente = true;

            do
            {
                Console.WriteLine("Informe o nome do Cliente: ");
                string nomeCliente = Console.ReadLine();

                bool nomeClienteValido = Validacoes.ValidaNome(nomeCliente);

                if (!nomeClienteValido)
                {

                    return;
                }

                var padronizarNomeCliente = nomeCliente.ToUpper();

                Console.WriteLine("Informe o CPF do cliente, favor digitar somente números: ");
                string cpfCliente = Console.ReadLine();

                bool cpfClienteValido = Validacoes.ValidaCpf(cpfCliente);

                if (!cpfClienteValido)
                {

                    return;
                }

                string padronizarCpf = FormataCPF(cpfCliente);

                Console.WriteLine("Informe a Data de Nascimento com o formato dd/mm/aaaa: ");
                string dataDeNascimento = Console.ReadLine();
                Validacoes.ValidaDataDeNascimento(dataDeNascimento);

                var cliente = new Cliente();
                cliente.NomeCliente = padronizarNomeCliente;
                cliente.Cpf = padronizarCpf;
                cliente.DataDeNascimento = dataDeNascimento;

                clientes.Add(cliente);

                Console.Clear();
                Console.WriteLine("Deseja incluir mais um cliente?(SIM OU NAO)");
                var lerOpcao = Console.ReadLine().ToUpper();
                
                if (lerOpcao == "SIM")
                {
                    sairAdicionarCliente = true;
                }
                else
                {
                    sairAdicionarCliente = false;
                }

                
               

            } while (sairAdicionarCliente);

        }

        public string FormataCPF(string cpf)
        {
            string response = cpf.Trim();
            if (response.Length == 11)
            {
                response = response.Insert(9, "-");
                response = response.Insert(6, ".");
                response = response.Insert(3, ".");
            }
            return response;
        }
    }
}
    