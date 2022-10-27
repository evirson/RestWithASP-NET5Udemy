using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoRest.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
