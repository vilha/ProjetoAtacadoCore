using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.SERV.Ancestral
{
    public interface IService<T>
        where T : class
    {
        T Incluir(T poco);

        T Obter(int id);

        IEnumerable<T> ObterTodos();

        T Atualizar(T poco);

        T Excluir(int id);
    }
}
