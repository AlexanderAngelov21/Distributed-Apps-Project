
using ApplicationService.DTOs;
using MVC.Utils;
using MVCAuthentication.ServiceReference1;
using MVCAuthentication.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthentication.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index(int? page,string Search_Data = "")
        {
            const int pageSize = 3;
            int pageNumber = (page ?? 1);
            List<SaleVM> salesVM = new List<SaleVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetSales(Search_Data))
                {
                    salesVM.Add(new SaleVM(item));
                }
            }
            var model = salesVM.ToList().ToPagedList(pageNumber, pageSize); 
            return View(model);
        }

        // GET: Sales/Details/
        public ActionResult Details(int id)
        {
            SaleVM saleVM = new SaleVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var saleDto = service.GetSaleByID(id);
                saleVM = new SaleVM(saleDto);
            }

            return View(saleVM);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {

                ViewBag.Motorcycles = new SelectList(service.GetMotorcycles(""), "Id", "Model");
            }
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleVM saleVM)
        {
            try
            {
                if (ModelState.IsValid && AccountController.loggedIn == true)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
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


                        service.PostSale(saleDto);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                ViewBag.Motorcycles = LoadDataUtil.LoadMotorcycleData();
                return View();
            }
        }


        // GET: Sales/Edit


        [HttpGet]
        public ActionResult Edit(int id)
        {


            SaleVM saleVM = new SaleVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                ViewBag.Motorcycles = new SelectList(service.GetMotorcycles(""), "Id", "Model");
                var saleDto = service.GetSaleByID(id);
                saleVM = new SaleVM(saleDto);

            }
            //ViewBag.Motorcycles = LoadDataUtil.LoadMotorcycleData();
            return View(saleVM);


        }

        // POST: Sales/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaleVM saleVM)
        {
            try
            {
                if (ModelState.IsValid && AccountController.loggedIn == true)
                {

                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {
                        SaleDTO saleDto = new SaleDTO
                        {
                            Id=saleVM.Id,
                            ClientFirstName = saleVM.ClientFirstName,
                            ClientLastName = saleVM.ClientLastName,
                            SellerName = saleVM.SellerName,
                            SaleDate = saleVM.SaleDate,
                            SalePrice = saleVM.SalePrice,

                            MotorcycleId = saleVM.MotorcycleId,
                            Motorcycle = new MotorcycleDTO
                            {
                                Id = saleVM.MotorcycleId
                            }



                        };
                        service.PostSale(saleDto);


                    }



                    return RedirectToAction("Index");
                }

                ViewBag.Sales = LoadDataUtil.LoadSaleData();
                return View();
            }
            catch
            {
                ViewBag.Sales = LoadDataUtil.LoadSaleData();
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                if (AccountController.loggedIn == true)
                {
                    service.DeleteSale(id);
                }

            }
            return RedirectToAction("Index");
        }
    }
}