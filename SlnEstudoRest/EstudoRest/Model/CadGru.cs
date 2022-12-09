using EstudoRest.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoRest.Model
{
    [Table("cadgru")]
    public class CadGru 
    {
        [Key]
        [Column("CODGRU")]
        public string CodGru { get; set; }
        [Column("NOMGRU")]
        public string NomGru { get; set; }
        [Column("NOMFAN")]
        public string NomFan { get; set; }
        [Column("SERIAL")]
        public string Serial { get; set; }
        [Column("NUMLOJ")]
        public int NumLoj { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("ENDSRV")]
        public string EndSrv { get; set; }
        [Column("PRTSRV")]
        public int PrtSrv { get; set; }
        [Column("TIPCOB")]
        public string TipCob { get; set; }
        [Column("OBSERV")]
        public string Observ { get; set; }
        [Column("DATVEN")]
        public DateTime DatVen { get; set; }
        [Column("OLD_ENDSRV")]
        public string OldEndSrv { get; set; }
        [Column("ENDFDB")]
        public string EndFdb { get; set; }
        [Column("ONDA_ENDSRV")]
        public string OndaEndSrv { get; set; }
        [Column("NUMSRV")]
        public int NumSrv { get; set; }
        [Column("IP_INT")]
        public int IpInt { get; set; }
        [Column("TIPSIS")]
        public int TipSis { get; set; }
        [Column("SIZFDB")]
        public int SizFdb { get; set; }
        [Column("NUMTRM")]
        public int NumTrm { get; set; }
        [Column("VERSAO_WEB")]
        public string VersaoWeb { get; set; }
        [Column("IP_APP")]
        public string IpApp { get; set; }
        [Column("IP_FDB")]
        public string IpFdb { get; set; }
        [Column("SRVAPP")]
        public int SrvApp { get; set; }
        [Column("SRVFDB")]
        public int SrvFdb { get; set; }
        [Column("USO_VETOR")]
        public string UsoVetor { get; set; }    

    }
}
