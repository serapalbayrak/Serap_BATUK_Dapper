using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperLibrary.Interfaces;


namespace DapperLibrary.Models
{
    public class Campus:ICampus
    {
        public int CampusNr { get; set; }
        public string Naam { get; set; }
        public override string ToString()
        {
            return $"{Naam}";
        }
    }
}


