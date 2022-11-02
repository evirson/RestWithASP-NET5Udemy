using Microsoft.AspNetCore.Mvc.Filters;

namespace EstudoRest.HyperMedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutedContext context);
        Task Enrich(ResultExecutedContext context);
    }
}
