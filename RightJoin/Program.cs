using Microsoft.Data.Sqlite;
using System;

namespace RightJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlExpression = "SELECT p.Title AS 'Продукты', c.Title AS 'Категории'  FROM Products AS p LEFT JOIN Categories as c on p.CategoryId = c.Id";
            using (var connection = new SqliteConnection("Data Source=../../../test.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            var id = reader.GetValue(0);
                            var name = reader.GetValue(1);

                            Console.WriteLine($"{id} - {name} ");
                        }
                    }
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
