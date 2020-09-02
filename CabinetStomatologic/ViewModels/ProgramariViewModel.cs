using CabinetStomatologic.Commands;
using CabinetStomatologic.Models;
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
using System.Windows.Input;

namespace CabinetStomatologic.ViewModels
{
    class ProgramariViewModel: BaseViewModel
    {
        private ProgramariActions _operations;
        public ProgramariViewModel()
        {
            _operations = new ProgramariActions(this);
        }

        #region Proprieties
        //========================
        private string _welcome = "Programarile medicului " + Props.CurentUser;
        public string Welcome
        {
            get
            {
                return _welcome;
            }
        }

        private DataTable _programariDataTable;
        public DataTable ProgramariDataTable
        {
            get { return _programariDataTable; }
            set
            {
                _programariDataTable = value;
                OnPropertyChanged("ProgramariDataTable");
            }
        }
        //======================
        #endregion


        #region Commands
        //=============
        private ICommand _loadProgramari;
        public ICommand LoadProgramariCommand
        {
            get
            {
                if (_loadProgramari == null)
                {
                    _loadProgramari = new RelayCommand(_operations.LoadProgramari);
                }
                return _loadProgramari;
            }
        }
        //=============
        #endregion
    }
}
