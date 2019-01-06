using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finals_Project
{
    [Serializable]
    public class DictItem
    {
        private List<DictData> dWords;
        public List<DictData> DWords
        {
            get { return dWords;  }
            set { dWords = value; }
        }
    }
}
