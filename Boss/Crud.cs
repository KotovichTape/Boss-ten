using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss
{
    internal interface Crud
    {
        public void Create();
        public void Read();
        public void Update();
        public void Delete();
    }

    internal interface Cruds : Crud
    {
        public void Search(string str);
    }

}
