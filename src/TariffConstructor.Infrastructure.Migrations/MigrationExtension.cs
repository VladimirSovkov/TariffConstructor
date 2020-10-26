using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace TariffConstructor.Infrastructure.Migrations
{
    public static class MigrationExtension
    {
        public static void AppendDataSql( this MigrationBuilder migrationBuilder, string sqlDataFileName )
        {
            IConfiguration config = GetConfig();
            string environment = config[ "ASPNETCORE_ENVIRONMENT" ];
            string dataPath = config[ "Transistor_Migrations_Data_Path" ] ?? "../../data/sql/";
            string dataEnvironment = environment.ToUpperInvariant() == "PROD" ? "PROD_RUSSIA" : "QA_RUSSIA";

            migrationBuilder.AppendSql( "COMMON_RUSSIA", dataPath, sqlDataFileName );
            migrationBuilder.AppendSql( dataEnvironment, dataPath, sqlDataFileName );
        }

        private static void AppendSql(
            this MigrationBuilder migrationBuilder,
            string dataEnvironment,
            string dataPath,
            string sqlDataFileName )
        {
            if ( File.Exists( $"{dataPath}/{dataEnvironment}/{sqlDataFileName}.sql" ) )
            {
                using ( StreamReader sr = new StreamReader( $"{dataPath}/{dataEnvironment}/{sqlDataFileName}.sql" ) )
                {
                    var sql = sr.ReadToEnd();
                    migrationBuilder.Sql( sql );
                }
            }
        }

        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" )
                .AddJsonFile( $"appsettings.{Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" )}.json",
                    true )
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
