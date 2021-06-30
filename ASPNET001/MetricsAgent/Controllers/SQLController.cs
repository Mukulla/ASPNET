using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.Models;
using MetricsAgent.DAL;

namespace MetricsAgent.Controllers
{
    [Route("api/sql")]
    [ApiController]
    public class SQLController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult TryToSqlLite()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                using var cmd = new SQLiteCommand(stm, con);
                string version = cmd.ExecuteScalar().ToString();
                return Ok(version);
            }
        }

        [HttpGet("read-write-test")]
        public IActionResult TryToInsertAndRead()
        {
            // Создаем строку подключения в виде базы данных в оперативной памяти
            string connectionString = "Data Source=:memory:";
            // создаем соединение с базой данных
            using (var connection = new SQLiteConnection(connectionString))
            {
                // открываем соединение
                connection.Open();
                // создаем объект через который будут выполняться команды к базе данных

                using (var command = new SQLiteCommand(connection))
                {
                    // задаем новый текст команды для выполнения
                    // удаляем таблицу с метриками если она существует в базе данных
                    command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                    // отправляем запрос в базу данных
                    command.ExecuteNonQuery();
                    // создаем таблицу с метриками
                    command.CommandText = @"CREATE TABLE cpumetrics(id INTEGERPRIMARY KEY,value INT, time INT)";
                    command.ExecuteNonQuery();
                    // создаем запрос на вставку данных
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(10, 1)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(50, 2)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(75, 4)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(90, 5)";
                    command.ExecuteNonQuery();

                    // создаем строку для выборки данных из базы
                    // LIMIT 3 обозначает, что мы достанем только 3 записи
                    string readQuery = "SELECT * FROM cpumetrics LIMIT 3";
                    // создаем массив, в который запишем объекты с данными из базы данных
                    List<CpuMetric> returnList = new List<CpuMetric>();
                    // изменяем текст команды на наш запрос чтения
                    command.CommandText = readQuery;
                    // создаем читалку из базы данных
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // цикл будет выполняться до тех пор, пока есть что читать из базы данных
                        while (reader.Read())
                        {
                            // создаем объект и записываем его в массив
                            returnList.Add(new CpuMetric
                            {
                                Id = reader.GetInt32(0),
                                Value = reader.GetInt32(1),
                                // налету преобразуем прочитанные секунды в метку времени
                                Time = DateTimeOffset.Now
                            });
                        }
                    }
                    // оборачиваем массив с данными в объект ответа и возвращаем пользователю
                    return Ok(returnList);
                }
            }
        }
    }
}
