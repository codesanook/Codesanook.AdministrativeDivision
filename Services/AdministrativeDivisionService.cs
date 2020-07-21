using Codesanook.AdministrativeDivision.Models;
using Orchard.Data;

namespace Codesanook.AdministrativeDivision.Services {
    public class AdministrativeDivisionService : IAdministrativeDivisionService {
        private readonly IRepository<ProvinceRecord> provinceRepository;
        private readonly IRepository<DistrictRecord> districtRepository;
        private readonly IRepository<SubdistrictRecord> subdistrictRepository;

        public AdministrativeDivisionService(
            IRepository<ProvinceRecord> provinceRepository,
            IRepository<DistrictRecord> districtRepository,
            IRepository<SubdistrictRecord> subdistrictRepository
        ) {
            this.provinceRepository = provinceRepository;
            this.districtRepository = districtRepository;
            this.subdistrictRepository = subdistrictRepository;
        }

        public ProvinceRecord GetPronviceById(int provinceId) => provinceRepository.Get(provinceId);
        public DistrictRecord GetDistrictById(int districtId) => districtRepository.Get(districtId);
        public SubdistrictRecord GetSubdistrictById(int subdistrictId) => subdistrictRepository.Get(subdistrictId);
    }
}