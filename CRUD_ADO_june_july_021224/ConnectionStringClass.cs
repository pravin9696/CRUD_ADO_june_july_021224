using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADO_june_july_021224
{
    public static class ConnectionStringClass
    {
        public static string getConString()
        {
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Acer\\source\\repos\\CRUD_ADO_june_july_021224\\CRUD_ADO_june_july_021224\\DB\\StudDB.mdf;Integrated Security=True";
        }
    }
}
