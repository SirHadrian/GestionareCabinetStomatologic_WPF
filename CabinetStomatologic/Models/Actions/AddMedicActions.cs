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
    class AddMedicActions
    {
        private SqlDataAdapter _sda;
        //private SqlCommandBuilder _scb;
        private DataTable _dt;


        private AddMedicViewModel _addMedicViewModel;
        public AddMedicActions(AddMedicViewModel _addMedicViewModel)
        {
            this._addMedicViewModel = _addMedicViewModel;
        }


        public void LoadUsers(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;


            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = "SELECT ID, UserName, Email FROM Users WHERE Medic = 1";

            _sda = new SqlDataAdapter(querry, con);
            _dt = new DataTable();
            _sda.Fill(_dt);

            _addMedicViewModel.UsersDataTable = _dt;
        }


        public void AddMedic(object param)
        {
            if (_addMedicViewModel.Add == null)
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

                        cmd.Parameters.AddWithValue("@nume", _addMedicViewModel.Nume);
                        cmd.Parameters.AddWithValue("@prenume", _addMedicViewModel.Prenume);
                        cmd.Parameters.AddWithValue("@id_user", _addMedicViewModel.Add);

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
            //Debug.WriteLine("Executat");
        }
    }
}
