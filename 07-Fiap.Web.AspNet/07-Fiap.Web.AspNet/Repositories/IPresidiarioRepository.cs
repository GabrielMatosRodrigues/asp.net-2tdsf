using _07_Fiap.Web.AspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _07_Fiap.Web.AspNet.Repositories
{
    public interface IPresidiarioRepository
    {
        void Cadastrar(Presidiario presidiario);
        void Atualizar(Presidiario presidiario);
        void Remover(int id);
        IList<Presidiario> Listar();
        Presidiario BuscarPorCodigo(int id);
        IList<Presidiario> BuscarPor(Expression<Func<Presidiario, bool>> filtro);
        void Salvar();
    }
}
