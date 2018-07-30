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
    [Route("api/v1/flightAttendants")]
    public class FlightAttendantsController : Controller
    {
        private readonly IMapper mapper;
        private readonly BaseService service;

        public FlightAttendantsController(IMapper mapper, BaseService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET api/v1/flightAttendants
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await Task.Run(() => service.GetAll<FlightAttendant>());
            if (items != null) return Ok(items);
            return NoContent();
        }

        // GET api/v1/flightAttendants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var item = await Task.Run(() => service.GetById<FlightAttendant>(id));
                if (item != null) return Ok(item);
            }
            return NotFound();
        }


        // POST api/v1/flightAttendants
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FlightAttendantDto value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Add(mapper.Map<FlightAttendantDto, FlightAttendant>(value)));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return BadRequest(); }
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/v1/flightAttendants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]FlightAttendantDto value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Update(mapper.Map<FlightAttendantDto, FlightAttendant>(value)));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return BadRequest(); }
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: /api/v1/flightAttendants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Remove<FlightAttendant>(id));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return NoContent(); }
                return Ok();
            }
            return NotFound();
        }
    }
}