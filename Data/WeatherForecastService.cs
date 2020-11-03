using BlazorTest.DataAccess;
using BlazorTest.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Data
{
    public class WeatherForecastService : ConexionBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        internal override string LlaveDeConexion
            => "User ID=ubfepizettarzi;Password=d37987ce0f30ac7fa4de13845d7d1285b4399ef220edec5cb06058c2262993fd;Host=ec2-3-210-23-22.compute-1.amazonaws.com;Port=5432;Database=d7107j52bsl0qr;Sslmode=Require;TrustServerCertificate=true";

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public async Task<int> AgregarStorage()
        {
            var affectedRows = await Query<Storage>("INSERT INTO Storage (Id, LastUpdate, PartialQuantity) Values (@Id, @LastUpdate, @PartialQuantity);",
                new
                {
                    Id = "12",
                    LastUpdate = DateTime.Now,
                    PartialQuantity = 23
                }
            );

            return affectedRows.Count;
        }

        public async Task<List<Storage>> TestConnection()
        {
            return await Query<Storage>("select * from Storage");

        }
    }
}
