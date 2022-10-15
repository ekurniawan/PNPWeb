using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyASPApp.DAL;
using MyASPApp.Models;

namespace MyASPApp.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ILogger<TrainerController> _logger;
        private readonly ITrainer _trainer;

        public TrainerController(ILogger<TrainerController> logger,ITrainer trainer)
        {
            _logger = logger;
            _trainer = trainer;
        }

        public IActionResult Index(string nama,string course)
        {
            ViewData["nama"] = nama;
            ViewData["course"] = course;
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _trainer.Get(id);
            if(model == null)
            {
                TempData["pesan"] = $"<span class='alert alert-danger'>Data dengan id: {id} tidak ditemukan</span>";
                return RedirectToAction(nameof(GetAllTrainer));
            }
            return View(model);
        }

        public IActionResult Update(int id){
            var model = _trainer.Get(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Trainer trainer){
            _trainer.Update(trainer.Id,trainer);
            return RedirectToAction(nameof(GetAllTrainer));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Trainer trainer)
        {
            _trainer.Add(trainer);
            return RedirectToAction(nameof(GetAllTrainer));
        }

        public IActionResult Delete(int id){
            var model = _trainer.Get(id);
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeletePost(int id){
            _trainer.Delete(id);
            return RedirectToAction(nameof(GetAllTrainer));
        }

        public IActionResult GetAllTrainer()
        {
            ViewData["pesan"] = TempData["pesan"] ?? TempData["pesan"];

            var models = _trainer.GetAll();
            return View(models);
        }

        public IActionResult Registrasi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrasi(string nama,string course)
        {
            ViewData["nama"] = nama;
            ViewData["course"] = course;
            return View("ResultRegistrasi");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}