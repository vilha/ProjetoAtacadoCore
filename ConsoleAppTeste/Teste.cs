using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.SERV.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste
{
    public class Teste
    {
        public void Executar()
        {
            AtacadoContext contexto = new AtacadoContext();
            CategoriaService servico = new CategoriaService(contexto);
            List<CategoriaPoco> lista = servico.ObterTodos().ToList();


            foreach (var item in lista)
            {
                Console.WriteLine("CategoriaID: {0}", item.CategoriaID);
                Console.WriteLine("Descricao: {0}", item.Descricao);
                Console.WriteLine("Data Inclusao: {0}", item.Descricao);
                Console.WriteLine("---------------------------------------");

            }

            Console.ReadLine();
        }
           
    }
}
