using CabinetStomatologic.Commands;
using CabinetStomatologic.Models.Actions;
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
    class AddMedicViewModel: BaseViewModel
    {
        private AddMedicActions _operations;
        public AddMedicViewModel()
        {
            _operations = new AddMedicActions(this);
        }

        #region Proprieties
        //==================
        private DataTable _usersDataTable;
        public DataTable UsersDataTable
        {
            get { return _usersDataTable; }
            set
            {
                _usersDataTable = value;
                OnPropertyChanged("UsersDataTable");
            }
        }

        private string _nume;
        public string Nume
        {
            get
            {
                return _nume;
            }
            set
            {
                _nume = value;
                OnPropertyChanged("Nume");
            }
        }

        private string _prenume;
        public string Prenume
        {
            get
            {
                return _prenume;
            }
            set
            {
                _prenume = value;
                OnPropertyChanged("Prenume");
            }
        }

        private string _add = null;
        public string Add
        {
            get
            {
                return _add;
            }
            set
            {
                _add = value;
                OnPropertyChanged("Add");
            }
        }
        //==================
        #endregion


        #region Commands
        //=================
        private ICommand _loadUsers;
        public ICommand LoadUsersCommand
        {
            get
            {
                if (_loadUsers == null)
                {
                    _loadUsers = new RelayCommand(_operations.LoadUsers);
                }
                return _loadUsers;
            }
        }


        private ICommand _addMedic;
        public ICommand AddMedicCommand
        {
            get
            {
                if (_addMedic == null)
                {
                    _addMedic = new RelayCommand(_operations.AddMedic);
                }
                return _addMedic;
            }
        }
        //=================
        #endregion
    }
}
