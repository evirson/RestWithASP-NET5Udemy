using EstudoRest.Data.Converter.Contract;
using EstudoRest.Data.VO;
using EstudoRest.Model;
using System.Drawing;

namespace EstudoRest.Data.Converter.Implementations
{
    public class CadGruConverter : IParser<CadGruVO, CadGru>, IParser<CadGru, CadGruVO>
    {
        public CadGru Parse(CadGruVO origin)
        {
            if (origin == null) return null;
            return new CadGru
            {
                CodGru= origin.CodGru,
                NomGru= origin.NomGru,
                NomFan= origin.NomFan
                /*,
                Serial= origin.Serial,
                NumLoj= origin.NumLoj,
                Email= origin.Email,
                EndSrv= origin.EndSrv,
                PrtSrv= origin.PrtSrv,
                TipCob= origin.TipCob,
                Observ= origin.Observ,
                DatVen= origin.DatVen,
                OldEndSrv= origin.OldEndSrv,
                EndFdb= origin.EndFdb,
                OndaEndSrv= origin.OndaEndSrv,
                NumSrv= origin.NumSrv,
                IpInt= origin.IpInt,
                TipSis= origin.TipSis,
                SizFdb= origin.SizFdb,
                NumTrm= origin.NumTrm,
                VersaoWeb= origin.VersaoWeb,
                IpApp= origin.IpApp,
                IpFdb= origin.IpFdb,
                SrvApp= origin.SrvApp,
                SrvFdb= origin.SrvFdb,
                UsoVetor= origin.UsoVetor*/
            };
        }

        public List<CadGru> Parse(List<CadGruVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();

        }

        public CadGruVO Parse(CadGru origin)
        {
            if (origin == null) return null;
            return new CadGruVO
            {
                CodGru = origin.CodGru,
                NomGru = origin.NomGru,
                NomFan = origin.NomFan
                /*,
                Serial = origin.Serial,
                NumLoj = origin.NumLoj,
                Email = origin.Email,
                EndSrv = origin.EndSrv,
                PrtSrv = origin.PrtSrv,
                TipCob = origin.TipCob,
                Observ = origin.Observ,
                DatVen = origin.DatVen,
                OldEndSrv = origin.OldEndSrv,
                EndFdb = origin.EndFdb,
                OndaEndSrv = origin.OndaEndSrv,
                NumSrv = origin.NumSrv,
                IpInt = origin.IpInt,
                TipSis = origin.TipSis,
                SizFdb = origin.SizFdb,
                NumTrm = origin.NumTrm,
                VersaoWeb = origin.VersaoWeb,
                IpApp = origin.IpApp,
                IpFdb = origin.IpFdb,
                SrvApp = origin.SrvApp,
                SrvFdb = origin.SrvFdb,
                UsoVetor = origin.UsoVetor */

            };
        }

        public List<CadGruVO> Parse(List<CadGru> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
    