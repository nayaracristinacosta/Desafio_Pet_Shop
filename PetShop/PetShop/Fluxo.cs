using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Fluxo
    {
        public void Executar()
        {
            Menu();
        }

        public void Menu()
        {
            bool FimExecucaoMenu = true;

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

                        while (opcaoMenuCliente != 4)
                        {

                            switch (opcaoMenuCliente)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Teste");
                                    break;

                                case 2:
                                    Console.Clear();
                                    break;                              

                                case 3:
                                    Console.Clear();
                                    break;

                                case 4:
                                    //Console.Clear();
                                    opcaoMenuCliente = 4;
                                    //FimExecucaoMenu = false;

                                    break;

                                default:
                                    //Console.Clear();
                                    break;

                            }

                        }
                        break;

                    case 2:

                        Console.Clear();
                        Console.WriteLine("#**************************************#");
                        Console.WriteLine("# #");
                        Console.WriteLine("# --- MENU CURSO --- #");
                        Console.WriteLine("# #");
                        Console.WriteLine("# 1 - Incluir curso #");
                        Console.WriteLine("# 2 - Alterar curso #");
                        Console.WriteLine("# 3 - Pesquisar curso #");
                        Console.WriteLine("# 4 - Excluir curso #");
                        Console.WriteLine("# 5 - Voltar ao menu principal #");
                        Console.WriteLine("# #");
                        Console.WriteLine("#**************************************#");
                        Console.WriteLine();
                        Console.Write("Digite sua opcao: ");

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

            //Console.ReadKey();


        }
    }
    }
    