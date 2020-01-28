using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using _07_Fiap.Web.AspNet.Models;
using _07_Fiap.Web.AspNet.Persistences;

namespace _07_Fiap.Web.AspNet.Repositories
{
    public class CelaRepository : ICelaRepository
    {
        private PresidioContext _context;

        public CelaRepository(PresidioContext context)
        {
            _context = context;
        }

        public void Atualizar(Cela cela)
        {
            _context.Celas.Update(cela);
        }

        public IList<Cela> BuscarPor(Expression<Func<Cela, bool>> filtro)
        {
            return _context.Celas.Where(filtro).ToList();
        }

        public Cela BuscarPorCodigo(int codigo)
        {
            return _context.Celas.Find(codigo);
        }

        public void Cadastrar(Cela cela)
        {
            _context.Celas.Add(cela);
        }

        public IList<Cela> Listar()
        {
            return _context.Celas.ToList();
        }

        public void Remover(int codigo)
        {
            var cela = _context.Celas.Find(codigo);
            _context.Celas.Remove(cela);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
