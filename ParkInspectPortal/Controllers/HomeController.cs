using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

using ParkInspectPortal.Helpers;
using ParkInspectPortal.Models;
using ParkInspectPortal.Repositories;


namespace ParkInspectPortal.Controllers
{
    public class HomeController : Controller
    {
        private IInspectionRepo _inspectionRepo;
        public HomeController(IInspectionRepo inspectionRepo)
        {
            _inspectionRepo = inspectionRepo;
        }

        public ActionResult Index()
        {
            return View(_inspectionRepo.GetInspections());
        }

        public ActionResult Download(Guid Guid)
        {
            // TODO: Map data with AutoMapper from repo or DB
            List<QuestionListViewModel> pdfvm = _inspectionRepo.GetQuestionList(Guid);

            if (pdfvm == null)
            {
                ViewBag.Error = "Fout tijdens genereren van PDF!";
                return View("Index");

            }

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