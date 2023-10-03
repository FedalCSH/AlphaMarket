using AlphaMarket_DataAccess.Data;
using AlphaMarket_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlphaMarket_Services;
using AlphaMarket_DataAccess.Repository.IRepository;

namespace AlphaServer.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _catRepo;
        public CategoryController(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _catRepo.GetAll();
            return View(objList);
        }

        //GET - CREATE
        
        
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Add(obj);
                _catRepo.Save();
                TempData[WC.Success] = "Новая категория создана успешно";
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = "При создании категории произошла ошибка";
            return View(obj);
        }
        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST - UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Update(obj);
                TempData[WC.Success] = "Категория изменена успешно";
                _catRepo.Save();
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = "При обновлении произошла ошибка";
            return View(obj);
        }
        //GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _catRepo.Find(id.GetValueOrDefault());
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
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if (id == null)
            {
                return NotFound();
            }
            TempData[WC.Success] = "Категория удалена";
            _catRepo.Remove(obj);
            _catRepo.Save();
            return RedirectToAction("Index");                        
        }

    }

}

