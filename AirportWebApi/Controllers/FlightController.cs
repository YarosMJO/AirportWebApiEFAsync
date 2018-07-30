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
    [Route("api/v1/flights")]
    public class FlightsController : Controller
    {
        private readonly IMapper mapper;
        private readonly BaseService service;

        public FlightsController(IMapper mapper, BaseService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET api/v1/flights
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await Task.Run(() => service.GetAll<Flight>());
            if (items != null) return Ok(items);
            return NoContent();
        }

        // GET api/v1/flights/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var item = await Task.Run(() => service.GetById<Flight>(id));
                if (item != null) return Ok(item);
            }
            return NotFound();
        }


        // POST api/v1/flights
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FlightDto value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Add(mapper.Map<FlightDto, Flight>(value)));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return BadRequest(); }
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/v1/flights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]FlightDto value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Update(mapper.Map<FlightDto, Flight>(value)));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return BadRequest(); }
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: /api/v1/flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Remove<Flight>(id));
                    await service.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return NoContent();
                }
                return Ok();
            }
            return NotFound();
        }
    }
}