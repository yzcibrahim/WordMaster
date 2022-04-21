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
    public class WordDefinitionController : Controller
    {
        IWordDefinitionRepository _repository;
        public WordDefinitionController(IWordDefinitionRepository repository)
        {
            _repository = repository;
        }
        // GET: LanguageController
        public ActionResult Index()
        {
            List<WordDefinitionViewModel> model = new List<WordDefinitionViewModel>();

            List<WordDefinition> liste = _repository.List();

            foreach (WordDefinition item in liste)
            {
                WordDefinitionViewModel lwm = new WordDefinitionViewModel()
                {
                    Id = item.Id,
                    Word = item.Word,
                    LangId = item.LangId
                };

                model.Add(lwm);
            }
            return View(model);
        }

        // GET: LanguageController/Edit/5
        public ActionResult Edit(int? id)
        {
            WordDefinitionViewModel model = new WordDefinitionViewModel();
            if (id.HasValue && id > 0)
            {
                WordDefinition wd = _repository.GetById(id.Value);

                model.Id = wd.Id;
                model.Word = wd.Word;
                model.LangId = wd.LangId;
            }

            return View(model);
        }

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WordDefinitionViewModel model)
        {
            WordDefinition entity = new WordDefinition()
            {
                Id = model.Id,
                 LangId = model.LangId,
                Word = model.Word
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
