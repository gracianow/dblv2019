using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiteDblv.Models
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private ContatoContext _context;

        public ContatoRepositorio(ContatoContext ContatoContext)
        {
            this._context = ContatoContext;
        }

        public IEnumerable<Contato> GetContatos()
        {
            return _context.Contatos.ToList();
        }

        public Contato GetContatoPorID(int id)
        {
            return _context.Contatos.Find(id);
        }

        public void InserirContato(Contato contato)
        {
            _context.Contatos.Add(contato);
        }

        public void DeletarContato(int contatoID)
        {
            Contato Contato = _context.Contatos.Find(contatoID);
            _context.Contatos.Remove(Contato);
        }

        public void AtualizaContato(Contato Contato)
        {
            _context.Entry(Contato).State = EntityState.Modified;
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}