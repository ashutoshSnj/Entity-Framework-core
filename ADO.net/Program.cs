using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ADO_Net
{
    public class MainAPP
    {
        public static void Main(string[] args)
        {
              Console.WriteLine("Today we Start the ADO.Net");
               using (  MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=#Ashutosh.snj79 ;database=fbs"))
               using (MySqlConnection conn1 = new MySqlConnection("server=localhost;user=root;password=#Ashutosh.snj79 ;database=usermanagment"))
               {
                   conn1.Open();
                   conn.Open();
                   string q = "select * from user where user=@name";
                   MySqlCommand cmd1= new MySqlCommand("Select * from roles", conn1);
                   MySqlDataReader red=cmd1.ExecuteReader();
                   while (red.Read())
                   {
                       Console.WriteLine(red.GetInt32(0)); 
                       Console.WriteLine(red.GetString(1));
                   }
                   using (MySqlCommand cmd = new MySqlCommand(q, conn))
                   {

                       cmd.Parameters.AddWithValue("@name", "ashutosh");
                       using (MySqlDataReader reader = cmd.ExecuteReader())
                       {

                           while (reader.Read())
                           {
                               Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1));
                           }

                        //reader.Close();
                       }

                       MySqlCommand cmdd = new MySqlCommand("update user set password=123 where user=@username", conn);
                       cmdd.Parameters.AddWithValue("@username", "Ashutosh");
                       //  cmd1.ExecuteNonQuery();
                   }
               }

           }
            using (MySqlConnection connection = new MySqlConnection("server=localhost;user=root;password=#Ashutosh.snj79 ;database=fbs"))
            {
                MySqlCommand command = new MySqlCommand("select * from user",connection); 
                MySqlDataAdapter adapter = new MySqlDataAdapter(command); 
                DataSet dataSet = new DataSet(); 

                adapter.Fill(dataSet); 
                DataTable table = dataSet.Tables[0];

                foreach (DataRow row in table.Rows) 
                {
                    Console.WriteLine($"ID: {row["user"]}, Name: {row["password"]}");
                }
            }
        }
    }
}