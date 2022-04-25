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
        ILanguageRepository _langRepository;
        public WordDefinitionController(IWordDefinitionRepository repository, ILanguageRepository langRepository)
        {
            _repository = repository;
            _langRepository = langRepository;
        }
        // GET: LanguageController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ListPartial(string searchKeyword)
        {
            List<WordDefinitionViewModel> model = new List<WordDefinitionViewModel>();

            List<WordDefinition> liste = searchKeyword != null ?
                                        _repository.List(searchKeyword) :
                                        _repository.List();

            foreach (WordDefinition item in liste)
            {
                WordDefinitionViewModel lwm = new WordDefinitionViewModel()
                {
                    Id = item.Id,
                    Word = item.Word,
                    LangId = item.LangId,
                    LangCode = item.Lang.Code,
                    LangName = item.Lang.Name,
                    Meanings = new List<WordMeaningViewModel>()
                };

                foreach (var meaning in item.WordMeanings)
                {
                    lwm.Meanings.Add(new WordMeaningViewModel()
                    {
                        Id = meaning.Id,
                        LangId = meaning.LangId,
                        Meaning = meaning.Meaning,
                        WordDefinitionId = meaning.WordDefinitionId,
                        SelectedLang = new LanguageViewModel()
                        {
                            Code = meaning.Lang.Code,
                            Id = meaning.Lang.Id,
                            Name = meaning.Lang.Name
                        }
                    });
                }

                model.Add(lwm);
            }
            return PartialView(model);
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
            ViewBag.Langs = _langRepository.List();

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
