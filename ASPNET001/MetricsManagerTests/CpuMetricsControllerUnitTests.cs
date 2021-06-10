using ASPNET001.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController CpuController;

        public CpuMetricsControllerUnitTests()
        {
            CpuController = new CpuMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = CpuController.GetMetricsFromAgent(agentId, fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetMetricsFromAllClusterFrist_ReturnsOk()
        {
            var result = CpuController.GetMetricsFromAllCluster(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(100), 12);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetMetricsFromAllClusterSecond_ReturnsOk()
        {
            var result = CpuController.GetMetricsFromAllCluster(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(100));

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController DotNetController;

        public DotNetMetricsControllerUnitTests()
        {
            DotNetController = new DotNetMetricsController();
        }

        [Fact]
        public void GetMetricsFromErrorsCount_ReturnsOk()
        {
            var result = DotNetController.GetErrorsCount(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(100));

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }

    
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController HddController;

        public HddMetricsControllerUnitTests()
        {
            HddController = new HddMetricsController();
        }

        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var result = HddController.GetLeftSpace();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
   
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController NetworkController;

        public NetworkMetricsControllerUnitTests()
        {
            NetworkController = new NetworkMetricsController();
        }


        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var result = NetworkController.GetNetworkBandwidth(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(100));

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
 
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController RamController;

        public RamMetricsControllerUnitTests()
        {
            RamController = new RamMetricsController();
        }


        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var result = RamController.GetAvailableSpace();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
