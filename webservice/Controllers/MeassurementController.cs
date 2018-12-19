using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webservice.Model;

namespace webservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeassurementController : ControllerBase
    {
        // MySQL connection string.
        // private const string connection = "server=192.168.122.105; uid=root; pwd=password; database=MeassurementDB";

        // MSSQL connection string.
        private const string connection = "Server=tcp:mock3db.database.windows.net,1433;Initial Catalog=mockdb;" +
        "Persist Security Info=False;User ID=sebastian;Password=P@ssw0rd;" +
        "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Meassurement
        [HttpGet]
        public List<Meassurement> Get()
        {
            var result = new List<Meassurement>();
            var sql = "SELECT * FROM Meassurement";
            // var db = new MySqlConnection(connection);
            var db = new SqlConnection(connection);
            db.Open();

            // var command = new MySqlCommand(sql, db);
            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Meassurement(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                }
            }
            db.Dispose();
            return result;
        }

        // GET: api/Meassurements/1
        [HttpGet("{id}")]
        public Meassurement Get(int id)
        {
            Meassurement result = null;
            var sql = $"SELECT * FROM Meassurement WHERE id = '{id}'";
            // var db = new MySqlConnection(connection);
            var db = new SqlConnection(connection);
            db.Open();

            // var command = new MySqlCommand(sql, db);
            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Meassurement(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                }
            }
            db.Dispose();
            return result;
        }

        // POST api/Meassurements
        [HttpPost]
        public int InsertMeassurement(Meassurement Meassurement)
        {
            var sql = "INSERT INTO dbo.Meassurement (Pressure, Humidity, Temperature, [TimeStamp])" +
            $"VALUES ('{Meassurement.Pressure}', '{Meassurement.Humidity}', '{Meassurement.Temperature}', '{Meassurement.TimeStamp}')";
            // var db = new MySqlConnection(connection);
            var db = new SqlConnection(connection);
            db.Open();

            // var command = new MySqlCommand(sql, db);
            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();
            db.Dispose();
            return reader.RecordsAffected;
        }

        // PUT api/Meassurements/5
        [HttpPut("{id}")]
        public int UpdateMeassurement(int id, [FromBody] Meassurement Meassurement)
        {
            var sql = $"UPDATE Meassurement SET Pressure = '{Meassurement.Pressure}', " +
            $"Humidity = '{Meassurement.Humidity}', Temperature = '{Meassurement.Temperature}'" +
            $"TimeStamp = '{Meassurement.TimeStamp}' WHERE id='{id}'";
            // var db = new MySqlConnection(connection);
            var db = new SqlConnection(connection);
            db.Open();

            // var command = new MySqlCommand(sql, db);
            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();
            db.Dispose();
            return reader.RecordsAffected;
        }

        // DELETE api/Meassurements/5
        [HttpDelete("{id}")]
        public int DeleteMeassurement(int id)
        {
            var sql = $"DELETE FROM Meassurement WHERE id='{id}'";
            // var db = new MySqlConnection(connection);
            var db = new SqlConnection(connection);

            db.Open();

            // var command = new MySqlCommand(sql, db);
            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();
            db.Dispose();
            return reader.RecordsAffected;
        }
    }
}
