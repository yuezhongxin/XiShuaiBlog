using System.Web.Mvc;

namespace CMSExpress.MvcApplication.Areas.Workflow
{
    public class WorkflowAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "workflow";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "workflow_default",
                "workflow/{controller}/{action}/{id}",
                new { action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
