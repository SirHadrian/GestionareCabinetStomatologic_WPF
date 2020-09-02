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
    class InterventionsActions
    {
        private SqlDataAdapter _sda;
        private SqlCommandBuilder _scb;
        private DataTable _dt;


        private InterventionsViewModel _interventionsViewModel;
        public InterventionsActions(InterventionsViewModel _interventionsViewModel)
        {
            this._interventionsViewModel = _interventionsViewModel;
        }

        public void LoadInterventions(object param)
        {
            //InterventionsViewModel interventionsViewModelParam = param as InterventionsViewModel;


            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;


            SqlConnection con = new SqlConnection(regularConnectionString);
            string querry = "SELECT ID, Interventie, Pret, Activ FROM Interventii;";

            _sda = new SqlDataAdapter(querry, con);
            _dt = new DataTable();
            _sda.Fill(_dt);

            _interventionsViewModel.InterventionsDataTable = _dt;
        }


        public void UpdateInterventions(object param)
        {
            //InterventionsViewModel interventionsViewModelParam = param as InterventionsViewModel;

            _scb = new SqlCommandBuilder(_sda);
            _sda.Update(_interventionsViewModel.InterventionsDataTable);
        }
    }
}
