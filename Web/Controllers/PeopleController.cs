using AutoMapper;
using Data.Models;
using Service.Abstracts;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonService _service;



        public PeopleController(IPersonService service)
        {
             
            _service  = service;
        }

        // GET: People
        public ActionResult Index()
        {
            var people = _service.GetAll(p => p.Id != 0);
            var peopleViewModels = Mapper.Map<IEnumerable<PersonViewModel>>(people);
            return View(peopleViewModels);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _service.Find(x=> x.Id == id);
            var personVieModel = Mapper.Map<PersonViewModel>(person);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(personVieModel);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,DateOfBirth,Sexo")] PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.Map<Person>(personViewModel);
                _service.Add(person);
                return RedirectToAction("Index");
            }

            return View(personViewModel);
        }

        // GET: People/Edit/5
        public  ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _service.Find(x => x.Id == id);
            var personViewModel = Mapper.Map<PersonViewModel>(person);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(personViewModel);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,DateOfBirth,Sexo")] PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.Map<Person>(personViewModel);
                _service.Update(person);
                return RedirectToAction("Index");
            }
            return View(personViewModel);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _service.Find(x => x.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = _service.Find(x=> x.Id == id);
            _service.Delete(person);
            return RedirectToAction("Index");
        }

    }
}
