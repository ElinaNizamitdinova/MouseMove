using Microsoft.AspNetCore.Mvc;
using Moq;
using MouseMovement.Presentation.Controllers;
using MouseMovementApp.Application;
using MouseMovementDomain.Domain;

namespace MouseMovementTest
{
    public class MoseMovementTest
    {

        [Fact]
        public async Task MouseDataIsNullPostTest()
        {
            var mockService = new Mock<MouseMovementService>(MockBehavior.Loose);
            var controller = new MouseDataController(mockService.Object);

            MouseDataDto mouseData = null;

            var result = await controller.Post(mouseData);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Mouse data cannot be null or empty.", badRequestResult.Value);
        }

        [Fact]
        public async Task MouseDataIsEmptyPostTest()
        {

            var mockService = new Mock<MouseMovementService>(MockBehavior.Loose);
            var controller = new MouseDataController(mockService.Object);

            var mouseData = new MouseDataDto
            {
                Coordinates = new List<long[]>()
            };

            var result = await controller.Post(mouseData);


            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Mouse data cannot be null or empty.", badRequestResult.Value);
        }
    }
}