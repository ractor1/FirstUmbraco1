using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using MyUmbraco1.Models;

namespace MyUmbraco1.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult ShowForm()
        {
            ContactDataModel mmodel =  new ContactDataModel();
            return PartialView("ContactForm", mmodel);
        }

        public ActionResult HandleFromPost(ContactDataModel model)
        {
            var newEmail = Services.ContentService.CreateContent(model.ID + model.firstname, CurrentPage.Id, "ContactPage");
            newEmail.SetValue("emailfrom", model.emailfrom);
            newEmail.SetValue("firstname", model.firstname);
            newEmail.SetValue("lastname", model.lastname);
            Services.ContentService.SaveAndPublishWithStatus(newEmail);

            return RedirectToCurrentUmbracoPage();
        }
    }
}