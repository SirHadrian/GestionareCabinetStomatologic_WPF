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
    class AddProgramareViewModel: BaseViewModel
    {
        private AddProgramareActions _operations;

        public AddProgramareViewModel()
        {
            StartDate = DateTime.Now;
            _operations = new AddProgramareActions(this);
        }

        #region Prorieties
        //===============
        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

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

        private DataTable _interventiiDataTable;
        public DataTable InterventiiDataTable
        {
            get { return _interventiiDataTable; }
            set
            {
                _interventiiDataTable = value;
                OnPropertyChanged("InterventiiDataTable");
            }
        }

        private string _idPacient = null;
        public string ID_Pacient
        {
            get
            {
                return _idPacient;
            }
            set
            {
                _idPacient = value;
                OnPropertyChanged("ID_Pacient");
            }
        }

        private string _idInterventie = null;
        public string ID_Interventie
        {
            get
            {
                return _idInterventie;
            }
            set
            {
                _idInterventie = value;
                OnPropertyChanged("ID_Interventie");
            }
        }
        //================
        #endregion


        #region Commands
        //==============
        private ICommand _addProgramare;
        public ICommand AddProgramareCommand
        {
            get
            {
                if (_addProgramare == null)
                {
                    _addProgramare = new RelayCommand(_operations.AddProgramare);
                }
                return _addProgramare;
            }
        }


        private ICommand _loadPacienti;
        public ICommand LoadPacientiCommand
        {
            get
            {
                if (_loadPacienti == null)
                {
                    _loadPacienti = new RelayCommand(_operations.LoadPacienti);
                }
                return _loadPacienti;
            }
        }


        private ICommand _loadInterventii;
        public ICommand LoadInterventiiCommand
        {
            get
            {
                if (_loadInterventii == null)
                {
                    _loadInterventii = new RelayCommand(_operations.LoadInterventii);
                }
                return _loadInterventii;
            }
        }
        //==============
        #endregion
    }
}
