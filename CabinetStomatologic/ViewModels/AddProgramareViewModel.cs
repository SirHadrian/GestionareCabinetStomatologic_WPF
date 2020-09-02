using CabinetStomatologic.Commands;
using CabinetStomatologic.Models;
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
    class AddProgramareViewModel: BaseViewModel
    {
        SqlDataAdapter sda;
        //SqlCommandBuilder scb;
        DataTable dt;

        int ID;

        public AddProgramareViewModel()
        {
            StartDate = DateTime.Now;
        }

        #region Prorieties
        //===============
        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
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

        private DataTable _interventiiDataTable;
        public DataTable InterventiiDataTable
        {
            get { return _interventiiDataTable; }
            set
            {
                _interventiiDataTable = value;
                OnPropertyChanged("InterventiiDataTable");
            }
        }

        private string _idPacient = null;
        public string ID_Pacient
        {
            get
            {
                return _idPacient;
            }
            set
            {
                _idPacient = value;
                OnPropertyChanged("ID_Pacient");
            }
        }

        private string _idInterventie = null;
        public string ID_Interventie
        {
            get
            {
                return _idInterventie;
            }
            set
            {
                _idInterventie = value;
                OnPropertyChanged("ID_Interventie");
            }
        }
        //================
        #endregion


        #region Commands
        //==============
        public void AddProgramare(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(regularConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("AddProgramari", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@date", StartDate);
                        cmd.Parameters.AddWithValue("@medic", Props.CurentUser);
                        cmd.Parameters.AddWithValue("@id_pacient", ID_Pacient);
                        cmd.Parameters.AddWithValue("@id_interventie", ID_Interventie);


                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("Incorect values");
                Debug.WriteLine(e);
                return;
            }
            System.Windows.MessageBox.Show("Programare added!", "AddProgramare", MessageBoxButton.OK, MessageBoxImage.Information);

            //Debug.WriteLine("Executat");
        }

        private ICommand _addProgramare;
        public ICommand AddProgramareCommand
        {
            get
            {
                if (_addProgramare == null)
                    _addProgramare = new RelayCommand(AddProgramare);
                return _addProgramare;
            }
        }


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

        public void LoadInterventii(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;

            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = "SELECT ID, Interventie, Pret FROM Interventii WHERE Activ = 1;";

            sda = new SqlDataAdapter(querry, con);
            dt = new DataTable();
            sda.Fill(dt);

            InterventiiDataTable = dt;
        }

        private ICommand _loadInterventii;
        public ICommand LoadInterventiiCommand
        {
            get
            {
                if (_loadInterventii == null)
                    _loadInterventii = new RelayCommand(LoadInterventii);
                return _loadInterventii;
            }
        }
        //==============
        #endregion
    }
}
