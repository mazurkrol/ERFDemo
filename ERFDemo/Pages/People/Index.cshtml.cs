using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERFDemo.Data;
using ERFDemo.Models;

namespace ERFDemo.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly ERFDemo.Data.PeopleContext _context;

        public IndexModel(ERFDemo.Data.PeopleContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Person != null)
            {
                Person = await _context.Person.ToListAsync();
            }
        }
    }
}
