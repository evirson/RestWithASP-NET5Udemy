using EstudoRest.HyperMedia;
using EstudoRest.HyperMedia.Abstract;
using EstudoRest.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoRest.Model
{
    public class CadGruVO : ISupportsHyperMedia
    {
        public string CodGru { get; set; }
        public string NomGru { get; set; }
        public string NomFan { get; set; }
        public string Serial { get; set; }
        public int NumLoj { get; set; }
        public string Email { get; set; }
        public string EndSrv { get; set; }
        public int PrtSrv { get; set; }
        public string TipCob { get; set; }
        public string Observ { get; set; }
        public DateTime DatVen { get; set; }
        public string OldEndSrv { get; set; }
        public string EndFdb { get; set; }
        public string OndaEndSrv { get; set; }
        public int NumSrv { get; set; }
        public int IpInt { get; set; }
        public int TipSis { get; set; }
        public int SizFdb { get; set; }
        public int NumTrm { get; set; }
        public string VersaoWeb { get; set; }
        public string IpApp { get; set; }
        public string IpFdb { get; set; }
        public int SrvApp { get; set; }
        public int SrvFdb { get; set; }
        public string UsoVetor { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
