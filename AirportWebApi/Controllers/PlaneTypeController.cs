using AirportWebApi.BL.Services;
using AirportWebApi.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace AirportWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/planeTypes")]
    public class PlaneTypesController : Controller
    {
        private readonly IMapper mapper;
        private readonly BaseService service;

        public PlaneTypesController(IMapper mapper, BaseService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET api/v1/planeTypes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await Task.Run(() => service.GetAll<PlaneType>());
            if (items != null) return Ok(items);
            return NoContent();
        }

        // GET api/v1/planeTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var item = await Task.Run(() => service.GetById<PlaneType>(id));
                if (item != null) return Ok(item);
            }
            return NotFound();
        }


        // POST api/v1/planeTypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PlaneTypeDto value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Add(mapper.Map<PlaneTypeDto, PlaneType>(value)));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return BadRequest(); }
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/v1/planeTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]PlaneTypeDto value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Update(mapper.Map<PlaneTypeDto, PlaneType>(value)));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return BadRequest(); }
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: /api/v1/planeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Remove<PlaneType>(id));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return NoContent(); }
                return Ok();
            }
            return NotFound();
        }
    }
}