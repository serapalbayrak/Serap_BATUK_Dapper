using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using DapperLibrary.Interfaces;

namespace DapperLibrary.Models
{
    public class OpleidingenService : IOpleidingenService
    {
        public void DeleteDocent(int docentNr)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@DocentNr", docentNr);
            using (IDbConnection connection = new SqlConnection(OpleindingenManager.GetConnection("OPLEIDINGEN")))
            {
                try
                {
                    connection.Execute("spDeleteDocent", param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void AddNewDocent(IDocent docent)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Voornaam", docent.Voornaam);
            param.Add("@Familienaam", docent.Familienaam);
            param.Add("@Wedde", docent.Wedde);
            param.Add("@CampusNr", docent.CampusNr);

            using (IDbConnection connection = new SqlConnection(OpleindingenManager.GetConnection("OPLEIDINGEN")))
            {
                try
                {
                    connection.Execute("spAddNewDocent", param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public IEnumerable<IDocent> GetDocent()
        {
            using (IDbConnection connection = new SqlConnection(OpleindingenManager.GetConnection("OPLEIDINGEN")))
            {
                var docent = connection.Query<Docent>("spGetAllDocenten", commandType: CommandType.StoredProcedure).ToList();
                return docent;
            }
        }
        public IEnumerable<ICampus> GetCampus()
        {
            using (IDbConnection connection = new SqlConnection(OpleindingenManager.GetConnection("OPLEIDINGEN")))
            {
                var campus = connection.Query<Campus>("spGetAllCampussen", commandType: CommandType.StoredProcedure).ToList();
                return campus;
            }
        }
        public IEnumerable<IDocent>FindDocent(int docentNr)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@DocentNr", docentNr);
            using (IDbConnection connection = new SqlConnection(OpleindingenManager.GetConnection("OPLEIDINGEN")))
            {
                var docent = connection.Query<Docent>("spFindDocent", param, commandType: CommandType.StoredProcedure).ToList();
                return docent;
            }
        }
    }
}


 
