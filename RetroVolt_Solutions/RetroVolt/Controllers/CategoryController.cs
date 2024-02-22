using Microsoft.AspNetCore.Mvc;
using RetroVolt.Data;
using RetroVolt.Models;

namespace RetroVolt.Controllers
{
    public class CategoryController : Controller
    {
        //private read only field, whatever implementation received from the contrustor it will be assigned to 
        //the local variable. This way it woul be able to be used in any other action method. 
        private readonly ApplicationDbContext _db;
        //Contrustor created on implimentation on ApplicationDbContext with variable name db.
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //retrieve all the categories.
            //can also use var, but we define it explicitly here.
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj); //Keeps track of all the changes that needs to be made in the database, because there will be more.
                _db.SaveChanges();   //It will go to database and create the category.
                return RedirectToAction("Index", "Category"); //When the category is added it will return to the Category
                                                              //Index view so we can see all teh categories. 
                                                              //if ecerything is valid return to Index
            }

            return View(obj); //else return itself
        }

        public IActionResult Edit(int? id) //"?" means that it is made nullable.
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id); //one way of retrieving category from database
            //other ways to retrieve from databse
            //Category categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
                
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj); //statement for updataing category
                _db.SaveChanges();   
                return RedirectToAction("Index", "Category"); 
            }

            return View(obj); 
        }

        //Get action method
        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //Post action method

        [HttpPost, ActionName("Delete")] // We need to explicitly say that this endpoint is named delete
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _db.Categories.Find(id);   
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");

           
        }
    }
}
