using Assesment.DataLayer;
using Assesment.DomainModels;
using Assesment.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.RepositoryLayer
{
    public class BrandsRepository : IBrandsRepository
    {
        CompanyDbContext dbContext = new CompanyDbContext();

        public List<Brand> GetBrands()
        {
            List<Brand> brands = dbContext.Brands.ToList();
            return brands;
        }

        public Brand GetBrandByBrandID(long BrandId)
        {
            Brand brand = dbContext.Brands.Where(temp => temp.BrandId == BrandId).FirstOrDefault();
            return brand;
        }

        public void InsertBrand(Brand brand)
        {
            dbContext.Brands.Add(brand);
            dbContext.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            Brand existingBrand = dbContext.Brands.Where(temp => temp.BrandId == brand.BrandId).FirstOrDefault();
            existingBrand.BrandId = brand.BrandId;
            existingBrand.BrandName = brand.BrandName;
            dbContext.SaveChanges();
        }

        public void DeleteBrand(long BrandId)
        {
            Brand existingBrand = dbContext.Brands.Where(temp => temp.BrandId == BrandId).FirstOrDefault();
            dbContext.Brands.Remove(existingBrand);
            dbContext.SaveChanges();
        }
    }
}
