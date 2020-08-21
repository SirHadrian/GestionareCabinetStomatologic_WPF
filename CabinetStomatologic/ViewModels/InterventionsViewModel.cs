using CabinetStomatologic.Commands;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CabinetStomatologic.ViewModels
{
    class InterventionsViewModel: BaseViewModel
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;


        #region Properties
        //==============
        private DataTable _interventionsDataTable;
        public DataTable InterventionsDataTable
        {
            get { return _interventionsDataTable; }
            set
            {
                _interventionsDataTable = value;
                OnPropertyChanged("InterventionsDataTable");
            }
        }

        private string _delete = null;
        public string DeleteThis
        {
            get
            {
                return _delete;
            }
            set
            {
                _delete = value;
                OnPropertyChanged("DeleteThis");
            }
        }
        //==============
        #endregion


        #region Commands
        //===================
        public void LoadInterventions(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;


            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = "SELECT ID, Interventie, Pret, Activ FROM Interventii;";

            sda = new SqlDataAdapter(querry, con);
            dt = new DataTable();
            sda.Fill(dt);

            InterventionsDataTable = dt;
        }

        private ICommand _loadInterventions;
        public ICommand LoadInterventionsCommand
        {
            get
            {
                if (_loadInterventions == null)
                    _loadInterventions = new RelayCommand(LoadInterventions);
                return _loadInterventions;
            }
        }


        public void UpdateInterventions(object param)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(InterventionsDataTable);
        }

        private ICommand _updateInterventions;
        public ICommand UpdateInterventionsCommand
        {
            get
            {
                if (_updateInterventions == null)
                    _updateInterventions = new RelayCommand(UpdateInterventions);
                return _updateInterventions;
            }
        }
        //=======================
        #endregion
    }
}
