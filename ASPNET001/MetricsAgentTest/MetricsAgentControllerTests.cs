using MetricsAgent;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTest
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
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;
           
            var result = cpu—ontroller.GetCpuMetrics(fromTime, toTime);
            
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
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = dotnet—ontroller.GetErrorsCount(fromTime, toTime);

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
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = hdd—ontroller.GetLeftSpace(fromTime, toTime);

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
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = network—ontroller.GetNetworkBandwidth(fromTime, toTime);

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
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = ram—ontroller.GetAvailableSpace(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
