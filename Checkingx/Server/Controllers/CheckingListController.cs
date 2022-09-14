﻿using Checkingx.Shared;
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
            string jsonLocation = $@"{Environment.CurrentDirectory}\Data\checking_list.json";

            List<CheckItem>? checkItems =
                JsonConvert.DeserializeObject<List<CheckItem>>(System.IO.File.ReadAllText(jsonLocation));

            return Ok(checkItems);
        }
    }
}