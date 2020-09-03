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

namespace CabinetStomatologic.Models.Actions
{
    class ProgramariActions
    {
        private SqlDataAdapter _sda;
        //private SqlCommandBuilder _scb;
        private DataTable _dt;


        private ProgramariViewModel _programariViewModel;
        public ProgramariActions(ProgramariViewModel _programariViewModel)
        {
            this._programariViewModel = _programariViewModel;
        }


        public void LoadProgramari(object param)
        {
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;

            SqlConnection con = new SqlConnection(regularConnectionString);
            con.Open();
            using (var cmd = new SqlCommand("getProgramari", con))
            {
                _dt = new DataTable();
                using (_sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    _sda.Fill(_dt);
                    _programariViewModel.ProgramariDataTable = _dt;
                }
            }
            con.Close();
        }
    }
}
