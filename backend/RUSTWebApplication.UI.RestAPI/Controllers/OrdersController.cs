﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RUSTWebApplication.Core.Entity.Order;
using RUSTWebApplication.Core.ApplicationService;

namespace RUSTWebApplication.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;


        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET api/orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                return Ok(_orderService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            try
            {
                return Ok(_orderService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


		// POST api/orders
		[HttpPost]
        public ActionResult<Order> Post([FromBody] Order value)
        {
            try
            {
                return Ok(_orderService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }		
        }

		// PUT api/orders/5
		[Authorize(Roles = "Administrator")]
		[HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order value)
        {
            try
            {
                if (id != value.Id)
                {
                    return Conflict("Parameter ID does not match Order id");
                }
                return Ok(_orderService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		// DELETE api/orders/5
		[Authorize(Roles = "Administrator")]
		[HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            Order deletedOrder = _orderService.Delete(id);
            if (deletedOrder == null)
            {
                return NotFound($"Did not find Order with ID: {id}");
            }
            return Ok(deletedOrder);
        }


    }
}
