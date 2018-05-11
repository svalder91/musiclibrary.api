using System.Collections.Generic;
using Demo.MusicLibrary.Api.Contracts.Models;
using Demo.MusicLibrary.Api.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.MusicLibrary.Api.Core.Controller
{
    [ApiController]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUrlTemplateReader _templateReader;
        public HomeController(IUrlTemplateReader templateReader)
        {
            _templateReader = templateReader;
        }

        [Route(Constants.Routes.Home.Prefix, Name = Constants.Relations.Home.GetUrlTemplates)]
        public ActionResult<IEnumerable<Link>> Get()
        {
            return Ok(_templateReader.GetTemplates());
        }
    }
}
