using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class SaleManagementService
    {
        private MotorcycleShopDb ctx = new MotorcycleShopDb();

        public List<SaleDTO> Get(string filter)
        {
            List<SaleDTO> salesDto = new List<SaleDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.SaleRepository.Get(x => x.ClientFirstName.Contains(filter)))
                {
                    salesDto.Add(new SaleDTO
                    {
                        Id = item.Id,
                        ClientFirstName = item.ClientFirstName,
                        ClientLastName = item.ClientLastName,
                        SellerName = item.SellerName,
                        SaleDate = item.SaleDate,
                        SalePrice = item.SalePrice,
                        Motorcycle = new MotorcycleDTO
                        {
                            Id = item.Motorcycle.Id,
                            Model = item.Motorcycle.Model,
                            Condition = item.Motorcycle.Condition,
                            Color = item.Motorcycle.Color,
                            Power = item.Motorcycle.Power,
                            Price = item.Motorcycle.Price,
                            ManifactureDate = item.Motorcycle.ManifactureDate,
                            Details = item.Motorcycle.Details,
                            AddedBy = item.Motorcycle.AddedBy
                        }
                    });
                }
            }


            return salesDto;
        }

        public SaleDTO GetById(int id)
        {
            SaleDTO saleDto = new SaleDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Sale sale = unitOfWork.SaleRepository.GetByID(id);
                saleDto = new SaleDTO
                {
                    Id = sale.Id,
                    ClientFirstName = sale.ClientFirstName,
                    ClientLastName = sale.ClientLastName,
                    SellerName = sale.SellerName,
                    SaleDate = sale.SaleDate,
                    SalePrice = sale.SalePrice,
                    MotorcycleId = sale.MotorcycleID,
                    Motorcycle = new MotorcycleDTO
                    {
                        Id = sale.MotorcycleID,
                        Model = sale.Motorcycle.Model,
                        Condition = sale.Motorcycle.Condition,
                        Color = sale.Motorcycle.Color,
                        Power = sale.Motorcycle.Power,
                        Price = sale.Motorcycle.Price,
                        ManifactureDate = sale.Motorcycle.ManifactureDate,
                        Details = sale.Motorcycle.Details,
                        AddedBy = sale.Motorcycle.AddedBy
                    }
                };
            }


            return saleDto;
        }

        public bool Save(SaleDTO saleDto)
        {
            if (saleDto.Motorcycle == null || saleDto.Motorcycle.Id == 0)
            {
                return false;
            }

            Motorcycle motorcycle = new Motorcycle
            {
                Id = saleDto.Motorcycle.Id,
                Model = saleDto.Motorcycle.Model,
                Condition = saleDto.Motorcycle.Condition,
                Color = saleDto.Motorcycle.Color,
                Power = saleDto.Motorcycle.Power,
                Price = saleDto.Motorcycle.Price,
                ManifactureDate = saleDto.Motorcycle.ManifactureDate,
                Details = saleDto.Motorcycle.Details,
                AddedBy = saleDto.Motorcycle.AddedBy
            };

            Sale sale = new Sale
            {
                Id = saleDto.Id,
                ClientFirstName = saleDto.ClientFirstName,
                ClientLastName = saleDto.ClientLastName,
                SellerName = saleDto.SellerName,
                SaleDate = saleDto.SaleDate,
                SalePrice = saleDto.SalePrice,
                MotorcycleID = saleDto.Motorcycle.Id
            };


            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (saleDto.Id == 0)
                    {
                        unitOfWork.SaleRepository.Insert(sale);
                    }
                    else
                    {
                        unitOfWork.SaleRepository.Update(sale);
                    }
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Sale sale = unitOfWork.SaleRepository.GetByID(id);
                    unitOfWork.SaleRepository.Delete(sale);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}