using CabinetStomatologic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetStomatologic.ViewModels
{
    class ProgramariViewModel: BaseViewModel
    {
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
        //======================
        #endregion
    }
}
