using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileAPPMVC.Models;
using MobileAPPMVC.Repository;
using MobileAPPMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Controllers
{
    [Authorize]
    public class MobileController : Controller
    {
        IMobileRepository _mobileRepository;
        IManufacturerRepository _manufacturerRepository;
        public MobileController(IMobileRepository mobileRepository, IManufacturerRepository manufacturerRepository)
        {
            _mobileRepository = mobileRepository;
            _manufacturerRepository = manufacturerRepository;
        }

        public IActionResult Index()
        {
            var mobiles = _mobileRepository.GetAllMobiles();

            List<MobileDetailsViewModel> mobileDetailsListViewModel = new List<MobileDetailsViewModel>();

            foreach (var mobile in mobiles)
            {
                MobileDetailsViewModel mobileDetailsViewModel = new MobileDetailsViewModel
                {
                    Id = mobile.Id,
                    Name = mobile.Name,
                    Manufacturer = mobile.Manufacturer.ManufacturerName,
                    Amount = mobile.Amount
                };
                mobileDetailsListViewModel.Add(mobileDetailsViewModel);
            }

            return View(mobileDetailsListViewModel);

        }

        [HttpGet]
        public IActionResult AddMobile()
        {
            var addMobileViewModel = new AddMobileViewModel();

            
            var manufacturers = _manufacturerRepository.GetAllManufacturers();
            List<SelectListItem> manufacturerSelectListItems = new List<SelectListItem>();


            foreach (var manuf in manufacturers)
            {
               
                manufacturerSelectListItems.Add(new SelectListItem { Text = manuf.ManufacturerName, Value = manuf.ManufacturerId.ToString() });
            }

                   
            manufacturerSelectListItems.Insert(0, new SelectListItem { Text = "--Select-Manufacturer", Value = string.Empty });

           
            addMobileViewModel.ManufactureList = manufacturerSelectListItems;

            return View(addMobileViewModel);
        }
        [HttpPost]
        public IActionResult AddMobile(AddMobileViewModel mobileViewModel)
        {
            if (ModelState.IsValid)
            {
                var mobile = new Mobile
                {
                    Name = mobileViewModel.Name,
                    
                    ManufacturerId = mobileViewModel.ManufacturerId,
                    Amount = mobileViewModel.Amount
                };

                var addedMobile = _mobileRepository.AddMobile(mobile);

                return RedirectToAction("Index");
            }

            return View(mobileViewModel);

        }

        [HttpGet]
        public IActionResult UpdateMobile(int id)
        {
            var updateMobileViewModel = new UpdateMobileViewModel();
            var mobileToBeEdited = _mobileRepository.GetMobileById(id);


           
            var manufacturers = _manufacturerRepository.GetAllManufacturers();
            List<SelectListItem> manufacturerSelectListItems = new List<SelectListItem>();
            foreach (var manuf in manufacturers)
            {
                manufacturerSelectListItems.Add(new SelectListItem { Text = manuf.ManufacturerName, Value = manuf.ManufacturerId.ToString() });
            }
            manufacturerSelectListItems.Insert(0, new SelectListItem { Text = "--Select-Department", Value = string.Empty });
            updateMobileViewModel.ManufactureList = manufacturerSelectListItems;


            

            updateMobileViewModel.Id = mobileToBeEdited.Id;
            updateMobileViewModel.Name = mobileToBeEdited.Name;
           
            updateMobileViewModel.ManufacturerId = mobileToBeEdited.ManufacturerId;
            updateMobileViewModel.Amount = mobileToBeEdited.Amount;

            return View(updateMobileViewModel);
        }

        [HttpPost]
        public IActionResult UpdateMobile(int id, UpdateMobileViewModel updateMobileViewModel)
        {
            if (ModelState.IsValid)
            {
                Mobile mobile = new Mobile
                {
                    Name = updateMobileViewModel.Name,
                   
                    ManufacturerId = updateMobileViewModel.ManufacturerId,
                  Amount= updateMobileViewModel.Amount
                };
                _mobileRepository.UpdateMobile(id, mobile);
                return RedirectToAction("Index");
            }

            return View(updateMobileViewModel);

        }

        [HttpGet]
        public IActionResult DeleteMobile(int id)
        {
            var mobileToBeDeleted = _mobileRepository.GetFullMobileDetailsById(id);
            var deleteMobileViewModel = new DeleteMobileViewModel
            {
                Id = mobileToBeDeleted.Id,
                Name = mobileToBeDeleted.Name,

                Manufacturer = mobileToBeDeleted.Manufacturer.ManufacturerName,
                Amount=mobileToBeDeleted.Amount
            };
            return View(deleteMobileViewModel);
        }


        [HttpPost]
        public IActionResult DeleteMobile(DeleteMobileViewModel deleteMobileViewModel)
        {
            _mobileRepository.RemoveMobile(deleteMobileViewModel.Id);
            return RedirectToAction("Index");
        }

    }
}
