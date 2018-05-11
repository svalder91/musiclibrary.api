using System.Collections.Generic;
using Demo.MusicLibrary.Api.Contracts.Models;

namespace Demo.MusicLibrary.Api.Contracts.Services
{
    public interface  IUrlTemplateReader
    {
        IEnumerable<Link> GetTemplates();
    }
}
