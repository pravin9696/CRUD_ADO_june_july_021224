

using Microsoft.Data.SqlClient;
using System.Data;
namespace CRUD_ADO_june_july_021224
{
    class Student_CRUD
    {
        public void selectStudents()
        {
            // 1
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Acer\\source\\repos\\CRUD_ADO_june_july_021224\\CRUD_ADO_june_july_021224\\DB\\StudDB.mdf;Integrated Security=True";
            con.Open();

             //2
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tblstudent";
            cmd.CommandType = CommandType.Text;

            //3
           SqlDataReader rdr= cmd.ExecuteReader();
            Console.WriteLine("roll\t Name\t Total Marks");
            while(rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}\t{rdr[1]}\t{rdr[2]}");
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student_CRUD sc = new Student_CRUD();
            sc.selectStudents();
        }
    }
}
