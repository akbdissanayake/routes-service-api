using RoutesServices.Models;

namespace RoutesService.Domain
{
    public interface IRouteService
    {
        public string RetrieveNextArrivalTimes(Route route);
    }
}
