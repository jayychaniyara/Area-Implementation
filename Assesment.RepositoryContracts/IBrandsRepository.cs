using Assesment.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.RepositoryContracts
{
    public interface IBrandsRepository
    {
        List<Brand> GetBrands();

        Brand GetBrandByBrandID(long BrandId);

        void InsertBrand(Brand brand);

        void UpdateBrand(Brand brand);

        void DeleteBrand(long BrandId);
    }
}
