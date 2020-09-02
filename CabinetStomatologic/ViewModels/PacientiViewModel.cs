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
    class PacientiViewModel: BaseViewModel
    {
        private PacientiActions _operations;
        public PacientiViewModel()
        {
            _operations = new PacientiActions(this);
        }


        #region Proprieties
        //==================
        private string _pacientiLabel = "Pacientii medicului " + Props.CurentUser;
        public string PacientiLabel
        {
            get
            {
                return _pacientiLabel;
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
        //==================
        #endregion


        #region Commands
        //==============
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


        private ICommand _updatePacienti;
        public ICommand UpdatePacientiCommand
        {
            get
            {
                if (_updatePacienti == null)
                {
                    _updatePacienti = new RelayCommand(_operations.UpdatePacienti);
                }
                return _updatePacienti;
            }
        }
        //==============
        #endregion
    }
}
