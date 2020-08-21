using CabinetStomatologic.Commands;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CabinetStomatologic.ViewModels
{
    class MediciViewModel: BaseViewModel
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;


        #region Proprieties
        //==================
        private DataTable _mediciDataTable;
        public DataTable MediciDataTable
        {
            get { return _mediciDataTable; }
            set
            {
                _mediciDataTable = value;
                OnPropertyChanged("MediciDataTable");
            }
        }

        private string _deleteThis = null;
        public string DeleteThis
        {
            get
            {
                return _deleteThis;
            }
            set
            {
                _deleteThis = value;
                OnPropertyChanged("DeleteThis");
            }
        }
        //==================
        #endregion

        #region Commands
        //==============
        public void LoadMedici(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;


            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = "SELECT ID, Nume, Prenume FROM Medici";

            sda = new SqlDataAdapter(querry, con);
            dt = new DataTable();
            sda.Fill(dt);

            MediciDataTable = dt;
        }

        private ICommand _loadMedici;
        public ICommand LoadMediciCommand
        {
            get
            {
                if (_loadMedici == null)
                    _loadMedici = new RelayCommand(LoadMedici);
                return _loadMedici;
            }
        }


        public void UpdateMedici(object param)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(MediciDataTable);
        }

        private ICommand _updateMedici;
        public ICommand UpdateMediciCommand
        {
            get
            {
                if (_updateMedici == null)
                    _updateMedici = new RelayCommand(UpdateMedici);
                return _updateMedici;
            }
        }

        public void DeleteMedic(object param)
        {
            if(DeleteThis == null)
            {
                MessageBox.Show("Insert a value");
                return;
            }

            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(regularConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("delMedic", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", DeleteThis);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("Exception --> " + e);
                MessageBox.Show("Incorrect value");
                return;
            }

            MessageBox.Show("Medic Deleted!");
        }

        private ICommand _deleteMedic;
        public ICommand DeleteMedicCommand
        {
            get
            {
                if (_deleteMedic == null)
                    _deleteMedic = new RelayCommand(DeleteMedic);
                return _deleteMedic;
            }
        }
        //==============
        #endregion
    }
}
