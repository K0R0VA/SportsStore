using Microsoft.AspNetCore.Mvc;

namespace SportsStoreForAzure.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}