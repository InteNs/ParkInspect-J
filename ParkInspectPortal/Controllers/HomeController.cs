using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

using ParkInspectPortal.Helpers;
using ParkInspectPortal.Models;


namespace ParkInspectPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // TODO: get all inspections from DB
            List<InspectionViewModel> Inspections = new List<InspectionViewModel>();
            using (var ctx = new ParkInspectEntities())
            {
                var inspections = ctx.Inspection.ToList();
                foreach(var item in inspections)
                    Inspections.Add(new InspectionViewModel()
                    {
                        DateTimeEnd = item.DateTimeEnd,
                        DateTimeStart = item.DateTimeStart,
                        Guid = item.Guid,
                        Id= item.Id,
                    });
            }

                return View(Inspections);
        }

        public ActionResult Download(Guid Guid)
        {
            // TODO: Map data with AutoMapper from repo or DB
            var pdfvm = new InspectionPDFViewModel();

            using (var pdfBuilder = new PDFBuilder())
            {
                pdfBuilder.AddHtml(pdfvm, pdfBuilder.MapPath("/Views/_templates/PDF/Inspectie.cshtml"));
                return File(pdfBuilder.GetPdfStream(), "application/pdf");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}