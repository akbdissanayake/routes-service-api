using Microsoft.AspNetCore.Mvc;
using RouteServices.Domain;
using RoutesService.Api.Controllers;
using RoutesService.Domain;
using RoutesServices.Models;
using System;
using Xunit;

namespace RoutesService.Tests
{
    public class RoutesControllerTest
    {
        RoutesController _controller;
        IRouteService _service;
        public RoutesControllerTest()
        {
            _service = new RouteService();
            _controller = new RoutesController(_service);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Route testRoute = new Route()
            {
                RequestedStopId = 1,
                RequestedDateTime = DateTime.Now
            };

            // Act
            var createdResponse = _controller.Post(testRoute);

            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
    }
}
