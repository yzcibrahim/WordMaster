using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordMaster.Filters;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class WordDefinitionController : Controller
    {
        readonly IWordDefinitionRepository _repository;
        readonly ILanguageRepository _langRepository;
        public WordDefinitionController(IWordDefinitionRepository repository, ILanguageRepository langRepository)
        {
            _repository = repository;
            _langRepository = langRepository;
        }
        // GET: LanguageController
      
        [MyFirstActionFilter]
        public ActionResult Index()
        {
            Request.Headers.Add("test", "asd");
            WordDefIndexViewModel model = new WordDefIndexViewModel();
            var langs = _langRepository.List();
           

            
            model.Langs = new List<LanguageViewModel>();

            foreach (var lng in langs)
            {
                model.Langs.Add(new LanguageViewModel() { Id = lng.Id, Code = lng.Code, Name = lng.Name });
            }

            return View(model);
        }

        [MyFirstActionFilter]
        public IActionResult ListPartial(string searchKeyword,int? selectedLang)
        {
            List<WordDefinitionViewModel> model = new List<WordDefinitionViewModel>();

            //List<WordDefinition> liste = searchKeyword != null ?
            //                            _repository.List(searchKeyword) :
            //                            _repository.List();
            List<WordDefinition> liste = _repository.List(searchKeyword, selectedLang);

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
        [MyFirstActionFilter]
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
        [MyFirstActionFilter]
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
        [MyFirstActionFilter]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: LanguageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyFirstActionFilter]
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
