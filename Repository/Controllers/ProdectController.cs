
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Models;

namespace Repository.Controllers
{
    public class ProdectController : Controller
    {
        private readonly IProdectRepository _prodectRepo;

        public ProdectController(IProdectRepository prodectRepo)
        {
            _prodectRepo = prodectRepo;
        }

        //private object search;
        //public async Task<IActionResult> Index(string search)
        //{
        //    var prodect1 = await _prodectRepo.Prodect1
        //    .Where(emp => string.IsNullOrEmpty(search) || (emp.ProdectName != null && emp.ProdectName.ToLower().Contains(search.ToLower()))).GetAll();
        //    return View(prodect1);
        //}



        public async Task<IActionResult> Index()
        {
            var prodect1 = await _prodectRepo.GetAll();
            return View(prodect1);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Prodect1());
            }
            else
            {
                try
                {
                    Prodect1 prodect1 = await _prodectRepo.GetById(id);
                    if (prodect1 != null)
                    {
                        return View(prodect1);
                    }
                }
                catch (Exception ex)
                {
                    TempData["errorMessage"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["errorMessage"] = $"Prodect details not found with Id : {id}";
                return RedirectToAction("Index");   
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Prodect1 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        await _prodectRepo.Add(model);
                        TempData["succesMessage"] = "Prodect created successfully !";
                    }
                    else
                    {
                      await  _prodectRepo.Update(model);
                        TempData["succesMessage"] = "Prodect details updated successfully !";
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["errorMessage"] = "Model state is invalid";
                    return View();
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();

            }
        }
        public async Task<IActionResult> Details(int id)
        {
            if(id == 0)
            {
                return View();
            }
            var prodect1 = await _prodectRepo.GetById(id);
            if (prodect1 == null)
            {
                return View();
            }
            return View(prodect1);
        }
            [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Prodect1 prodect1 = await _prodectRepo.GetById(id);
                if (prodect1 != null)
                {
                    return View(prodect1);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");

            }
            TempData["errorMessage"] = $"Prodect details not found with id : {id}";
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _prodectRepo.Delete(id);
                TempData["succesMessage"] = "Prodect deleted successfully !";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
