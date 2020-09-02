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
    class PacientiViewModel: BaseViewModel
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        //int ID;

        #region Proprieties
        //==================
        private string _pacientiLabel = "Pacientii medicului " + Props.CurentUser;
        public string PacientiLabel
        {
            get
            {
                return _pacientiLabel;
            }
        }

        private DataTable _pacientiDataTable;
        public DataTable PacientiDataTable
        {
            get { return _pacientiDataTable; }
            set
            {
                _pacientiDataTable = value;
                OnPropertyChanged("PacientiDataTable");
            }
        }
        //==================
        #endregion

        #region Commands
        //==============
        public void LoadPacienti(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;


            SqlConnection con = new SqlConnection(regularConnectionString);
            con.Open();
            using (var cmd = new SqlCommand("getPacienti", con))
            {
                dt = new DataTable();
                using (sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@curentuser", Props.CurentUser);
                    sda.Fill(dt);
                    PacientiDataTable = dt;
                }
            }
            con.Close();
        }

        private ICommand _loadPacienti;
        public ICommand LoadPacientiCommand
        {
            get
            {
                if (_loadPacienti == null)
                    _loadPacienti = new RelayCommand(LoadPacienti);
                return _loadPacienti;
            }
        }


        public void UpdatePacienti(object param)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(PacientiDataTable);
        }

        private ICommand _updatePacienti;
        public ICommand UpdatePacientiCommand
        {
            get
            {
                if (_updatePacienti == null)
                    _updatePacienti = new RelayCommand(UpdatePacienti);
                return _updatePacienti;
            }
        }
        //==============
        #endregion
    }
}
