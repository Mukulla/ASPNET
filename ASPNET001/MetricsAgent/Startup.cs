using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.DAL;
using System.Data.SQLite;

namespace MetricsAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureSqlLiteConnection(services);
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            const string connectionString = "DataSource = metrics.db; Version = 3; Pooling = true; Max Pool Size = 100; ";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                // задаем новый текст команды для выполнения
                // удаляем таблицу с метриками если она существует в базе данных
                command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                // отправляем запрос в базу данных
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARYKEY, value INT, time INT)";
                command.ExecuteNonQuery();

                command.CommandText = "DROP TABLE IF EXISTS dotnetmetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE dotnetmetrics(id INTEGER PRIMARYKEY, value INT, time INT)";
                command.ExecuteNonQuery();
                
                command.CommandText = "DROP TABLE IF EXISTS hddmetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE hddmetrics(id INTEGER PRIMARYKEY, value INT, time INT)";
                command.ExecuteNonQuery();

                command.CommandText = "DROP TABLE IF EXISTS networkmetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE networkmetrics(id INTEGER PRIMARYKEY, value INT, time INT)";
                command.ExecuteNonQuery();

                command.CommandText = "DROP TABLE IF EXISTS rammetrics";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE rammetrics(id INTEGER PRIMARYKEY, value INT, time INT)";
                command.ExecuteNonQuery();

                //cpumetrics
                command.CommandText = "INSERT INTO cpumetrics(id, value, time)VALUES(1, 10, 1)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO cpumetrics(id, value, time)VALUES(2, 12, 13)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO cpumetrics(id, value, time)VALUES(3, 21, 34)";
                command.ExecuteNonQuery();

                //dotnetmetrics
                command.CommandText = "INSERT INTO dotnetmetrics(id, value, time)VALUES(1, 34, 3)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(id, value, time)VALUES(2, 27, 4)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO dotnetmetrics(id, value, time)VALUES(3, 19, 8)";
                command.ExecuteNonQuery();

                //hddmetrics
                command.CommandText = "INSERT INTO hddmetrics(id, value, time)VALUES(1, 37, 82)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO hddmetrics(id, value, time)VALUES(2, 63, 67)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO hddmetrics(id, value, time)VALUES(3, 91, 35)";
                command.ExecuteNonQuery();

                //networkmetrics
                command.CommandText = "INSERT INTO networkmetrics(id, value, time)VALUES(1, 48, 56)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(id, value, time)VALUES(2, 95, 76)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO networkmetrics(id, value, time)VALUES(3, 45, 87)";
                command.ExecuteNonQuery();

                //rammetrics
                command.CommandText = "INSERT INTO rammetrics(id, value, time)VALUES(1, 15, 7)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO rammetrics(id, value, time)VALUES(2, 17, 9)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO rammetrics(id, value, time)VALUES(3, 18, 11)";
                command.ExecuteNonQuery();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
