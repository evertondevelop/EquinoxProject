using Equinox.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            switch (id)
            {
                case 500:
                    SetErrorDetails(modelErro, "An error has occurred! Please try again later or contact our support.", "An error has occurred!");
                    break;
                case 404:
                    SetErrorDetails(modelErro, "The page you are looking for does not exist! <br /> If you have any questions please contact our support", "Oops! Page not found.");
                    break;
                case 403:
                    SetErrorDetails(modelErro, "You are not allowed to do this.", "Access Denied");
                    break;
                default:
                    return StatusCode(500);
            }

            return View("Error", modelErro);
        }

        private void SetErrorDetails(ErrorViewModel model, string message, string title)
        {
            model.Message = message;
            model.Title = title;
            model.ErrorCode = id;
        }
    }
}
