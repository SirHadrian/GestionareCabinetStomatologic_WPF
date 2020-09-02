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
    class CreateAccountActions
    {
        //private SqlDataAdapter _sda;
        //private SqlCommandBuilder _scb;
        //private DataTable _dt;


        private CreateAccountViewModel _createAccountViewModel;
        public CreateAccountActions(CreateAccountViewModel _createAccountViewModel)
        {
            this._createAccountViewModel = _createAccountViewModel;
        }


        public void CreateAccount(object param)
        {
            CreateAccountViewModel _createAccountViewModelParam = param as CreateAccountViewModel;

            if (_createAccountViewModelParam.UserName == null || _createAccountViewModelParam.EmailAdress == null 
                || _createAccountViewModelParam.Password_1 == null ||
                _createAccountViewModelParam.Password_2 == null)
            {
                MessageBox.Show("All fields must be completed!");
                return;
            }

            if (!Tools.IsValidEmail(_createAccountViewModelParam.EmailAdress))
            {
                MessageBox.Show("Email invalid");
                return;
            }

            if (_createAccountViewModelParam.Password_1 != _createAccountViewModelParam.Password_2)
            {
                MessageBox.Show("Passwords don't match");
                return;
            }

            //=============
            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;

            using (SqlConnection con = new SqlConnection(regularConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("isUserNameAndEmail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@username", _createAccountViewModelParam.UserName);
                    cmd.Parameters.AddWithValue("@email", _createAccountViewModelParam.EmailAdress);

                    int status = Convert.ToInt32(cmd.ExecuteScalar());

                    if (status == 1)
                    {
                        MessageBox.Show("UserName or Email already registered");
                        return;
                    }
                    else
                    {
                        using (SqlCommand cmd2 = new SqlCommand("NewUser", con))
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@username", _createAccountViewModelParam.UserName);
                            cmd2.Parameters.AddWithValue("@email", _createAccountViewModelParam.EmailAdress);
                            cmd2.Parameters.AddWithValue("@password", _createAccountViewModelParam.Password_1);
                            cmd2.Parameters.AddWithValue("@medic", 0);
                            cmd2.Parameters.AddWithValue("@admin", 0);

                            cmd2.ExecuteNonQuery();
                        }
                    }
                }
                con.Close();
            }
            //================
            MessageBox.Show("Account created successfully");
            var win = Application.Current.MainWindow;
            win.DataContext = new LoginViewModel();
        }


        public void BackBTN(object param)
        {
            var win = Application.Current.MainWindow;
            win.DataContext = new LoginViewModel();
        }
    }
}
