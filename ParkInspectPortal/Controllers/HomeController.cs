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
        private IAccessRepo _accessRepo;

        public HomeController(IInspectionRepo inspectionRepo, IAccessRepo accessRepo)
        {
            _inspectionRepo = inspectionRepo;
            _accessRepo = accessRepo;
        }

        public ActionResult Index(string token)
        {
            try
            {
                Guid accessToken = new Guid(token);
                if(_accessRepo.IsAuthorized(accessToken))
                    return View(_inspectionRepo.GetInspections());
            }
            catch (Exception)
            {

            }
            ViewBag.ErrMessage = "Toegang niet geautoriseerd!";
            return View("Error");

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
                ViewBag.ErrMessage = "Fout tijdens genereren van PDF!";
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