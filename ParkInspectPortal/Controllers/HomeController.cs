using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

using ParkInspectPortal.Helpers;
using ParkInspectPortal.Models;
using ParkInspectPortal.Repositories;
using System.Windows;

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
        [HttpGet]
        public ActionResult Download(string Guid)
        {
            List<QuestionListViewModel> pdfvm =new List<QuestionListViewModel>();

            try
            {
                Guid _guid = new Guid(Guid);               
                pdfvm = _inspectionRepo.GetQuestionList(_guid);
            }
            catch (Exception)
            {
                
            }

            if (pdfvm == null)
            {
                return View("Error");
            }

            using (var pdfBuilder = new PDFBuilder())
            {
                pdfBuilder.AddHtml(pdfvm, pdfBuilder.MapPath("/Views/_templates/PDF/Inspectie.cshtml"));
                return File(pdfBuilder.GetPdfStream(), "application/pdf");
            }
        }
    }
}