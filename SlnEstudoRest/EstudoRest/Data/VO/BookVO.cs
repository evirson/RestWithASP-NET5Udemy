using EstudoRest.HyperMedia;
using EstudoRest.HyperMedia.Abstract;
using EstudoRest.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoRest.Model
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime Launch_Date { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; }
    }
}
