using AlphaMarket_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlphaMarket_Services;
using AlphaMarket_DataAccess.Data;
using AlphaMarket_DataAccess.Repository.IRepository;

namespace AlphaServer.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ApplicationTypeController : Controller
    {
        private readonly IApplicationTypeRepository _appTypeRepo;
            public ApplicationTypeController(IApplicationTypeRepository appTypeRepo)
            {
            _appTypeRepo = appTypeRepo;
            }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objlist = _appTypeRepo.GetAll();
            return View(objlist);
        }
        //get create
        public IActionResult Create()
        {
            return View();
        }
        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid) 
            {
                _appTypeRepo.Add(obj);
                TempData[WC.Success] = "OK";
                _appTypeRepo.Save();
            return RedirectToAction("Index");
            }
            TempData[WC.Error] = "Произошла ошибка!!!";
            return View(obj);
        }
        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST - UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _appTypeRepo.Update(obj);
                TempData[WC.Success] = "OK";
                _appTypeRepo.Save();
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = "Произошла ошибка!!!";
            return View(obj);
        }
        //GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (id == null)
            {
                return NotFound();
            }
            _appTypeRepo.Remove(obj);
            TempData[WC.Success] = "OK";
            _appTypeRepo.Save();
            return RedirectToAction("Index");
        }
    }                    
}
