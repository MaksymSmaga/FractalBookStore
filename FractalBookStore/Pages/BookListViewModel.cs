using FractalBookStore.DataTransferObjects;
using System.Collections;
using System.Collections.Generic;

namespace FractalBookStore.Web.Models.Pages
{
    public class BookListViewModel
    {
        public  IEnumerable <Book> Books { get; set; }

        
        
        public PagingInfo PagingInfo { get; set; }
    }
}
