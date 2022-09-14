using Checkingx.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Checkingx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingListController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<CheckItem>> GetAllCheckItems()
        {
            List<CheckItem>? checkItems =
                JsonConvert.DeserializeObject<List<CheckItem>>(System.IO.File.ReadAllText(@"C:\Users\mateusz.konopka\Work Folders\Desktop\Book1.json"));

            return Ok(checkItems);
        }
    }
}