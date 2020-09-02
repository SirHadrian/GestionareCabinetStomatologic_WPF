using CabinetStomatologic.ViewModels;
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

namespace CabinetStomatologic.Models.Actions
{
    class AddProgramareActions
    {
        private SqlDataAdapter _sda;
        //private SqlCommandBuilder _scb;
        private DataTable _dt;

        private AddProgramareViewModel _addProgramareViewModel;
        public AddProgramareActions(AddProgramareViewModel _addProgramareViewModel)
        {
            this._addProgramareViewModel = _addProgramareViewModel;
        }


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

                        cmd.Parameters.AddWithValue("@date", _addProgramareViewModel.StartDate);
                        cmd.Parameters.AddWithValue("@medic", Props.CurentUser);
                        cmd.Parameters.AddWithValue("@id_pacient", _addProgramareViewModel.ID_Pacient);
                        cmd.Parameters.AddWithValue("@id_interventie", _addProgramareViewModel.ID_Interventie);


                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Incorect values");
                Debug.WriteLine(e);
                return;
            }
            System.Windows.MessageBox.Show("Programare added!", "AddProgramare", MessageBoxButton.OK, MessageBoxImage.Information);

            //Debug.WriteLine("Executat");
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
                _dt = new DataTable();
                using (_sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@curentuser", Props.CurentUser);
                    _sda.Fill(_dt);
                    _addProgramareViewModel.PacientiDataTable = _dt;
                }
            }
            con.Close();
        }


        public void LoadInterventii(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;

            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = "SELECT ID, Interventie, Pret FROM Interventii WHERE Activ = 1;";

            _sda = new SqlDataAdapter(querry, con);
            _dt = new DataTable();
            _sda.Fill(_dt);

            _addProgramareViewModel.InterventiiDataTable = _dt;
        }
    }
}
