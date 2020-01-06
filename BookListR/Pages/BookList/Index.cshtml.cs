using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListR.Model;
using Microsoft.EntityFrameworkCore;

namespace BookListR.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<CBook> Books { get; set; }
        public async Task OnGet()
        {
            // we are going to database and retrieving all of the books storing them in the Ienumerable all of this inside the get handler
            Books = await _db.Book.ToListAsync(); 
        }
    }
} 
