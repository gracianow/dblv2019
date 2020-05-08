using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteDblv.Models
{
    interface IContatoRepositorio : IDisposable
    {
        IEnumerable<Contato> GetContatos();
        Contato GetContatoPorID(int ContatoId);
        void InserirContato(Contato contato);
        void DeletarContato(int contatoId);
        void AtualizaContato(Contato contato);
        void Salvar();
    }
}
