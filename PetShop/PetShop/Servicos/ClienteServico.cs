using PetShop.Modelos;
using PetShop.Utilitarios;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetShop
{
    public class ClienteServico

    {
        private readonly Repositorios.ClienteRepositorio _repositorio;

        public ClienteServico()
        {
            _repositorio = new Repositorios.ClienteRepositorio();
        }

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
                Console.WriteLine(" 1 - Gestão do Cliente");
                Console.WriteLine(" 2 - Gestão do Pet ");     
                Console.WriteLine(" 3 - Sair ");
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
                            Console.WriteLine("# -------- Gestão do Cliente --------- #");
                            Console.WriteLine("#**************************************#");
                            Console.WriteLine(" 1 - Incluir Cliente ");
                            Console.WriteLine(" 2 - Buscar um cliente por CPF ");
                            Console.WriteLine(" 3 - Listar Clientes ");
                            Console.WriteLine(" 4 - Listar os aniversáriantes do mês ");
                            Console.WriteLine(" 5 - Excluir Cliente ");
                            Console.WriteLine(" 6 - Voltar ao menu principal ");
                            Console.WriteLine("#**************************************#");
                            Console.WriteLine(Environment.NewLine);
                            Console.Write("Digite sua opção: ");
                           
                  
                            var opcaoValidada = int. Parse(Console.ReadLine());

                            switch (opcaoValidada)
                            {
                                case 1:
                                    Console.Clear();
                                    AdicionarCliente();
                                    
                                    break;

                                case 2:
                                    Console.Clear();
                                    BuscarClientePorCpf();
                                    break;

                                case 3:
                                    Console.Clear();
                                    ListarCliente();                                  
                                    break;

                                case 4:
                                    Console.Clear();
                                    ListarAniversariantesDoMes();
                                    break;                                  

                                case 5:
                                    Console.Clear();
                                    RemoverCliente();
                                    break;

                                case 6:                                 
                                    FimExecucaoSubMenu = false;                                   
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("***ATENÇÃO***\nOpção Inválida\nFavor informar uma opção Válida!!!\nPressione ENTER para voltar ao menu anterior...");
                                    Console.ReadLine();
                                    break;


                            }

                        }
                        while (FimExecucaoSubMenu);
                        break;

                    case 2:

                        Console.Clear();
                        Console.WriteLine("***EM CONSTRUÇÃO***\nPressione ENTER para voltar ao menu anterior...");
                        Console.ReadLine();

                        break;

                    case 3:
                        FimExecucaoMenu = false;
                        break;

                    default:

                        break;

                }

            } while (FimExecucaoMenu);
  

        }

        public void AdicionarCliente()
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

                string padronizarCpf = FormataCPF(cpfCliente);

                bool validaCpf = _repositorio.SeExiste(padronizarCpf);

                if(validaCpf)
                {
                    Console.Clear();
                    Console.WriteLine("***ATENÇÃO***\nNão é possível cadastrar um CPF já ativo no sistema!!!\nPressione ENTER para voltar ao menu anterior...");
                    Console.ReadLine();
                    return;
                    
                }

                bool cpfClienteValido = Validacoes.ValidaCpf(cpfCliente);

                if (!cpfClienteValido)
                {

                    return;
                }
           
                Console.WriteLine("Informe a Data de Nascimento com o formato dd/mm/aaaa: ");
                string dataDeNascimento = Console.ReadLine();
                bool dataDeNascimentoValido = Validacoes.ValidaDataDeNascimento(dataDeNascimento);

                if (!dataDeNascimentoValido)
                {

                    return;
                }

                var cliente = new Cliente();
                cliente.NomeCliente = padronizarNomeCliente;
                cliente.Cpf = padronizarCpf;
                cliente.DataDeNascimento = dataDeNascimento;

                _repositorio.Inserir(cliente);

                Console.Clear();
                Console.Write("Deseja incluir mais um cliente? \nDIGITE (1-SIM OU 2-NAO):");
                var lerOpcao = int.Parse(Console.ReadLine());
                
                if (lerOpcao == 1)
                {
                    sairAdicionarCliente = true;
                }
                else
                {
                    sairAdicionarCliente = false;
                }

                
               

            } while (sairAdicionarCliente);

        }

        public void ListarCliente()
        {
            var cliente = _repositorio.Listar();
            foreach (var c in cliente)
            {
                Console.WriteLine($"Nº de registro do Cliente: {c.IdentificadorCliente}\nNome do Cliente: {c.NomeCliente}\nCPF: {c.Cpf}\nData de Nascimento:{c.DataDeNascimento}");
                Console.WriteLine("===============================");
            }

            Console.WriteLine("\nDigite ENTER para voltar ao menu anterior...");
            Console.ReadLine();

        }

        public void BuscarClientePorCpf()
        {
            Console.WriteLine("Informe o CPF do Cliente que você deseja buscar:\nDIGITE APENAS NÚMEROS:");
            var cpfInformado = Console.ReadLine();
            var cpfFormatado = FormataCPF(cpfInformado);


            var clienteSelecionado = new Cliente();
            var cliente = _repositorio.Listar();
            foreach (var c in cliente)
            {
                if(c.Cpf == cpfFormatado)
                {
                    clienteSelecionado = c;

                }

            }

            if(clienteSelecionado.IdentificadorCliente > 0)
            {
                Console.Clear();
                Console.WriteLine($"Nº de registro do Cliente: {clienteSelecionado.IdentificadorCliente}\nNome do Cliente: {clienteSelecionado.NomeCliente}\nCPF: {clienteSelecionado.Cpf}\nData de Nascimento: {clienteSelecionado.DataDeNascimento}");
                Console.WriteLine("===============================");
                Console.WriteLine("\nDigite ENTER para voltar ao menu anterior...");
                Console.ReadLine();
              
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"***ATENÇÃO***\nO CPF {cpfFormatado} não foi encontrado no Sistema!!!\nTente Novamente...\nPressione ENTER para voltar ao menu anterior...");
                Console.ReadLine();
            }

        }

        private string FormataCPF(string cpf)
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

        public void ListarAniversariantesDoMes()
        {            
            var clientesSelecionados = new List<Cliente>();
            var cliente = _repositorio.Listar();
            foreach (var c in cliente)
            {
                var mesNascimento = DateTime.Parse(c.DataDeNascimento);

                if (mesNascimento.Month == DateTime.Now.Month)
                {
                    clientesSelecionados.Add(c);
                }
                
            }

            if (clientesSelecionados.Count > 0)
            {
                Console.WriteLine("***Aniversariantes do Mês***\n");
                foreach (var c in clientesSelecionados)
                {
                    Console.WriteLine($"Nº de registro do Cliente: {c.IdentificadorCliente}\nNome do Cliente: {c.NomeCliente}\nCPF: {c.Cpf}\nData de Nascimento:{c.DataDeNascimento}");
                    Console.WriteLine("===============================");                                     
                }

                Console.WriteLine("\nDigite ENTER para voltar ao menu anterior...");
                Console.ReadLine();
                    
            }
            else
            {   
                Console.Clear();
                Console.WriteLine("Ainda não há aniversariantes no mês Atual");
                Console.WriteLine("\nDigite ENTER para voltar ao menu anterior...");
                Console.ReadLine();
            } 
            
        }

        public void RemoverCliente()
        {
            Console.WriteLine("Por favor forneça o CPF do Cliente para excluir do sistema:");
            var cpfCliente = Console.ReadLine();
            
            string cpfConvertido = FormataCPF(cpfCliente);
            

            if (!_repositorio.SeExiste(cpfConvertido))
            {
                Console.Clear();
                Console.WriteLine("***ATENÇÃO***\nEste CPF não existe no sistema... Tente novamente...\nPressione ENTER para voltar ao menu anterior...");
                Console.ReadLine();
            }
            else          
            {
                _repositorio.RemoverPorCpf(cpfConvertido);
                Console.Clear();
                Console.WriteLine("***Cliente excluido com sucesso***\nPressione ENTER para voltar ao menu anterior...");
                Console.ReadLine();
            }

            return;
        }


    }
}
    