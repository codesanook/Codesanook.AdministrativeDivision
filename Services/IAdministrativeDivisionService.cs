using CodeSanook.AdministrativeDivision.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSanook.AdministrativeDivision.Services
{
    public interface IAdministrativeDivisionService : IDependency
    {
        ProvinceRecord GetPronviceById(int provinceId);
        DistrictRecord GetDistrictById(int districtId);
        SubdistrictRecord GetSubdistrictById(int subdistrictId);
    }
}