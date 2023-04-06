using ERFDemo.Data;
using ERFDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERFDemo.Pages
{
	public class IndexModel : PageModel
	{
		private readonly PeopleContext _context;
		private readonly ILogger<IndexModel> _logger;
		public IndexModel(ILogger<IndexModel> logger, PeopleContext
context)
		{
			_logger = logger;
			_context = context;
		}

		public IList<Person> People { get; set; }
        public void OnGet()
        {
            People = _context.Person
            .Where(p => p.FirstName == "Adam").ToList();
        }

        [BindProperty]
        public Person Person { get; set; }
        public IActionResult OnPost()
        {
            People = _context.Person.ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Person.Add(Person);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}