using Tulan_David_Lab2.Models;

namespace Tulan_David_Lab2.ViewModels
{
    public class CategoryIndexData
    {

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }

    }
}