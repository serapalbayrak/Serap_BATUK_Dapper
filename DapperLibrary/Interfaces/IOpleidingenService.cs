using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperLibrary.Interfaces;

namespace DapperLibrary.Models
{
    public interface IOpleidingenService 
    {
        void DeleteDocent(int docentNr);
        void AddNewDocent(IDocent docent);
        IEnumerable<IDocent> GetDocent();
        IEnumerable<ICampus> GetCampus();
        IEnumerable<IDocent> FindDocent(int docentNr);
    }
}
