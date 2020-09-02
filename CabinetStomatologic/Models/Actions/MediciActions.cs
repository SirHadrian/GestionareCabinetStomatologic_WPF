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
    class MediciActions
    {
        private SqlDataAdapter _sda;
        private SqlCommandBuilder _scb;
        private DataTable _dt;


        private MediciViewModel _mediciViewModel;
        public MediciActions(MediciViewModel _mediciViewModel)
        {
            this._mediciViewModel = _mediciViewModel;
        }


        public void LoadMedici(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;


            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = "SELECT ID, Nume, Prenume FROM Medici";

            _sda = new SqlDataAdapter(querry, con);
            _dt = new DataTable();
            _sda.Fill(_dt);

            _mediciViewModel.MediciDataTable = _dt;
        }


        public void UpdateMedici(object param)
        {
            _scb = new SqlCommandBuilder(_sda);
            _sda.Update(_mediciViewModel.MediciDataTable);
        }


        public void DeleteMedic(object param)
        {
            if (_mediciViewModel.DeleteThis == null)
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

                        cmd.Parameters.AddWithValue("@id", _mediciViewModel.DeleteThis);

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception --> " + e);
                MessageBox.Show("Incorrect value");
                return;
            }

            MessageBox.Show("Medic Deleted!");
        }
    }
}
