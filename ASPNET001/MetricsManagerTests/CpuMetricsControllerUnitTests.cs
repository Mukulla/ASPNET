using ASPNET001.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController cpu—ontroller;

        public CpuMetricsControllerUnitTests()
        {
            cpu—ontroller = new CpuMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = cpu—ontroller.GetMetricsFromAgent(agentId, fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetMetricsFromAllClusterFrist_ReturnsOk()
        {
            var result = cpu—ontroller.GetMetricsFromAllCluster(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(100), 12);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetMetricsFromAllClusterSecond_ReturnsOk()
        {
            var result = cpu—ontroller.GetMetricsFromAllCluster(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(100));

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController dotnet—ontroller;

        public DotNetMetricsControllerUnitTests()
        {
            dotnet—ontroller = new DotNetMetricsController();
        }

        [Fact]
        public void GetMetricsFromErrorsCount_ReturnsOk()
        {
            var result = dotnet—ontroller.GetErrorsCount(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(100));

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController hdd—ontroller;

        public HddMetricsControllerUnitTests()
        {
            hdd—ontroller = new HddMetricsController();
        }

        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var result = hdd—ontroller.GetLeftSpace();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
   
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController network—ontroller;

        public NetworkMetricsControllerUnitTests()
        {
            network—ontroller = new NetworkMetricsController();
        }


        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var result = network—ontroller.GetNetworkBandwidth(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(100));

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
 
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController ram—ontroller;

        public RamMetricsControllerUnitTests()
        {
            ram—ontroller = new RamMetricsController();
        }


        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var result = ram—ontroller.GetAvailableSpace();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
