using CabinetStomatologic.Commands;
using CabinetStomatologic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CabinetStomatologic.ViewModels
{
    class ProgramariViewModel: BaseViewModel
    {
        SqlDataAdapter sda;
        //SqlCommandBuilder scb;
        DataTable dt;


        #region Proprieties
        //========================
        private string _welcome = "Programarile medicului " + Props.CurentUser;
        public string Welcome
        {
            get
            {
                return _welcome;
            }
        }

        private DataTable _programariDataTable;
        public DataTable ProgramariDataTable
        {
            get { return _programariDataTable; }
            set
            {
                _programariDataTable = value;
                OnPropertyChanged("ProgramariDataTable");
            }
        }
        //======================
        #endregion


        #region Commands
        //=============
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

            sda = new SqlDataAdapter(querry, con);
            dt = new DataTable();
            sda.Fill(dt);

            ProgramariDataTable = dt;
        }

        private ICommand _loadProgramari;
        public ICommand LoadProgramariCommand
        {
            get
            {
                if (_loadProgramari == null)
                    _loadProgramari = new RelayCommand(LoadProgramari);
                return _loadProgramari;
            }
        }
        //=============
        #endregion
    }
}
