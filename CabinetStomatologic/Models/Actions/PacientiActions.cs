using CabinetStomatologic.ViewModels;
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

namespace CabinetStomatologic.Models.Actions
{
    class PacientiActions
    {
        private SqlDataAdapter _sda;
        //private SqlCommandBuilder _scb;
        private DataTable _dt;


        private PacientiViewModel _pacientiViewModel;
        public PacientiActions(PacientiViewModel _pacientiViewModel)
        {
            this._pacientiViewModel = _pacientiViewModel;
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
                    _pacientiViewModel.PacientiDataTable = _dt;
                }
            }
            con.Close();
        }


        public void DeletePacienti(object param)
        {
            if (_pacientiViewModel.ID == null)
            {
                System.Windows.MessageBox.Show("Insert the ID", "Pacienti", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    using (SqlCommand cmd = new SqlCommand("delPacient", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", _pacientiViewModel.ID);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Cannot delete, wrong ID");
                return;
            }

            _pacientiViewModel.ID = null;
            System.Windows.MessageBox.Show("Pacient Deleted!", "Pacienti", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
