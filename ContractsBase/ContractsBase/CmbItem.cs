using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractsBase
{
    public class CmbItem
    {
        private int _Id;
        private string _Name;

        public CmbItem(int valId, string valName)
        {

            this._Id = valId;
            this._Name = valName;
        }

        public int Id
        {
            get
            {
                return _Id;
            }
        }

        public string Name
        {

            get
            {
                return _Name;
            }
        }

    }
}
