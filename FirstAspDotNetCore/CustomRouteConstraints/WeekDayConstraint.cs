using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FirstAspDotNetCore.CustomRouteConstraints
{
    public class WeekDayConstraint : IRouteConstraint
    {
        private string[] _daysOfWeek =  {"sat", "sun", "mon", "tue", "wed", "thu","fri"};
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return _daysOfWeek.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}
