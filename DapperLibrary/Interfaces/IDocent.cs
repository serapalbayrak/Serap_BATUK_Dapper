using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperLibrary.Interfaces;

namespace DapperLibrary.Interfaces
{
    public interface IDocent
    {
        int DocentNr { get; set; }
        string Voornaam { get; set; }
        string Familienaam { get; set; }
        decimal Wedde { get; set; }
        int CampusNr { get; set; }
    }
}
