
using MVC.Utils;
using MVCAuthentication.ServiceReference1;
using MVCAuthentication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationService.DTOs;
using PagedList;
using System.IO;

namespace MVCAuthentication.Controllers
{
    public class MotorcycleController : Controller
    {

        public ActionResult Index(int? page, string Search_Data = "")
        {
            const int pageSize = 3;
            int pageNumber = (page ?? 1);
            List<MotorcycleVM> motorcycleVM = new List<MotorcycleVM>();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                foreach (var item in service.GetMotorcycles(Search_Data))
                {
                    motorcycleVM.Add(new MotorcycleVM(item));
                }
            }
            var model = motorcycleVM.ToList().ToPagedList(pageNumber, pageSize); 
            return View(model);
        }


        public ActionResult Details(int id)
        {
            MotorcycleVM motorcycleVM = new MotorcycleVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                var motorcycleDto = service.GetMotorcycleByID(id);
                motorcycleVM = new MotorcycleVM(motorcycleDto);
            }

            return View(motorcycleVM);
        }


        public ActionResult Create()
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                ViewBag.Brands = new SelectList(service.GetBrands(""), "Id", "BrandName");
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MotorcycleVM motorcycleVM)
        {
            try
            {
                if (ModelState.IsValid&& AccountController.loggedIn == true)
                {
                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {

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
                        service.PostMotorcycle(motorcycleDto);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                ViewBag.Brands = LoadDataUtil.LoadBrandData();
                return View();
            }
        }





        [HttpGet]
        public ActionResult Edit(int id)
        {


            MotorcycleVM motorcycleVM = new MotorcycleVM();
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {

                var motorcycleDto = service.GetMotorcycleByID(id);
                motorcycleVM = new MotorcycleVM(motorcycleDto);

            }



            //ViewBag.Motorcycles = LoadDataUtil.LoadMotorcycle();
            ViewBag.Brands = LoadDataUtil.LoadBrandData();
            return View(motorcycleVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MotorcycleVM motorcycleVM)
        {
            try
            {
                if (ModelState.IsValid&& AccountController.loggedIn == true)
                {

                    using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
                    {

                        MotorcycleDTO motorcycleDto = new MotorcycleDTO
                        {
                            Id=motorcycleVM.Id,
                            BrandId=motorcycleVM.BrandId,
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

                        service.PostMotorcycle(motorcycleDto);
                    }



                    return RedirectToAction("Index");
                }

                ViewBag.Motorcycles = LoadDataUtil.LoadBrandData();
                return View();
            }
            catch
            {
                ViewBag.Motorcycles = LoadDataUtil.LoadBrandData();
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            using (ServiceReference1.Service1Client service = new ServiceReference1.Service1Client())
            {
                if(AccountController.loggedIn == true)
                {
                    service.DeleteMotorcycle(id);
                }
                
            }
            return RedirectToAction("Index");
        }
    }
}