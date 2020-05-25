using Newtonsoft.Json;
using RoutesService.Domain;
using RoutesServices.Models;
using System;
using System.Collections.Generic;

namespace RouteServices.Domain
{
    public class RouteService : IRouteService
    {
        public const int initiatingTimeFromBusStop1 = 0;

        /// <summary>
        /// Build response for api implementation
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public string RetrieveNextArrivalTimes(Route route)
        {
            try
            {
                Dictionary<string, List<int>> resposne = new Dictionary<string, List<int>>();
                for (int i = 1; i <= 3; i++)
                {
                    List<string> departureTimes = new List<string>();
                    resposne.Add("Route " + i + " in", new List<int> {
                    CalculateNextArrivalTimes(route.RequestedDateTime, route.RequestedStopId, i),
                    CalculateNextArrivalTimes(route.RequestedDateTime, route.RequestedStopId, i) + 15
                });
                }
                return JsonConvert.SerializeObject(resposne);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>        
        /// Implement business logic for next two arrival times for requested bus stop
        /// </summary>
        /// <param name="requestedDateTime"></param>
        /// <param name="requestedStopId"></param>
        /// <param name="routeNumber"></param>
        /// <returns></returns>
        private int CalculateNextArrivalTimes(DateTime requestedDateTime, int requestedStopId, int routeNumber)
        {
            int mintues = (requestedDateTime.Hour * 60) + requestedDateTime.Minute;
            // Get the MOD value by dividing 15
            int nextIterationForStop1 = ((15 - (mintues % 15) + mintues) / 15) + 1;
            // Fn = x + 2r + 2s + 15n - 19
            int dipatureTimeInMins = initiatingTimeFromBusStop1 + 2 * (routeNumber) + 2 * (requestedStopId) + 15 * (nextIterationForStop1) - 19;
            return dipatureTimeInMins - mintues;
        }
    }
}
