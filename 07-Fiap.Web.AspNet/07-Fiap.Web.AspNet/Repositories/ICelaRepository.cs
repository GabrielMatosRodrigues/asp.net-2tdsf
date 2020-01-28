using _07_Fiap.Web.AspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _07_Fiap.Web.AspNet.Repositories
{
    public interface ICelaRepository
    {
        void Cadastrar(Cela cela);
        void Atualizar(Cela cela);
        void Remover(int codigo);
        IList<Cela> Listar();
        Cela BuscarPorCodigo(int codigo);
        IList<Cela> BuscarPor(Expression<Func<Cela, bool>> filtro);
        void Salvar();
    }
}
