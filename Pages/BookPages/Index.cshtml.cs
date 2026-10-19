using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tulan_David_Lab2.Models;

namespace Tulan_David_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Tulan_David_Lab2Context _context;

    public IndexModel(Tulan_David_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public SelectList AuthorList { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    [Display(Name = "Author")]
    public int? SelectedAuthorID { get; set; }

    public async Task OnGetAsync()
    {
        AuthorList = new SelectList(
            _context.Author.Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }),
            "ID", "FullName");

        var books = _context.Book
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .AsQueryable();

        if (SelectedAuthorID.HasValue)
        {
            books = books.Where(b => b.AuthorID == SelectedAuthorID);
        }

        Book = await books.ToListAsync();
    }
}