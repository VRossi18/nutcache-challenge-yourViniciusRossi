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
    public class DetailsModel : PageModel
    {
        private readonly PeopleManagment.Data.DataContext _context;

        public DetailsModel(PeopleManagment.Data.DataContext context)
        {
            _context = context;
        }

      public People People { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.peoples == null)
            {
                return NotFound();
            }

            var people = await _context.peoples.FirstOrDefaultAsync(m => m.Id == id);
            if (people == null)
            {
                return NotFound();
            }
            else 
            {
                People = people;
            }
            return Page();
        }
    }
}
