using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactList.Models
{
    public class ContactViewModel
    {
        public int ID { get; set; }
        public string Who { get; set; }
        public string Status { get; set; }
        public string Company { get; set; }
        public string Ind { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}