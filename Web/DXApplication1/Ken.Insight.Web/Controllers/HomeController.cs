namespace Ken.Insight.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using DevExpress.Web.Mvc;

    using Ken.Insight.Web.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            
            return this.View(NorthwindDataProvider.GetCustomers());
        }
        
        public ActionResult GridViewPartialView() 
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return this.PartialView("GridViewPartialView", NorthwindDataProvider.GetCustomers());
        }


        Ken.Insight.Web.Models.NorthwindDataContext db = new Ken.Insight.Web.Models.NorthwindDataContext();

        [ValidateInput(false)]
        public ActionResult DataViewPartial()
        {
            var model = this.db.Customers;
            return this.PartialView("_DataViewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult FileManagerPartial()
        {
            return this.PartialView("_FileManagerPartial", HomeControllerFileManagerSettings.Model);
        }

        public FileStreamResult FileManagerPartialDownload()
        {
            return FileManagerExtension.DownloadFiles("FileManager", HomeControllerFileManagerSettings.Model);
        }
    }
    public class HomeControllerFileManagerSettings
    {
        public const string RootFolder = @"~\";

        public static string Model { get { return RootFolder; } }
    }

    public enum HeaderViewRenderMode { Full, Title }
}