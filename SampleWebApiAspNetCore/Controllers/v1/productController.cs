using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiAspNetCore.Repositories;
using System.Collections.Generic;
using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Helpers;
using System.Text.Json;

namespace SampleWebApiAspNetCore.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class productController : ControllerBase
    {
        private readonly IRepository _Repository;
        private readonly IUrlHelper _urlHelper;

        public productController(
            IUrlHelper urlHelper,
            IRepository Repository)
        {
            _Repository = Repository;
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = nameof(GetAllproducts))]
        public ActionResult GetAllproducts(ApiVersion version, [FromQuery] QueryParameters queryParameters)
        {
            List<productEntity> productItems = _Repository.GetAll(queryParameters).ToList();

            var allItemCount = _Repository.Count();

            var paginationMetadata = new
            {
                totalCount = allItemCount,
                pageSize = queryParameters.PageCount,
                currentPage = queryParameters.Page,
                totalPages = queryParameters.GetTotalPages(allItemCount)
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));


            var toReturn = productItems.ToList();

            return Ok(toReturn);
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingleproduct))]
        public ActionResult GetSingleproduct(ApiVersion version, int id)
        {
            productEntity productItem = _Repository.GetSingle(id);

            if (productItem == null)
            {
                return NotFound();
            }

            return Ok(productItem);
        }

        [HttpPost(Name = nameof(Addproduct))]
        public ActionResult<productEntity> Addproduct(ApiVersion version, [FromBody] productEntity productCreateDto)
        {
            if (productCreateDto == null)
            {
                return BadRequest();
            }


            _Repository.Add(productCreateDto);

            if (!_Repository.Save())
            {
                throw new Exception("Creating a productitem failed on save.");
            }

            productEntity newproductItem = _Repository.GetSingle(productCreateDto.id);

            return CreatedAtRoute(nameof(GetSingleproduct),
                new { version = version.ToString(), id = newproductItem.id },
                newproductItem);
        }

        [HttpDelete]
        [Route("{id:int}", Name = nameof(Removeproduct))]
        public ActionResult Removeproduct(int id)
        {
            productEntity productItem = _Repository.GetSingle(id);

            if (productItem == null)
            {
                return NotFound();
            }

            _Repository.Delete(id);

            if (!_Repository.Save())
            {
                throw new Exception("Deleting a productitem failed on save.");
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}", Name = nameof(Updateproduct))]
        public ActionResult<productEntity> Updateproduct(int id, [FromBody] productEntity productUpdateDto)
        {
            if (productUpdateDto == null)
            {
                return BadRequest();
            }


            var existingproductItem = _Repository.Update(id, productUpdateDto);

            if (!_Repository.Save())
            {
                throw new Exception("Updating a productitem failed on save.");
            }

            return Ok(existingproductItem);
        }

 

    }
}
