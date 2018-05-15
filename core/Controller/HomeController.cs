using Demo.MusicLibrary.Api.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.MusicLibrary.Api.Core.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUrlTemplateReader _templateReader;
        private readonly ILoggerFactory _loggerFactory;

        public HomeController(IUrlTemplateReader templateReader, ILoggerFactory loggerFactory)
        {
            _templateReader = templateReader;
            _loggerFactory = loggerFactory;
        }

        [Route(Constants.Routes.Home.Prefix, Name = Constants.Relations.Home.GetUrlTemplates)]
        public IActionResult Get()
        {
            return Ok(_templateReader.GetTemplates());
        }
    }
}
