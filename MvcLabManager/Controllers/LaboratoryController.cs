using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LaboratoryController : Controller
{
    private LabManagerContext _context;

    public LaboratoryController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        return View(_context.Laboratorys);
    }

    public IActionResult Show(int id)
    {
        Laboratory? laboratory =_context.Laboratorys.Find(id);

        if(laboratory == null)
        {
            return NotFound();
        }
        return View(laboratory);
    }

    public IActionResult Create(){
                
        return View();
    }

    public IActionResult Creation(int id, int number, string name, string block){
        if(_context.Laboratorys.Find(id) == null)
        {
            _context.Laboratorys.Add(new Laboratory(id,number,name,block));
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
           return Content("Já existe um laboratorio com esse id");
        }
       
    }

    public IActionResult Delete(int id){
        _context.Laboratorys.Remove(_context.Laboratorys.Find(id));
        _context.SaveChanges();
        return View();
    }

    public IActionResult Update(int id){
        Laboratory laboratory = _context.Laboratorys.Find(id);
        if(laboratory == null)
        {
            return Content("Esse laboratorio não existe!");
        }
        else
        {
           return View(laboratory);
        }
    }

    public IActionResult Updation(int id, int number, string name, string block){
        Laboratory laboratory = _context.Laboratorys.Find(id);

        laboratory.Number = number;
        laboratory.Name = name;
        laboratory.Block = block;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
}