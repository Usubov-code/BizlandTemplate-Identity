using BizlandTemplate.Data;
using BizlandTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizlandTemplate.ViewComponents
{
    public class VcContact:ViewComponent
    {
        private readonly AppDbContext _context;

        public VcContact(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            Contact contacts = await _context.Contacts.FirstOrDefaultAsync();


            return View(contacts);
        }
    }
}
