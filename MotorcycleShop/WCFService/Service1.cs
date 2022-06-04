using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private BrandManagementService brandService = new BrandManagementService();
        private MotorcycleManagementService motorcycleService = new MotorcycleManagementService();
        private SaleManagementService saleService = new SaleManagementService();
        public int CurrentId = 0;
        public string DeleteBrand(int id)
        {
            if (!brandService.Delete(id))
            {
                return "Brand is not deleted!";
            }
            else
            {
                return "Brand is deleted!";
            }
        }

        public string DeleteMotorcycle(int id)
        {
            if (!motorcycleService.Delete(id))
            {
                return "Motorcycle is not deleted!";
            }
            else
            {
                return "Motorcycle is deleted!";
            }
        }

        public string DeleteSale(int id)
        {
            if (!saleService.Delete(id))
            {
                return "Sale is not deleted!";
            }
            else
            {
                return "Sale is deleted!";
            }
        }

        public BrandDTO GetBrandByID(int id)
        {
            return brandService.GetById(id);
        }

        public List<BrandDTO> GetBrands(string filter)
        {
            return brandService.Get(filter);
        }

        public MotorcycleDTO GetMotorcycleByID(int id)
        {
            return motorcycleService.GetById(id);
        }

        public List<MotorcycleDTO> GetMotorcycles(string filter)
        {
            return motorcycleService.Get(filter);
        }
        public int GetCurrentId()
        {
            return CurrentId;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public SaleDTO GetSaleByID(int id)
        {
            return saleService.GetById(id);
        }

        public List<SaleDTO> GetSales(string filter)
        {
            return saleService.Get(filter);
        }

        public string PostBrand(BrandDTO brandDto)
        {
            if (!brandService.Save(brandDto))
                return "Brand is not inserted";

            return "Brand is inserted";
        }

        public string PostMotorcycle(MotorcycleDTO motorcycleDto)
        {
            if (!motorcycleService.Save(motorcycleDto))
                return "Motorcycle is not inserted";

            return "Motorcycle is inserted";
        }


        public string PostSale(SaleDTO saleDto)
        {
            if (!saleService.Save(saleDto))
                return "Sale is not inserted";

            return "Sale is inserted";
        }

        public string PutBrand(BrandDTO brandDto)
        {
            throw new NotImplementedException();
        }

        public string PutMotorcycle(MotorcycleDTO motorcycleDto)
        {
            throw new NotImplementedException();
        }

        public string PutSale(SaleDTO saleDto)
        {
            throw new NotImplementedException();
        }
        public void SetCurrentId(int value)
        {
            CurrentId = value;
        }
    }
}
