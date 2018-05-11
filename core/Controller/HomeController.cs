using System;
using System.Collections.Generic;
using System.Linq;
using Demo.MusicLibrary.Api.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Demo.MusicLibrary.Api.Core.Controller
{
    [ApiController]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IActionDescriptorCollectionProvider _collectionProvider;
        public HomeController(IActionDescriptorCollectionProvider collectionProvider)
        {
            _collectionProvider = collectionProvider;
        }

        [Route(Constants.Routes.Home.Prefix, Name = Constants.Relations.Home.GetUrlTemplates)]
        public ActionResult<IEnumerable<Link>> Get()
        {
            IList<Link> result = new List<Link>();
            AddRoute(ref result, Constants.Relations.Home.GetUrlTemplates);
            AddRoute(ref result, Constants.Relations.Artists.GetArtists);
            AddRoute(ref result, Constants.Relations.Artists.GetArtistById);
            AddRoute(ref result, Constants.Relations.Artists.AddArtist);
            AddRoute(ref result, Constants.Relations.Artists.UpdateArtist);
            AddRoute(ref result, Constants.Relations.Artists.RemoveArtist);
            return Ok(result);
        }



        private void AddRoute(ref IList<Link> target, string relation)
        {
            var item = _collectionProvider
                        .ActionDescriptors
                        .Items
                        .FirstOrDefault(_ => _.AttributeRouteInfo.Name == relation);
            if (item == null) throw new NullReferenceException($"invalid relation: {relation}");
            target.Add(new Link
            {
                Relation = item.AttributeRouteInfo.Name,
                Method = item.RouteValues["action"].ToUpper(),
                Hyperreference = item.AttributeRouteInfo.Template
            });
        }
    }
}
