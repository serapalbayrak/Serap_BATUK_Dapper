using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperLibrary.Interfaces;
using DapperLibrary.Interfaces;

namespace DapperLibrary.Interfaces
{
    public interface ICampus
    {
        int CampusNr { get; set; }
        string Naam { get; set; }
    }
}
