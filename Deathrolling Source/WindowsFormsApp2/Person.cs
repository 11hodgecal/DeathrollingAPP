using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Person
    {
        string name;
        int rolled;

        public string PName
        {
            get { return name; }
            set { name = value; }
        }
        public int Proll
        {
            get { return rolled; }
            set { rolled = value; }
        }

        public Person(string name)
        {
            this.name = name;
        }

        public void pname(string newid)
        {
            this.name = newid;
        }
    }
}
