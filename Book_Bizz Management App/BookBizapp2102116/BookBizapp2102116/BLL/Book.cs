using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBizapp2102116.BLL
{
    public class Book
    {
        public int ISBN { get; set; }
        
    
        
        public string Title { get; set; }
        public int UnitPrice { get; set; }
        public int YearPublished { get; set; }
        public int QOH { get; set; }

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
