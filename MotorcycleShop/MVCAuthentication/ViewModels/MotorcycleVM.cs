using ApplicationService.DTOs;
using MVCAuthentication.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentication.ViewModels
{
    
    public class MotorcycleVM
    {
     
        public int Id { get; set; }
        [DisplayName("Brand Name")]
        public int BrandId { get; set; }

        public BrandVM BrandVM { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Model name can't be that long.")]
        [DisplayName("Model")]
        public string Model { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Condition")]
        public string Condition { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Color")]
        public string Color { get; set; }

        [Required]
        [DisplayName("Power")]
        [Range(70, 2000,
            ErrorMessage = "Power must be between 70 and 2000")]
        public int Power { get; set; }

        [Required]
        [DisplayName("Price")]
        [Range(5000, 5000000,
            ErrorMessage = "Price must be between 5000 and 5000000")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Manifacture date")]
        public DateTime ManifactureDate { get; set; }

        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Details")]
        public string Details { get; set; }


        [StringLength(50, ErrorMessage = "This field can't be that long.")]
        [DisplayName("Added by")]
        public string AddedBy { get; set; }

       

        public MotorcycleVM() { }

        public MotorcycleVM(MotorcycleDTO motorcycleDto)
        {
            Id = motorcycleDto.Id;
            Model = motorcycleDto.Model;
            Condition = motorcycleDto.Condition;
            Color = motorcycleDto.Color;
            Power = motorcycleDto.Power;
            Price = motorcycleDto.Price;
            ManifactureDate = motorcycleDto.ManifactureDate;
            Details = motorcycleDto.Details;
            AddedBy = motorcycleDto.AddedBy;
            BrandId = motorcycleDto.BrandId;
            BrandVM = new BrandVM
            {
                Id = motorcycleDto.BrandId,
                BrandName = motorcycleDto.Brand.BrandName,
                CountryOfOrigin = motorcycleDto.Brand.CountryOfOrigin,
                FoundedIn = motorcycleDto.Brand.FoundedIn,
                AddedOn = motorcycleDto.Brand.AddedOn,
                AddedFrom = motorcycleDto.Brand.AddedFrom,
                LowestModelPrice = motorcycleDto.Brand.LowestModelPrice

            };
        }
    }
}