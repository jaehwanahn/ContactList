using ContactList.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ContactList.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            //contactlistEntities db = new contactlistEntities();

            //List<Contact> contactList = db.Contacts.ToList();

            //ContactViewModel contactViewModel = new ContactViewModel();

            //List<ContactViewModel> contactViewModelsList = contactList.Select(x => new ContactViewModel
            //{
            //    ID = x.ID,
            //    Who = x.Who,
            //    Status = x.Status,
            //    Company = x.Company,
            //    Ind = x.Ind,
            //    First = x.First,
            //    Last = x.Last,
            //    Position = x.Position,
            //    Phone = x.Phone,
            //    Email = x.Email
            //}).ToList();

            //return View(contactViewModelsList);
            ////////////////////////////////
            //Contact contact = db.Contacts.SingleOrDefault(x => x.ID == 1);

            //ContactViewModel contactVM = new ContactViewModel();

            //contactVM.ID = contact.ID;
            //contactVM.Who = contact.Who;
            //contactVM.Status = contact.Status;
            //contactVM.Company = contact.Company;
            //contactVM.Ind = contact.Ind;
            //contactVM.First = contact.First;
            //contactVM.Last = contact.Last;
            //contactVM.Position = contact.Position;
            //contactVM.Phone = contact.Phone;
            //contactVM.Email = contact.Email;



            //return View(contactVM);
            return View();
        }

        [HttpGet]
        public string GetData()
        {
            contactlistEntities db = new contactlistEntities();

            List<Contact> contactList = db.Contacts.ToList();

            ContactViewModel contactViewModel = new ContactViewModel();

            List<ContactViewModel> contactViewModelsList = contactList.Select(x => new ContactViewModel
            {
                ID = x.ID,
                Who = x.Who,
                Status = x.Status,
                Company = x.Company,
                Ind = x.Ind,
                First = x.First,
                Last = x.Last,
                Position = x.Position,
                Phone = x.Phone,
                Email = x.Email
            }).ToList();

            var output = JsonConvert.SerializeObject(contactViewModelsList);


            //return Json(new { data = output }, JsonRequestBehavior.AllowGet);
            return output;
        }
        [HttpPost]
        public void UpdateData(int id, string columnHeader, string newData)
        {
            try
            {
                contactlistEntities db = new contactlistEntities();
                // Create a Contact object and obtain all data of matching ID's row from dB. 
                Contact contactEntry = db.Contacts.FirstOrDefault(x => x.ID == id);

                // Get all properties of Contact class using Reflection
                PropertyInfo [] properties = contactEntry.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    Type propertyType = property.PropertyType;

                    // Find which column the change is made based on the header name.
                    // Convert 'newData' datatype to a correct one.
                    if (property.Name.Equals(columnHeader))
                        property.SetValue(contactEntry, Convert.ChangeType(newData, propertyType));
                }

                db.SaveChanges();
                // if contactEntry is null, throw exception?

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}