using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SovaDatabase;
using DataAccessLayer;
using Webservice.Models;
using AutoMapper;
using DomainModel;

namespace Webservice.Controllers
{
    [Route("api/taglinks")]
    public class TaglinkController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IUrlHelper _urlHelper;

        public TaglinkController(IDataService dataService, IUrlHelper urlHelper)
        {
            _dataService = dataService;
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = nameof(GetTaglinks))]
        public IActionResult GetTaglinks(ResourceParameters resourceParameters)
        {
            var data = _dataService.GetTaglinks(resourceParameters);
            return Ok(CreateLinkedResult(data));
        }

        [HttpGet("{id}", Name = nameof(GetTaglink))]
        public IActionResult GetTaglink(int postId)
        {
            Taglink taglink = null; // _dataService.GetTaglink(postId);
            if (taglink == null) return NotFound();
            return Ok(CreateLinks<TaglinkModel>(taglink));
        }

        private object CreateLinkedResult(PagedList<Taglink> data)
        {
            return new
            {
                Values = data.Select(CreateLinks<TaglinkModel>),
                Links = CreateLinks(data)
            };
        }

        private List<LinkModel> CreateLinks(PagedList<Taglink> data)
        {
            var links = new List<LinkModel>
            {
                CreateLinkModel(nameof(GetTaglinks), new {data.CurrentPage, data.PageSize}, "self", "GET")
            };

            if (data.HasPrev)
            {
                links.Add(CreateLinkModel(nameof(GetTaglinks), new { PageNumber = data.CurrentPage - 1, data.PageSize }, "prev_page", "GET"));
            }

            if (data.HasNext)
            {
                links.Add(CreateLinkModel(nameof(GetTaglinks), new { PageNumber = data.CurrentPage + 1, data.PageSize }, "next_page", "GET"));
            }

            return links;
        }
        private T CreateLinks<T>(Taglink taglink) where T : LinkedResourceModel
        {
            var routeValues = new { taglink.PostId, taglink.TagId };
            var model = Mapper.Map<T>(taglink);
            model.Url = CreateUrl(nameof(GetTaglink), routeValues);


            return model;
        }

        private LinkModel CreateLinkModel(string routeString, object routeValues, string rel, string method)
        {
            return new LinkModel { Href = CreateUrl(routeString, routeValues), Rel = rel, Method = method };
        }

        private string CreateUrl(string routeString, object routeValues)
        {
            return _urlHelper.Link(routeString, routeValues);
        }

    }
}
