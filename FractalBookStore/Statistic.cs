using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FractalBookStore
{
    public class Statistic
    {
        public Task<decimal> LowPrice { get; set; }
        public Task<decimal> HighPrice { get; set; }
        public Task<Book> Newest { get; set; }
        public Task<Book> GetRandomRecommended { get; set; }
        public Task<Book> GetCheapest { get; set; }
        public Task<Book> GetDiscountest { get; set; }
    }
}