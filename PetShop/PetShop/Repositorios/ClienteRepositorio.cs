using PetShop.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositorios
{
    internal class ClienteRepositorio
    {
        private readonly string _caminhoBase = "C:\\Users\\NayaraCosta\\Desktop\\Desafio_Pet_Shop\\PetShop\\PetShop\\Arquivo\\Cliente.csv";
        private List<Cliente> ListagemClientes = new List<Cliente>();
        public ClienteRepositorio()
        {
            if (!File.Exists(_caminhoBase))
            {
                var file = File.Create(_caminhoBase);
                file.Close();
            }
        }

        public void Inserir(Cliente Cliente)
        {
            var identificador = ProximoIdentificador();

            var sw = new StreamWriter(_caminhoBase, true);
            sw.WriteLine(GerarLinhaCliente(identificador, Cliente));
            sw.Close();
        }
        public List<Cliente> Listar()
        {
            CarregarClientes();
            return ListagemClientes;
        }
        public bool SeExiste(int identificadorCliente)
        {
            CarregarClientes();
            return ListagemClientes.Any(x => x.IdentificadorCliente == identificadorCliente);

            //foreach (var x in ListagemClientes)
            //{
            //    if(x.IdentificadorCliente == identificadorCliente)
            //        return true;
            //}

            //return false;
        }
        public void Atualizar(Cliente Cliente)
        {
            CarregarClientes();

            var posicao = ListagemClientes.FindIndex(x => x.IdentificadorCliente == Cliente.IdentificadorCliente);
            ListagemClientes[posicao] = Cliente;
            RegravarClientes(ListagemClientes);
        }
        public void Remover(int identificadorCliente)
        {
            CarregarClientes();
            var posicao = ListagemClientes.FindIndex(x => x.IdentificadorCliente == identificadorCliente);
            ListagemClientes.RemoveAt(posicao);
            RegravarClientes(ListagemClientes);
        }

        #region Metodos privados
        private Cliente LinhaTextoParaCliente(string linha)
        {
            var colunas = linha.Split(';');

            var Cliente = new Cliente();
            Cliente.IdentificadorCliente = int.Parse(colunas[0]);
            Cliente.NomeCliente = colunas[1];
            Cliente.Cpf = colunas[2];
            Cliente.DataDeNascimento = colunas[3];

            return Cliente;
        }
        private void CarregarClientes()
        {
            ListagemClientes.Clear();
            var sr = new StreamReader(_caminhoBase);
            while (true)
            {
                var linha = sr.ReadLine();

                if (linha == null)
                    break;

                ListagemClientes.Add(LinhaTextoParaCliente(linha));
            }

            sr.Close();
        }
        private int ProximoIdentificador()
        {
            CarregarClientes();

            if (ListagemClientes.Count == 0)
                return 1;

            return ListagemClientes.Max(x => x.IdentificadorCliente) + 1;
        }
        private void RegravarClientes(List<Cliente> Clientes)
        {
            var sw = new StreamWriter(_caminhoBase);

            foreach (var Cliente in Clientes.OrderBy(x => x.IdentificadorCliente))
            {
                sw.WriteLine(GerarLinhaCliente(Cliente.IdentificadorCliente, Cliente));
            }

            sw.Close();
        }
        private string GerarLinhaCliente(int identificador, Cliente Cliente)
        {
            return $"{identificador};{Cliente.NomeCliente};{Cliente.Cpf};{Cliente.DataDeNascimento}";
        }
        #endregion
    }
}
