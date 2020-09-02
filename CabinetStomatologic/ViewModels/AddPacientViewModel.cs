using CabinetStomatologic.Commands;
using CabinetStomatologic.Models;
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
    class AddPacientViewModel: BaseViewModel
    {
        private AddPacientActions _operations;
        public AddPacientViewModel()
        {
            _operations = new AddPacientActions(this);
        }
        

        #region Proprieties
        //==================
        private DataTable _pacientiDataTable;
        public DataTable PacientiDataTable
        {
            get { return _pacientiDataTable; }
            set
            {
                _pacientiDataTable = value;
                OnPropertyChanged("PacientiDataTable");
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
        //===============
        #endregion


        #region Commands
        //=================
        private ICommand _addPacient;
        public ICommand AddPacientCommand
        {
            get
            {
                if (_addPacient == null)
                {
                    _addPacient = new RelayCommand(_operations.Add);
                }
                return _addPacient;
            }
        }
        //=====================
        #endregion
    }
}
