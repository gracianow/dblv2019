using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteDblv.Models
{
    interface IContatoRepositorio : IDisposable
    {
        IEnumerable<ContatoViewModel> GetContatos();
        ContatoViewModel GetContatoPorID(int ContatoId);
        void InserirContato(ContatoViewModel contato);
        void DeletarContato(int contatoId);
        void AtualizaContato(ContatoViewModel contato);
        void Salvar();
    }
}
