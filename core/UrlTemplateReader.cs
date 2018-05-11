using System;
using System.Collections.Generic;
using System.Linq;
using Demo.MusicLibrary.Api.Contracts.Models;
using Demo.MusicLibrary.Api.Contracts.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Demo.MusicLibrary.Api.Core
{
    internal class UrlTemplateReader : IUrlTemplateReader
    {

        private readonly IActionDescriptorCollectionProvider _collectionProvider;
        private static IEnumerable<Link> _templates;

        // ReSharper disable once UnusedMember.Global
        public UrlTemplateReader(IActionDescriptorCollectionProvider collectionProvider)
        {
            _collectionProvider = collectionProvider;
            _templates = CreateTemplates();
        }

        private IEnumerable<Link> CreateTemplates()
        {
            IList<Link> result = new List<Link>();
            AddRoute(ref result, Constants.Relations.Home.GetUrlTemplates);
            AddRoute(ref result, Constants.Relations.Artists.GetArtists);
            AddRoute(ref result, Constants.Relations.Artists.GetArtistById);
            AddRoute(ref result, Constants.Relations.Artists.AddArtist);
            AddRoute(ref result, Constants.Relations.Artists.UpdateArtist);
            AddRoute(ref result, Constants.Relations.Artists.RemoveArtist);
            return result;
        }

        public IEnumerable<Link> GetTemplates()
        {
            return _templates;
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
