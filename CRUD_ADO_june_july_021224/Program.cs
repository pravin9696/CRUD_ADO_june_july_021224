

using Microsoft.Data.SqlClient;
using System.Data;
namespace CRUD_ADO_june_july_021224
{
    class Student_CRUD
    {
        public void DeleteStudent()
        {
            Console.WriteLine("Enter roll number to Delete record");
            int roll = int.Parse(Console.ReadLine());
          
            string quryString = $"delete from tblStudent where Roll={roll}";


            SqlConnection con = new SqlConnection(ConnectionStringClass.getConString());
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = quryString;
            cmd.CommandType = CommandType.Text;
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("Record Deleted Successfully...");
            }
            else
            {
                Console.WriteLine("Record not Deleted Or Not found!!!");
            }
            con.Close();
        }
        public void updateStudent()
        {
            Console.WriteLine("Enter roll number , name & total marks of Student to update");
            int roll = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            int tmarks = Convert.ToInt32(Console.ReadLine());
            string quryString = $"update tblStudent set Name='{name}',TotalMarks={tmarks} where Roll={roll}";


            SqlConnection con = new SqlConnection(ConnectionStringClass.getConString());
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = quryString;
            cmd.CommandType = CommandType.Text;
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("Record updated Successfully...");
            }
            else
            {
                Console.WriteLine("Record not updated!!!");
            }
            con.Close();
        }
        public void insertStudent()
        {
            Console.WriteLine("Enter roll number , name & total marks of Student");
            int roll=int.Parse(Console.ReadLine()); 
            string name=Console.ReadLine();
            int tmarks = Convert.ToInt32(Console.ReadLine());
            string quryString = $"insert into tblStudent values({roll},'{name}',{tmarks})";


            SqlConnection con = new SqlConnection(ConnectionStringClass.getConString());           
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = quryString;
            cmd.CommandType = CommandType.Text;
           int n= cmd.ExecuteNonQuery();
            if (n>0)
            {
                Console.WriteLine("Record inserted Successfully...");
            }
            else
            {
                Console.WriteLine("Record not inserted!!!");
            }
            con.Close();
        }
        public void selectStudentByRoll()
        {
            Console.WriteLine("Enter roll number to Search Student");
            int roll = int.Parse(Console.ReadLine());

            string quryString = $"select * from tblstudent where roll={roll}";


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionStringClass.getConString();
            con.Open();

            //2
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = quryString;
            cmd.CommandType = CommandType.Text;

            //3
            SqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("roll\t Name\t Total Marks");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}\t{rdr[1]}\t{rdr[2]}");
            }

        }
        public void selectStudents()
        {
            // 1
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionStringClass.getConString();
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
            int choice;
            do
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine("1: insert record\n2: show all Students\n3:search by roll");
                Console.WriteLine("4:update record\n5:Delete record\n 6:exit");
                Console.WriteLine("=======================================================");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: sc.insertStudent();break;
                    case 2: sc.selectStudents(); break;
                    case 3: sc.selectStudentByRoll(); break;
                    case 4: sc.updateStudent(); break;
                    case 5: sc.DeleteStudent(); break;
                    case 6: Environment.Exit(0);break;
                    default:
                        Console.WriteLine("Enter 1 to 6 choice only!!!!");
                        break;
                }
            }
            while (true);
            

        }
    }
}
