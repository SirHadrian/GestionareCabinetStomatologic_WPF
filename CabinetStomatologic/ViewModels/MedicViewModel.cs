using CabinetStomatologic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CabinetStomatologic.ViewModels
{
    class MedicViewModel: BaseViewModel
    {
        #region Visibility User Type
        //========================
        private string _curentUser = Props.CurentUser;
        public string CurentUser
        {
            get
            {
                return _curentUser;
            }
            set
            {
                _curentUser = value;
                OnPropertyChanged("CurentUser");
            }
        }


        private Visibility _adminBtn = Props.AdminBtn;
        public Visibility AdminBtn
        {
            get
            {
                return _adminBtn;
            }
            set
            {
                _adminBtn = value;
                OnPropertyChanged("AdminBtn");
            }
        }


        public Visibility _medicBtn = Props.MedicBtn;
        public Visibility MedicBtn
        {
            get
            {
                return _medicBtn;
            }
            set
            {
                _medicBtn = value;
                OnPropertyChanged("MedicBtn");
            }
        }
        //============================
        #endregion
    }
}
