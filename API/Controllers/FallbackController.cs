using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class FallbackController : Controller
{
    public ActionResult Index() 
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwrooot", "index.html"), "text/HTML");
    }

}