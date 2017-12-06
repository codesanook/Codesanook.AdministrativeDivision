using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using CodeSanook.AdministrativeDivision.Models;
using Orchard.Data;
using Flurl;
using System.IO;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Orchard;
using Orchard.Environment.Configuration;
using System.Linq;
using System.Web.Hosting;
using System.Reflection;

namespace CodeSanook.AdministrativeDivision
{
    public class Migrations : DataMigrationImpl
    {
        private readonly ITransactionManager transactionManager;
        private readonly IOrchardServices orchardService;
        private readonly IShellSettingsManager shellSettingsManager;

        public Migrations(
            ITransactionManager transactionManager,
            IOrchardServices orchardService,
            IShellSettingsManager shellSettingsManager)
        {
            this.transactionManager = transactionManager;
            this.orchardService = orchardService;
            this.shellSettingsManager = shellSettingsManager;
        }

        public int Create()
        {

            SchemaBuilder.CreateTable(typeof(ProvinceRecord).Name, table =>
                table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<int>("Code")
                    .Column<string>("NameInThai")
                    .Column<string>("NameInEnglish")
            );

            SchemaBuilder.CreateTable(typeof(DistrictRecord).Name, table =>
                table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<int>("Code")
                    .Column<string>("NameInThai")
                    .Column<string>("NameInEnglish")
                    .Column<int>("ProvinceRecord_Id")
            );

            SchemaBuilder.CreateTable(typeof(SubdistrictRecord).Name, table =>
                table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<int>("Code")
                    .Column<string>("NameInThai")
                    .Column<string>("NameInEnglish")
                    .Column<decimal>("Latitude")
                    .Column<decimal>("Longitude")
                    .Column<int>("District_Id")
                    .Column<int>("ZipCode")
            );

            //TODO add indexes and foreign keys

            return 1;
        }

        public int UpdateFrom1()
        {
            //insert administrative division data
            ServerConnection connectionContext = null;
            try
            {
                var connectionString = GetConnectionString();
                var connection = new SqlConnection(connectionString);
                //var session = transactionManager.GetSession();
                //var connection = (SqlConnection)session.Connection;


                var server = new Server(new ServerConnection(connection));
                var script = GetAdminstrativeDivisionDataScript();

                connectionContext = server.ConnectionContext;
                //connectionContext.StatementTimeout = 60;
                connectionContext.BeginTransaction();
                connectionContext.ExecuteNonQuery(script);
                connectionContext.CommitTransaction();
            }
            catch (Exception ex)
            {
                //roll back if insert fail
                if (connectionContext != null && connectionContext.IsOpen)
                {
                    connectionContext.RollBackTransaction();
                }
                //throw exception to handle by default handler  
                throw;
            }

            return 2;
        }

        private string GetConnectionString()
        {
            var settings = shellSettingsManager.LoadSettings();
            var defaultSetting = settings.Where(setting => setting.Name == "Default").Single(); ;
            var connectionString = defaultSetting.DataConnectionString;
            return connectionString;
        }

        private string GetAdminstrativeDivisionDataScript()
        {
            var scriptUrl = Url.Combine(
                "~/Modules",
                this.GetType().Assembly.GetName().Name,
                "Contents",
                "AdministrativeDivisionData.sql");
            var httpContext = orchardService.WorkContext.HttpContext;

            var scriptPath = //httpContext.Request.MapPath(scriptUrl);
            HostingEnvironment.MapPath(scriptUrl);
            return File.ReadAllText(scriptPath);
        }

        private string GetRootPath()
        {
            var codeBaseUrl = Assembly.GetExecutingAssembly().CodeBase;
            var filePathToCodeBase = new Uri(codeBaseUrl).LocalPath;
            var directoryPath = Path.GetDirectoryName(filePathToCodeBase);
            return directoryPath;
        }
    }
}