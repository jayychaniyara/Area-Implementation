using Assesment.DomainModels;
using Assesment.RepositoryContracts;
using Assesment.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.ServiceLayer
{
    public class BrandsService : IBrandsService
    {
        IBrandsRepository brandsRepository;

        public BrandsService(IBrandsRepository brandsRepository)
        {
            this.brandsRepository = brandsRepository;
        }

        public List<Brand> GetBrands()
        {
            List<Brand> brands = brandsRepository.GetBrands();
            return brands;
        }

        public Brand GetBrandByBrandID(long BrandId)
        {
            Brand brand = brandsRepository.GetBrandByBrandID(BrandId);
            return brand;
        }

        public void InsertBrand(Brand brand)
        {
            brandsRepository.InsertBrand(brand);
        }

        public void UpdateBrand(Brand brand)
        {
            brandsRepository.UpdateBrand(brand);
        }

        public void DeleteBrand(long BrandId)
        {
            brandsRepository.DeleteBrand(BrandId);
        }
    }
}
