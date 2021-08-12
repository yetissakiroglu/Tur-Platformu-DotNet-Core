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
using Core.Services.FileManager;
using Core.Enums;
using YonetimUI.Extensions;

namespace YonetimUI.Controllers
{
    public class LocationController : Controller
    {
        ILocationService _locationService;
        private IFileManager _fileManager;
        ITreeviewLocation _treeviewLocation;

        public LocationController(IFileManager fileManager, ILocationService locationService, ITreeviewLocation treeviewLocation)
        {
            _treeviewLocation = treeviewLocation;
               _fileManager = fileManager;
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
                        },
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
                    Title = "Hata",
                    Message = "Sistem Hatası Oluştu. Tekrar deneyiniz." + e,
                    Css = "alert-warning",
                });
                return View("_message");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            LocationViewModel model = new LocationViewModel()
            {
                title = "Yeni Lokasyon Ekleme Bölümü",
                Location = new Location(),

            };

            model.TopLocationListItem = _treeviewLocation.TreeViewNote(_locationService.ListLocation().Data);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationViewModel viewmodel)
        {
            if (!ModelState.IsValid) return View(viewmodel);

            if (!_fileManager.ValidateUploadedFile(viewmodel.imgFile, UploadFileType.Image, 4, ModelState)) return View(viewmodel);

            string fileName = await _fileManager.UploadFileAsync(viewmodel.imgFile, new List<string> { "images", "lokasyon", "thumb" });

            Location entity = new Location()
            {
                location_Id = viewmodel.Location.location_Id,
                topLocation_Id = viewmodel.Location.topLocation_Id,
                title = viewmodel.Location.title,
                keywords = viewmodel.Location.keywords,
                description = viewmodel.Location.description,
                content = viewmodel.Location.content,
                image_Id = viewmodel.Location.image_Id,
                row = viewmodel.Location.row,
                state = viewmodel.Location.state,
                IsChecked = viewmodel.Location.IsChecked,
                imgPath = fileName,
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
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelview = _locationService.GetLocationByLocationId((int)id);

            if (modelview.Data == null)
            {
                return NotFound();
            }
            if (modelview.Success)
            {
                var model = new LocationViewModel()
                {
                    Location = modelview.Data.Adapt<Location>(),
                    title = modelview.Data.Adapt<Location>().title,
                    message = modelview.Data.Adapt<Location>().title + " - adlı içerik güncelenecektir."
                };

                List<SelectListItem> note = new List<SelectListItem>();
                note.Insert(0, new SelectListItem() { Value = "0", Text = " --- Lokasyon Seçiniz --- " });
                note.Insert(1, new SelectListItem() { Value = "-1", Text = " --- Üst Lokasyon -- " });

                // Get the top level parents
                var listeler = _locationService.ListLocation().Data;
                var parents = listeler.Where(x => x.topLocation_Id == -1);
                foreach (var parent in parents)
                {
                    // Add SelectListItem for the parent
                    note.Add(new SelectListItem()
                    {
                        Value = parent.location_Id.ToString(),
                        Text = parent.title
                    });
                    // Get the child items associated with the parent
                    var children = listeler.Where(x => x.topLocation_Id == parent.location_Id);

                  // Add SelectListItem for each child
                        foreach (var child in children)
                        {
                            note.Add(new SelectListItem()
                            {
                                Value = child.location_Id.ToString(),
                                Text = string.Format("--{0}", child.title)
                            });
                        }
                   
                }
   
                model.TopLocationListItem = note;

                return View(model);
            }
            else
            {
                return NotFound();
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
