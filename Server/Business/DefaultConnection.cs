using BlazorTest.DataAccess;
using System;

namespace BlazorTest.Business
{
    public abstract class DefaultConnection : ConexionBase
    {
        internal override string LlaveDeConexion
            => "User ID=ubfepizettarzi;Password=d37987ce0f30ac7fa4de13845d7d1285b4399ef220edec5cb06058c2262993fd;Host=ec2-3-210-23-22.compute-1.amazonaws.com;Port=5432;Database=d7107j52bsl0qr;Sslmode=Require;TrustServerCertificate=true";

    }
}