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
    }
}
