using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{

    public class AgentsControllerUnitTests
    {
        private AgentsController agents—ontroller;

        public AgentsControllerUnitTests()
        {
            agents—ontroller = new AgentsController();
        }

        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            var agentInfo = new AgentInfo();

            var result = agents—ontroller.RegisterAgent(agentInfo);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            var agentId = 1;

            var result = agents—ontroller.EnableAgentById(agentId);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            var agentId = 1;

            var result = agents—ontroller.DisableAgentById(agentId);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllClusterFrist_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = agents—ontroller.GetMetricsFromAllCluster(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }



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
            var agentId = 1;
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;
           
            var result = cpu—ontroller.GetMetricsFromAgent(agentId, fromTime, toTime);
            
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetMetricsFromAllClusterFrist_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = cpu—ontroller.GetMetricsFromAllCluster(fromTime, toTime);

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
            var agentId = 1;
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = dotnet—ontroller.GetMetricsFromAgent(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllClusterFrist_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = dotnet—ontroller.GetMetricsFromAllCluster(fromTime, toTime);

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
            var agentId = 1;
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = hdd—ontroller.GetMetricsFromAgent(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllClusterFrist_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = hdd—ontroller.GetMetricsFromAllCluster(fromTime, toTime);

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
            var agentId = 1;
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = network—ontroller.GetMetricsFromAgent(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllClusterFrist_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = network—ontroller.GetMetricsFromAllCluster(fromTime, toTime);

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
            var agentId = 1;
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = ram—ontroller.GetMetricsFromAgent(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllClusterFrist_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = ram—ontroller.GetMetricsFromAllCluster(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
