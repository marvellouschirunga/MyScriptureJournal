using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SortBy { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from m in _context.Entry
                                            orderby m.Book
                                            select m.Book;


            var entries = from m in _context.Entry
                         select m;


            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.Notes.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(Book))
            {
                entries = entries.Where(x => x.Book == Book);
            }

            if (!string.IsNullOrEmpty(SortBy))
            {
                if(SortBy == "book")
                {
                    entries = entries.OrderBy(e => e.Book);
                }

                if(SortBy == "date")
                {
                    entries = entries.OrderBy(e => e.AddedDate);
                }
            }

            Genres = new SelectList(await bookQuery.Distinct().ToListAsync());
            Entry = await entries.ToListAsync();
        }

        
    }
}
