﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chat_App.Data;
using Chat_App.Models;
using Chat_App.services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class contactsController : ControllerBase
    {
        private readonly IContactService _service;

        public contactsController(Chat_AppContext context)
        {
            _service = new ContactService();
        }

        
        [HttpGet]
        public IEnumerable<Contact> Index()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public Contact Details(int? id)
        {
            var contact = _service.Get((int)id);
            return contact;
        }

        [HttpPost]
        public void Create([Bind("Id,Name,NickName,Messages,User")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _service.Create(contact.Name, contact.NickName, contact.Messages, contact.User);
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult Edit(int id, [Bind("Id,Name,NickName,Messages,User")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _service.Edit(id, contact.Name, contact.NickName, contact.Messages, contact.User);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //                throw;
        //        }
        //        return NoContent();
        //    }
        //    return BadRequest();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    if (_service.Get((int)id) == null)
        //    {
        //        return NotFound();
        //    }
        //    var contact = _service.Get((int)id);
        //    if (contact != null)
        //    {
        //        _service.Delete(id);
        //    }
        //    return NoContent();
        //}
    }
}
