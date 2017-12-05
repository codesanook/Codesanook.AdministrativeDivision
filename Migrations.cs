using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using CodeSanook.AdministrativeDivision.Models;

namespace CodeSanook.AdministrativeDivision {
    public class Migrations : DataMigrationImpl {

        public int Create() {

            SchemaBuilder.CreateTable(typeof(ProvinceRecord).Name, table =>
                table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Code")
                    .Column<string>("NameInThai")
                    .Column<string>("NameInEnglish")
            );

            SchemaBuilder.CreateTable(typeof(DistrictRecord).Name, table =>
                table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Code")
                    .Column<string>("NameInThai")
                    .Column<string>("NameInEnglish")
                    .Column<int>("ProvinceRecord_Id")
            );

            SchemaBuilder.CreateTable(typeof(SubdistrictRecord).Name, table =>
                table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Code")
                    .Column<string>("NameInThai")
                    .Column<string>("NameInEnglish")
                    .Column<decimal>("Latitude")
                    .Column<decimal>("Longitude")
                    .Column<int>("District_Id")
                    .Column<int>("ZipCode")
            );

            return 1;
        }
    }
}