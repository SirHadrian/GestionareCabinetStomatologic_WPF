using CabinetStomatologic.Commands;
using CabinetStomatologic.Models.Actions;
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
using System.Windows.Input;

namespace CabinetStomatologic.ViewModels
{
    class InterventionsViewModel: BaseViewModel
    {
        private InterventionsActions _operations;
        public InterventionsViewModel()
        {
            _operations = new InterventionsActions(this);
        }

        #region Properties
        //==============
        private DataTable _interventionsDataTable;
        public DataTable InterventionsDataTable
        {
            get { return _interventionsDataTable; }
            set
            {
                _interventionsDataTable = value;
                OnPropertyChanged("InterventionsDataTable");
            }
        }

        private string _delete = null;
        public string DeleteThis
        {
            get
            {
                return _delete;
            }
            set
            {
                _delete = value;
                OnPropertyChanged("DeleteThis");
            }
        }
        //==============
        #endregion


        #region Commands
        //===================
        private ICommand _loadInterventions;
        public ICommand LoadInterventionsCommand
        {
            get
            {
                if (_loadInterventions == null)
                {
                    _loadInterventions = new RelayCommand(_operations.LoadInterventions);
                }
                return _loadInterventions;
            }
        }


        private ICommand _updateInterventions;
        public ICommand UpdateInterventionsCommand
        {
            get
            {
                if (_updateInterventions == null)
                {
                    _updateInterventions = new RelayCommand(_operations.UpdateInterventions);
                }
                return _updateInterventions;
            }
        }
        //=======================
        #endregion
    }
}
