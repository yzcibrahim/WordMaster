using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class LanguageController : Controller
    {
        ILanguageRepository _repository;
        public LanguageController(ILanguageRepository repository)
        {
            _repository = repository;
        }
        // GET: LanguageController
        public ActionResult Index()
        {
            List<LanguageViewModel> model = new List<LanguageViewModel>();

            List<Language> liste = _repository.List();

            foreach (Language item in liste)
            {
                LanguageViewModel lwm = new LanguageViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code
                };

                model.Add(lwm);
            }
            return View(model);
        }

        public IActionResult Index1()
        {
            return View();
        }



        // GET: LanguageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LanguageController/Edit/5
        public ActionResult Edit(int? id)
        {
            LanguageViewModel model = new LanguageViewModel();
            if(id.HasValue&& id>0)
            {
                Language lang = _repository.GetById(id.Value);

                model.Id = lang.Id;
                model.Code = lang.Code;
                model.Name = lang.Name;
            }

            return View(model);
        }

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LanguageViewModel model)
        {
            Language entity = new Language()
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code
            };

            if (entity.Id > 0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Add(entity);
            }
            return RedirectToAction("Index");
        }

        // GET: LanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: LanguageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
