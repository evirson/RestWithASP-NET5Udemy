using EstudoRest.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoRest.Model
{
    [Table("book")]
    public class Book :BaseEntity
     {
        [Column("author")] 
        public string Author { get; set; }
        [Column("launch_date")]
        public DateTime Launch_Date { get; set; }
        [Column("price")]
        public float Price { get; set; }
        [Column("title")]
        public string Title { get; set; }

    }
}
