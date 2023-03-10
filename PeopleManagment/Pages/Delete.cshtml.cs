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
    public class DeleteModel : PageModel
    {
        private readonly PeopleManagment.Data.DataContext _context;

        public DeleteModel(PeopleManagment.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.peoples == null)
            {
                return NotFound();
            }
            var people = await _context.peoples.FindAsync(id);

            if (people != null)
            {
                People = people;
                _context.peoples.Remove(People);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
