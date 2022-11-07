using Microsoft.AspNetCore.Mvc.Filters;

namespace EstudoRest.HyperMedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
