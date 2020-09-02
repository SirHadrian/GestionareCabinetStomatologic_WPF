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
    class MediciViewModel: BaseViewModel
    {
        private MediciActions _operations;
        public MediciViewModel()
        {
            _operations = new MediciActions(this);
        }


        #region Proprieties
        //==================
        private DataTable _mediciDataTable;
        public DataTable MediciDataTable
        {
            get { return _mediciDataTable; }
            set
            {
                _mediciDataTable = value;
                OnPropertyChanged("MediciDataTable");
            }
        }

        private string _deleteThis = null;
        public string DeleteThis
        {
            get
            {
                return _deleteThis;
            }
            set
            {
                _deleteThis = value;
                OnPropertyChanged("DeleteThis");
            }
        }
        //==================
        #endregion


        #region Commands
        //==============
        private ICommand _loadMedici;
        public ICommand LoadMediciCommand
        {
            get
            {
                if (_loadMedici == null)
                {
                    _loadMedici = new RelayCommand(_operations.LoadMedici);
                }
                return _loadMedici;
            }
        }


        private ICommand _updateMedici;
        public ICommand UpdateMediciCommand
        {
            get
            {
                if (_updateMedici == null)
                {
                    _updateMedici = new RelayCommand(_operations.UpdateMedici);
                }
                return _updateMedici;
            }
        }

        
        private ICommand _deleteMedic;
        public ICommand DeleteMedicCommand
        {
            get
            {
                if (_deleteMedic == null)
                {
                    _deleteMedic = new RelayCommand(_operations.DeleteMedic);
                }
                return _deleteMedic;
            }
        }
        //==============
        #endregion
    }
}
