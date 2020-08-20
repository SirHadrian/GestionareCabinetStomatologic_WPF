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
    class AddMedicViewModel: BaseViewModel
    {
        SqlDataAdapter sda;
        //SqlCommandBuilder scb;
        DataTable dt;


        #region Proprieties
        //==================
        private DataTable _usersDataTable;
        public DataTable UsersDataTable
        {
            get { return _usersDataTable; }
            set
            {
                _usersDataTable = value;
                OnPropertyChanged("UsersDataTable");
            }
        }

        private string _nume;
        public string Nume
        {
            get
            {
                return _nume;
            }
            set
            {
                _nume = value;
                OnPropertyChanged("Nume");
            }
        }

        private string _prenume;
        public string Prenume
        {
            get
            {
                return _prenume;
            }
            set
            {
                _prenume = value;
                OnPropertyChanged("Prenume");
            }
        }

        private string _add = null;
        public string Add
        {
            get
            {
                return _add;
            }
            set
            {
                _add = value;
                OnPropertyChanged("Add");
            }
        }
        //==================
        #endregion


        #region Commands
        //=================
        public void LoadUsers(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;


            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = "SELECT ID, UserName, Email FROM Users WHERE Medic = 1";

            sda = new SqlDataAdapter(querry, con);
            dt = new DataTable();
            sda.Fill(dt);

            UsersDataTable = dt;
        }

        private ICommand _loadUsers;
        public ICommand LoadUsersCommand
        {
            get
            {
                if (_loadUsers == null)
                    _loadUsers = new RelayCommand(LoadUsers);
                return _loadUsers;
            }
        }


        public void AddMedic(object param)
        {
            if (Add == null) 
            {
                MessageBox.Show("Insert an ID");
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
                    using (SqlCommand cmd = new SqlCommand("AddMedic", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nume", Nume);
                        cmd.Parameters.AddWithValue("@prenume", Prenume);
                        cmd.Parameters.AddWithValue("@id_user", Add);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Insert a correct value");
                return;
            }
            MessageBox.Show("Medic Added Succesfully", "AddMedic", MessageBoxButton.OK, MessageBoxImage.Information);
            Debug.WriteLine("Executat");
        }

        private ICommand _addMedic;
        public ICommand AddMedicCommand
        {
            get
            {
                if (_addMedic == null)
                    _addMedic = new RelayCommand(AddMedic);
                return _addMedic;
            }
        }
        //=================
        #endregion
    }
}
