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
    [Route("api/v1/tickets")]
    public class TicketsController : Controller
    {
        private readonly IMapper mapper;
        private readonly BaseService service;

        public TicketsController(IMapper mapper, BaseService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET api/v1/tickets
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await Task.Run(() => service.GetAll<Ticket>());
            if (items != null) return Ok(items);
            return NoContent();
        }

        // GET api/v1/tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var item = await service.GetById<Ticket>(id);
                if (item != null) return Ok(item);
            }
            return NotFound();
        }


        // POST api/v1/tickets
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TicketDto value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.Add(mapper.Map<TicketDto, Ticket>(value));
                    await service.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return BadRequest();
                }
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/v1/tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]TicketDto value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.Update(mapper.Map<TicketDto, Ticket>(value));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return BadRequest(); }
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: /api/v1/tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await Task.Run(() => service.Remove<Ticket>(id));
                    await service.SaveChangesAsync();
                }
                catch (Exception) { return NoContent(); }
                return Ok();
            }
            return NotFound();
        }

    }
}