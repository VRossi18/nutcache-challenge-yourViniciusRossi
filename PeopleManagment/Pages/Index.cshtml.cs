using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeopleManagment.Data;
using PeopleManagment.Models;

namespace PeopleManagment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PeopleManagment.Data.DataContext _context;

        public IndexModel(PeopleManagment.Data.DataContext context)
        {
            _context = context;
        }

        public IList<People> People { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.peoples != null)
            {
                People = await _context.peoples.ToListAsync();
            }
        }
    }
}
