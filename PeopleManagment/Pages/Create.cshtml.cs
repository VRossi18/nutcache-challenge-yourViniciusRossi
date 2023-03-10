using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PeopleManagment.Data;
using PeopleManagment.Models;

namespace PeopleManagment.Pages
{
    public class CreateModel : PageModel
    {
        private readonly PeopleManagment.Data.DataContext _context;

        public CreateModel(PeopleManagment.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public People People { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.peoples.Add(People);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
