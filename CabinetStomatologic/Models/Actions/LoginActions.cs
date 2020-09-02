using CabinetStomatologic.ViewModels;
using CabinetStomatologic.Views;
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
    class LoginActions
    {
        private LoginViewModel _loginViewModel;
        public LoginActions(LoginViewModel _loginViewModel)
        {
            this._loginViewModel = _loginViewModel;
        }


        public void Join(object param)
        {
            LoginViewModel _loginViewModelParam = param as LoginViewModel;

            _loginViewModelParam.LoginLabel = Visibility.Collapsed;
            _loginViewModelParam.UserNameLabel = Visibility.Collapsed;
            _loginViewModelParam.UserNameBox = Visibility.Collapsed;
            _loginViewModelParam.PasswordLabel = Visibility.Collapsed;
            _loginViewModelParam.PasswordBox = Visibility.Collapsed;
            _loginViewModelParam.BtnJoin = Visibility.Collapsed;
            _loginViewModelParam.BtnLogin = Visibility.Collapsed;
            _loginViewModelParam.Spacer = Visibility.Collapsed;


            _loginViewModelParam.JoinLabel = Visibility.Visible;
            _loginViewModelParam.BtnBack = Visibility.Visible;
            _loginViewModelParam.BtnCreateAccount = Visibility.Visible;
            _loginViewModelParam.BtnGuest = Visibility.Visible;
        }


        public void Back(object param)
        {
            LoginViewModel _loginViewModelParam = param as LoginViewModel;

            _loginViewModelParam.LoginLabel = Visibility.Visible;
            _loginViewModelParam.UserNameLabel = Visibility.Visible;
            _loginViewModelParam.UserNameBox = Visibility.Visible;
            _loginViewModelParam.PasswordLabel = Visibility.Visible;
            _loginViewModelParam.PasswordBox = Visibility.Visible;
            _loginViewModelParam.BtnJoin = Visibility.Visible;
            _loginViewModelParam.BtnLogin = Visibility.Visible;
            _loginViewModelParam.Spacer = Visibility.Visible;


            _loginViewModelParam.JoinLabel = Visibility.Hidden;
            _loginViewModelParam.BtnBack = Visibility.Hidden;
            _loginViewModelParam.BtnCreateAccount = Visibility.Hidden;
            _loginViewModelParam.BtnGuest = Visibility.Hidden;
        }


        public void Login(object param)
        {
            LoginViewModel _loginViewModelParam = param as LoginViewModel;

            if (_loginViewModelParam.UserName == null || _loginViewModelParam.Password == null)
            {
                MessageBox.Show("UserName or Password missing!");
                return;
            }

            string conectionStringEF = ConfigurationManager.ConnectionStrings["CabinetStomatologicEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(conectionStringEF);
            var regularConnectionString = builder.ProviderConnectionString;


            using (SqlConnection con = new SqlConnection(regularConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("isAdmin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", _loginViewModelParam.UserName);


                    int status = Convert.ToInt32(cmd.ExecuteScalar());

                    if (status == 1)
                    {
                        Props.AdminBtn = Visibility.Visible;
                        Props.MedicBtn = Visibility.Collapsed;
                    }
                    else
                    {
                        Props.AdminBtn = Visibility.Collapsed;
                        Debug.WriteLine("Not Admin");
                    }
                }


                using (SqlCommand cmd = new SqlCommand("Login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", _loginViewModelParam.UserName);
                    cmd.Parameters.AddWithValue("@Password", _loginViewModelParam.Password);

                    int status = Convert.ToInt32(cmd.ExecuteScalar());

                    if (status == 1)
                    {
                        Props.CurentUser = _loginViewModelParam.UserName;

                        Main main = new Main();
                        main.Show();

                        var win = Application.Current.MainWindow;
                        win.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!");
                    }
                }
                con.Close();
            }
        }


        public void CreateAccountB(object param)
        {
            var win = Application.Current.MainWindow;
            win.DataContext = new CreateAccountViewModel();
        }
    }
}
