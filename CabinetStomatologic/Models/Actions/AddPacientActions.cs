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
    class AddPacientActions
    {
        //private SqlDataAdapter _sda;
        //private SqlCommandBuilder _scb;
        //private DataTable _dt;


        private AddPacientViewModel _addPacientViewModel;
        public AddPacientActions(AddPacientViewModel _addPacientViewModel)
        {
            this._addPacientViewModel = _addPacientViewModel;
        }


        public void Add(object param)
        {
            AddPacientViewModel _addPacientViewModelParam = param as AddPacientViewModel;

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

                        cmd.Parameters.AddWithValue("@nume", _addPacientViewModelParam.Nume);
                        cmd.Parameters.AddWithValue("@prenume", _addPacientViewModelParam.Prenume);
                        cmd.Parameters.AddWithValue("@medic", Props.CurentUser);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong");
                Debug.WriteLine(e);
                return;
            }

            System.Windows.MessageBox.Show("Pacient Added!", "AddPacient", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
