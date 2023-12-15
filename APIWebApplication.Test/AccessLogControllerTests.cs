using APIWebApplication.Controllers;
using APIWebApplication.DTO.Response;
using APIWebApplication.Interfaces;
using APIWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace APIWebApplication.Tests
{
    /// <summary>
    /// Unit tests for the AccessLogController class.
    /// </summary>
    public class AccessLogControllerTests
    {
        private readonly Mock<IAccessLogService> _mockService;
        private readonly AccessLogController _controller;

        public AccessLogControllerTests()
        {
            _mockService = new Mock<IAccessLogService>();
            _controller = new AccessLogController(_mockService.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WithAccessLogs()
        {
            // Arrange
            var fakeAccessLogs = new List<AccessLogResponse> { /* ... populate test data ... */ };
            _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(fakeAccessLogs);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<AccessLogResponse>>(okResult.Value);
            Assert.Equal(fakeAccessLogs, returnValue);
        }

        // Additional tests for GetByIdAsync, CreatAsync, DeletAsync, UpdateAsync...
    }
}
