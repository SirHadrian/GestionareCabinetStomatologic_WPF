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
using System.Windows;
using System.Windows.Input;

namespace CabinetStomatologic.ViewModels
{
    class AddPacientViewModel: BaseViewModel
    {
        

        #region Proprieties
        //==================
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
        //===============
        #endregion


        #region Commands
        //=================
        public void Add(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(regularConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("AddPacient", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nume", Nume);
                        cmd.Parameters.AddWithValue("@prenume", Prenume);
                        cmd.Parameters.AddWithValue("@medic", Props.CurentUser);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }

            System.Windows.MessageBox.Show("Pacient Added!", "AddPacient", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private ICommand _addPacient;
        public ICommand AddPacientCommand
        {
            get
            {
                if (_addPacient == null)
                    _addPacient = new RelayCommand(Add);
                return _addPacient;
            }
        }
        //=====================
        #endregion
    }
}
