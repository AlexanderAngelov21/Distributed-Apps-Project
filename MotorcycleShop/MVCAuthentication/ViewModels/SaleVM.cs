﻿using ApplicationService.DTOs;
using MVCAuthentication.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAuthentication.ViewModels
{
    public class SaleVM
    {


        public int Id { get; set; }
        [DisplayName("Motorcycle")]
        public int MotorcycleId { get; set; }

        public string MotorcycleModel { get; set; }
        public MotorcycleVM MotorcycleVM { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Client's first name can't be that long.")]
        [DisplayName("Client's first name")]
        public string ClientFirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Client's last name can't be that long.")]
        [DisplayName("Client's last name")]
        public string ClientLastName { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Seller's name can't be that long.")]
        [DisplayName("Seller's name")]
        public string SellerName { get; set; }

        [Required]
        [DisplayName("Sale Date")]
        [DataType(DataType.Date)]
        public DateTime? SaleDate { get; set; }

        [Required]
        [Range(5000, 5000000,
        ErrorMessage = "Price must be between 5000 and 5000000")]
        [DisplayName("Sale Price")]
        public decimal SalePrice { get; set; }




        public SaleVM() { }

        public SaleVM(SaleDTO saleDto)
        {
            Id = saleDto.Id;
            ClientFirstName = saleDto.ClientFirstName;
            ClientLastName = saleDto.ClientLastName;
            SellerName = saleDto.SellerName;
            SaleDate = saleDto.SaleDate;
            SalePrice = saleDto.SalePrice;
            MotorcycleId = saleDto.MotorcycleId;
            MotorcycleVM = new MotorcycleVM
            {
                Id = saleDto.MotorcycleId,
                Model = saleDto.Motorcycle.Model,
                Condition = saleDto.Motorcycle.Condition,
                Color = saleDto.Motorcycle.Color,
                Power = saleDto.Motorcycle.Power,
                Price = saleDto.Motorcycle.Price,
                ManifactureDate = saleDto.Motorcycle.ManifactureDate,
                Details = saleDto.Motorcycle.Details,
                AddedBy = saleDto.Motorcycle.AddedBy,

            };
            MotorcycleModel = saleDto.Motorcycle.Model;
        }
    }
}