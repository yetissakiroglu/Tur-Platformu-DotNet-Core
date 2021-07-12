using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YonetimUI.ViewModels;
using Entities.Concrete;
using Mapster;
using Core.Extensions;
using Core.Entities.Concrete;
using Core.Utilities.Messages;

namespace YonetimUI.Controllers
{
    public class LocationController : Controller
    {
        ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult Index(int pageSize, string text, int locationId, int page = 1)
        {

            try
            {
                if (pageSize == 0)
                {
                    pageSize = 10;
                }

                var locations = _locationService.ListLocationPagingByTopLocationIdAndByTitle(text, locationId, page, pageSize);
                if (locations.Success)
                {
                    var models = new LocationViewModel()
                    {
                        title = "Lokasyonlar",
                        message = "Bu konumda lokasyon bilgileriniz listelenmektedir.",
                        Locations = locations.Data,
                        PagingInfo = new PagingInfo()
                        {
                            CurrentPage = page,
                            ItemsPerPage = pageSize,
                            TotalItems = _locationService.CountLocationByTopLocationId(locationId).Data
                        }
                    };

                    List<SelectListItem> note = new List<SelectListItem>();
                    note.Insert(0, new SelectListItem() { Value = "0", Text = " --- Lokasyon Seçiniz --- " });
                    foreach (var item in _locationService.ListLocation().Data)
                    {
                        var selectList = new SelectListItem
                        {
                            Text = item.title,
                            Value = item.location_Id.ToString(),
                        };
                        note.Add(selectList);
                    }

                    models.TopLocationListItem = note;

                    if (!string.IsNullOrEmpty(text))
                    {
                        models.Search = text;
                    }


                    return View(models);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title ="Hata",
                    Message = "Sistem Hatası Oluştur. Tekrar deneyiniz.",
                    Css = "alert-warning",
                });
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            LocationViewModel model = new LocationViewModel()
            {
                title = "Yeni Lokasyon Ekleme Bölümü",
                //TopLocationListItem = new SelectList(_locationService.ListLocation().Data, "location_Id", "title", " -- Seçim Yapınız -- "),
                Location = new Location(),

            };

            List<SelectListItem> note = new List<SelectListItem>();
            note.Insert(0, new SelectListItem() { Value = "0", Text = " --- Lokasyon Seçiniz --- " });
            foreach (var item in _locationService.ListLocation().Data)
            {
                var selectList = new SelectListItem
                {
                    Text = item.title,
                    Value = item.location_Id.ToString(),
                };
                note.Add(selectList);
            }

            model.TopLocationListItem = note;

            return View(model);
        }



        [HttpPost]
        public IActionResult Create(LocationViewModel model)
        {
            Location entity = new Location()
            {
               location_Id=model.Location.location_Id,
                title=model.Location.title,
                description=model.Location.description,
                image_Id = model.Location.image_Id,
                row = model.Location.row,
                state = model.Location.state,
                IsChecked = model.Location.IsChecked,
            };
      

            var result = _locationService.Create(entity);
            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Başarılı",
                    Message = "Kayıt işlemi yapılmıştır.",
                    Css = "alert-success",
                });

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", result);
            }

         

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try
            {
                var deletemodel = _locationService.GetLocationByLocationId((int)id);
                if (deletemodel.Success)
                {
                    Location entity = new Location()
                    {
                        location_Id = deletemodel.Data.location_Id,
                        title = deletemodel.Data.title,
                        description = deletemodel.Data.description,
                        image_Id = deletemodel.Data.image_Id,
                        row = deletemodel.Data.row,
                        state = deletemodel.Data.state,
                        IsChecked = deletemodel.Data.IsChecked,
                    };

                    var modeldelete = _locationService.Delete(entity);
                    if (modeldelete.Success)
                    {
                        TempData.Put("message", new ResultMessage()
                        {
                            Title = ProsesMessages.TitleSuccess,
                            Message = ProsesMessages.MessageDelete,
                            Css = ProsesMessages.CssWarning,
                        });
                    }
                    else
                    {
                        TempData.Put("message", new ResultMessage()
                        {
                            Title = ProsesMessages.TitleError,
                            Message = ProsesMessages.MessageError,
                            Css = ProsesMessages.CssError,
                        });
                    }
                }
            }
            catch (Exception e)
            {

                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = e.Message,
                    Css = ProsesMessages.CssError,
                });

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Active(bool active, int id)
        {
            var modelactive = _locationService.GetLocationByLocationId((int)id);

            LocationViewModel model = new LocationViewModel()
            {
                Location = modelactive.Data
            };


            if (active == true)
            {
                model.Location.state = false;
            }
            if (active == false)
            {
                model.Location.state = true;
            }

            var resultUpdate = _locationService.Update(model.Location);
            if (resultUpdate.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = ProsesMessages.MessageEdit,
                    Css = ProsesMessages.CssSuccess
                });
            }
            return RedirectToAction("Index");
        }

    }
}
