using GestionTickets.Models;
using GestionTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionTickets.Controllers
{
    public class TicketController : Controller
    {
        TicketsContext context = new TicketsContext();
        // GET: Ticket
        public ActionResult Index()
        {
            var listado = context.Tickets;
            return View(listado);
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            var viewmodel = new TicketViewModel();
            viewmodel.Responsables = context.Responsables.ToList();
            viewmodel.Estados = context.Estados.ToList();
            viewmodel.Usuarios = context.Usuarios.ToList();
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Nuevo(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var viewModel = new TicketViewModel();
            viewModel.Ticket = context.Tickets.FirstOrDefault(x => x.Id == id);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            var viewModel = new TicketViewModel();
            viewModel.Ticket = context.Tickets.FirstOrDefault(x => x.Id == id);
            viewModel.Responsables = context.Responsables.ToList();
            viewModel.Estados = context.Estados.ToList();
            viewModel.Usuarios = context.Usuarios.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Actualizar(Ticket ticket)
        {
            context.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var ticket = context.Tickets.FirstOrDefault(x => x.Id == id);
            context.Tickets.Remove(ticket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}