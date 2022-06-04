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
    public class MotorcycleManagementService
    {
        private MotorcycleShopDb ctx = new MotorcycleShopDb();

        public List<MotorcycleDTO> Get(string filter)
        {
            List<MotorcycleDTO> motorcycleDto = new List<MotorcycleDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.MotorcycleRepository.Get(x => x.Color.Contains(filter)))
                {
                    motorcycleDto.Add(new MotorcycleDTO
                    {
                        Id = item.Id,
                        Model = item.Model,
                        Condition = item.Condition,
                        Color = item.Color,
                        Power = item.Power,
                        Price = item.Price,
                        ManifactureDate = item.ManifactureDate,
                        Details = item.Details,
                        AddedBy = item.AddedBy,
                        BrandId = item.BrandID,
                        Brand = new BrandDTO
                        {
                            Id = item.Brand.Id,
                            BrandName = item.Brand.BrandName,
                            CountryOfOrigin = item.Brand.CountryOfOrigin,
                            FoundedIn = item.Brand.FoundedIn,
                            AddedOn = item.Brand.AddedOn,
                            AddedFrom = item.Brand.AddedFrom,
                            LowestModelPrice = item.Brand.LowestModelPrice
                        }
                    });
                }
            }


            return motorcycleDto;
        }

        public MotorcycleDTO GetById(int id)
        {
            MotorcycleDTO motorcycleDto = new MotorcycleDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Motorcycle motorcycle = unitOfWork.MotorcycleRepository.GetByID(id);
                motorcycleDto = new MotorcycleDTO
                {
                    Id = motorcycle.Id,
                    Model = motorcycle.Model,
                    Condition = motorcycle.Condition,
                    Color = motorcycle.Color,
                    Power = motorcycle.Power,
                    Price = motorcycle.Price,
                    ManifactureDate = motorcycle.ManifactureDate,
                    Details = motorcycle.Details,
                    AddedBy = motorcycle.AddedBy,
                    BrandId = motorcycle.BrandID,
                    Brand = new BrandDTO
                    {
                        Id = motorcycle.BrandID,
                        BrandName = motorcycle.Brand.BrandName,
                        CountryOfOrigin = motorcycle.Brand.CountryOfOrigin,
                        FoundedIn = motorcycle.Brand.FoundedIn,
                        AddedOn = motorcycle.Brand.AddedOn,
                        AddedFrom = motorcycle.Brand.AddedFrom,
                        LowestModelPrice = motorcycle.Brand.LowestModelPrice
                    }
                };
            }


            return motorcycleDto;
        }

        public bool Save(MotorcycleDTO motorcycleDto)
        {
            Brand brand = new Brand
            {
                Id = motorcycleDto.Brand.Id,
                BrandName = motorcycleDto.Brand.BrandName,
                CountryOfOrigin = motorcycleDto.Brand.CountryOfOrigin,
                FoundedIn = motorcycleDto.Brand.FoundedIn,
                AddedOn = motorcycleDto.Brand.AddedOn,
                AddedFrom = motorcycleDto.Brand.AddedFrom,
                LowestModelPrice = motorcycleDto.Brand.LowestModelPrice
            };
            Motorcycle motorcycle = new Motorcycle
            {
                Id = motorcycleDto.Id,
                Model = motorcycleDto.Model,
                Condition = motorcycleDto.Condition,
                Color = motorcycleDto.Color,
                Power = motorcycleDto.Power,
                Price = motorcycleDto.Price,
                ManifactureDate = motorcycleDto.ManifactureDate,
                Details = motorcycleDto.Details,
                AddedBy = motorcycleDto.AddedBy,
                BrandID = brand.Id
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (motorcycleDto.Id == 0)
                    {
                        unitOfWork.MotorcycleRepository.Insert(motorcycle);
                    }
                    else
                    {
                        unitOfWork.MotorcycleRepository.Update(motorcycle);
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
                    Motorcycle motorcycle = unitOfWork.MotorcycleRepository.GetByID(id);
                    unitOfWork.MotorcycleRepository.Delete(motorcycle);

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