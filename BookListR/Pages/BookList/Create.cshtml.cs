using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListR.Model;

namespace BookListR.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public CBook Book { get; set; }
        public void OnGet()
        {
        }
        //public async Task<IActionResult> OnPost(CBook bookObj) we use Bindpropety to use the property we already have, post assumes that book is the object
        public async Task<IActionResult> OnPost()
        { 
             if(ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
