using Microsoft.AspNetCore.Mvc;

namespace Equinox.UI.Web.ViewComponents
{
    /// <summary>
    /// SummaryViewComponent is a class that represents a ViewComponent for rendering a summary view.
    /// </summary>
    public class SummaryViewComponent : ViewComponent
    {
        /// <summary>
        /// Invoke is the method that is called when this ViewComponent is executed.
        /// It returns a ViewResult that renders the Default view.
        /// </summary>
        /// <returns>A ViewResult that renders the Default view.</returns>
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}
