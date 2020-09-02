using CabinetStomatologic.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetStomatologic.Models.Actions
{
    class ProgramariActions
    {
        private SqlDataAdapter _sda;
        //private SqlCommandBuilder _scb;
        private DataTable _dt;


        private ProgramariViewModel _programariViewModel;
        public ProgramariActions(ProgramariViewModel _programariViewModel)
        {
            this._programariViewModel = _programariViewModel;
        }


        public void LoadProgramari(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;

            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = @"SELECT 
                            Programari.ID AS ID, 
                            Programari.DataProgramarii AS DataProgramarii, 
                            Medici.Nume AS Nume, 
                            Medici.Prenume AS Prenume, 
                            Interventii.Interventie AS Interventie, 
                            Interventii.Pret AS Pret

                            FROM Programari

                            INNER JOIN Medici ON Medici.ID = ID_Medic
                            INNER JOIN Pacienti ON Pacienti.ID = ID_Pacient
                            INNER JOIN Interventii ON Interventii.ID = ID_Interventie;";

            _sda = new SqlDataAdapter(querry, con);
            _dt = new DataTable();
            _sda.Fill(_dt);

            _programariViewModel.ProgramariDataTable = _dt;
        }
    }
}
