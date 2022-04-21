using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class WordMeaningController : Controller
    {
        IWordMeaningRepository _repository;
        public WordMeaningController(IWordMeaningRepository repository)
        {
            _repository = repository;
        }
        // GET: LanguageController
        public ActionResult Index()
        {
            List<WordMeaningViewModel> model = new List<WordMeaningViewModel>();

            List<WordMeaning> liste = _repository.List();
            var serializedText = JsonSerializer.Serialize(liste);
            model = JsonSerializer.Deserialize<List<WordMeaningViewModel>>(serializedText);
           
            return View(model);
        }

        // GET: LanguageController/Edit/5
        public ActionResult Edit(int? id)
        {
            WordMeaningViewModel model = new WordMeaningViewModel();
            if (id.HasValue && id > 0)
            {
                WordMeaning wd = _repository.GetById(id.Value);
                var serializedText = JsonSerializer.Serialize(wd);
                model = JsonSerializer.Deserialize<WordMeaningViewModel>(serializedText);
            }

            return View(model);
        }

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WordMeaningViewModel model)
        {
            WordMeaning entity = new WordMeaning();

            var serilazedText = JsonSerializer.Serialize(model);
            entity = JsonSerializer.Deserialize<WordMeaning>(serilazedText);

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

    }
}
