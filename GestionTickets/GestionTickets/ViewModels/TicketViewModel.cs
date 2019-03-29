using GestionTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionTickets.ViewModels
{
    public class TicketViewModel
    {
        public Ticket Ticket { get; set; }
        public List<Responsable> Responsables { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Estado> Estados { get; set; }
    }
}