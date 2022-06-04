using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCAuthentication.Controllers;
using MVCAuthentication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WCFService;

namespace UnitTestMVC
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BrandVM brandVM = new BrandVM();
            BrandDTO brandDto = new BrandDTO
            {
                Id = brandVM.Id,
                BrandName = brandVM.BrandName,
                CountryOfOrigin = brandVM.CountryOfOrigin,
                FoundedIn = brandVM.FoundedIn,
                AddedOn = brandVM.AddedOn,
                AddedFrom = brandVM.AddedFrom,
                LowestModelPrice = brandVM.LowestModelPrice
            };
            BrandManagementService brandService = new BrandManagementService();
            var service = new Service1();
            var result = service.PostBrand(brandDto);
            if (!brandService.Save(brandDto))
            {
                Assert.AreEqual("Brand is not inserted",result);
            }
            else
            {
                Assert.AreEqual("Brand is inserted", result);
            }
                
        }
        [TestMethod]
        public void TestMethod2()
        {
            MotorcycleVM motorcycleVM = new MotorcycleVM();
            MotorcycleDTO motorcycleDto = new MotorcycleDTO
            {
                BrandId = motorcycleVM.BrandId,
                Model = motorcycleVM.Model,
                Condition = motorcycleVM.Condition,
                Color = motorcycleVM.Color,
                Power = motorcycleVM.Power,
                Price = motorcycleVM.Price,
                ManifactureDate = motorcycleVM.ManifactureDate,
                Details = motorcycleVM.Details,
                AddedBy = motorcycleVM.AddedBy,
                Brand = new BrandDTO
                {
                    Id = motorcycleVM.BrandId
                }
            };
            MotorcycleManagementService motorcycleService = new MotorcycleManagementService();
            var service = new Service1();
            var result = service.PostMotorcycle(motorcycleDto);
            if (!motorcycleService.Save(motorcycleDto))
            {
                Assert.AreEqual("Motorcycle is not inserted", result);
            }
            else
            {
                Assert.AreEqual("Motorcycle is inserted", result);
            }

        }
        [TestMethod]
        public void TestMethod3()
        {
            SaleVM saleVM = new SaleVM();
            SaleDTO saleDto = new SaleDTO
            {
                MotorcycleId = saleVM.MotorcycleId,
                ClientFirstName = saleVM.ClientFirstName,
                ClientLastName = saleVM.ClientLastName,
                SellerName = saleVM.SellerName,
                SaleDate = saleVM.SaleDate,
                SalePrice = saleVM.SalePrice,

                Motorcycle = new MotorcycleDTO
                {
                    Id = saleVM.MotorcycleId

                }
            };
            SaleManagementService saleService = new SaleManagementService();
            var service = new Service1();
            var result = service.PostSale(saleDto);
            if (!saleService.Save(saleDto))
            {
                Assert.AreEqual("Sale is not inserted", result);
            }
            else
            {
                Assert.AreEqual("Sale is inserted", result);
            }

        }
        [TestMethod]
        public void TestMethod4()
        {
           
            BrandManagementService brandService = new BrandManagementService();
            var service = new Service1();
            int id = 5;
            var result = service.DeleteBrand(id);
            if (!brandService.Delete(id))
            {
                Assert.AreEqual("Brand is not deleted!", result);
            }
            else
            {
                Assert.AreEqual("Brand is deleted!", result);
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            var service = new Service1();
            int value = 5;
            var result = service.GetData(value);

            Assert.AreEqual(string.Format("You entered: {0}", value),result);
    

        }
        [TestMethod]
        public void TestMethod6()
        {
            var service = new Service1();
            var result = service.GetCurrentId();

            Assert.AreEqual(0, result);


        }
        [TestMethod]
        public void TestMethod7()
        {
            MotorcycleManagementService motorcycleService = new MotorcycleManagementService();
            var service = new Service1();
            int id = 5;
            var result = service.DeleteMotorcycle(id);
            if (!motorcycleService.Delete(id))
            {
                Assert.AreEqual("Motorcycle is not deleted!", result);
            }
            else
            {
                Assert.AreEqual("Motorcycle is deleted!", result);
            }
        }
        [TestMethod]
        public void TestMethod8()
        {
            var service = new Service1();
            try
            {
                service.SetCurrentId(3);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void TestMethod9()
        {

            MotorcycleManagementService motorcycleService = new MotorcycleManagementService();
            var service = new Service1();
            int id = 5;
            var result = service.DeleteMotorcycle(id);
            if (!motorcycleService.Delete(id))
            {
                Assert.AreEqual("Motorcycle is not deleted!", result);
            }
            else
            {
                Assert.AreEqual("Motorcycle is deleted!", result);
            }
        }
        [TestMethod]
        public void TestMethod10()
        {

            SaleManagementService saleService = new SaleManagementService();
            var service = new Service1();
            int id = 5;
            var result = service.DeleteSale(id);
            if (!saleService.Delete(id))
            {
                Assert.AreEqual("Sale is not deleted!", result);
            }
            else
            {
                Assert.AreEqual("Sale is deleted!", result);
            }
        }
        [TestMethod]
        public void TestMethod11()
        {

            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }
        [TestMethod]
        public void TestMethod12()
        {
            int id = 5;
            var service = new Service1();
            try
            {
                service.DeleteBrand(id);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void TestMethod13()
        {
            int id = 5;
            var service = new Service1();
            try
            {
                service.DeleteMotorcycle(id);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void TestMethod14()
        {
            int id = 5;
            var service = new Service1();
            try
            {
                service.DeleteSale(id);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void TestMethod15()
        {
            int id = 0;
            var service = new Service1();
            try
            {
                service.GetBrandByID(id);
                Assert.IsFalse(true);
            }
            catch
            {
                Assert.IsFalse(false);
            }
        }
        [TestMethod]
        public void TestMethod16()
        {
            string filter = "";
            var service = new Service1();
            try
            {
                service.GetBrands(filter);
                Assert.IsFalse(true);
            }
            catch
            {
                Assert.IsFalse(false);
            }
        }
    }
}
