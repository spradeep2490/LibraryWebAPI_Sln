using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LibraryWebAPI_Prj.Entities
{
    public class Books
    {
        [Key]
        public int Code { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public char Is_Available { get; set; }
        public decimal Price { get; set; }
        public int RackCode { get; set; }
        [AllowNull]
        public string RackID { get; set; }
        public int ShelfCode { get; set; }
        [AllowNull]
        public string ShelfID { get; set; }

        public char DeleteFlag { get; set; }

    }
}
