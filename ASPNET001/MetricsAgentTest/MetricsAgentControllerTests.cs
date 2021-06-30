using MetricsAgent.Models;
using MetricsAgent.DAL;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTest
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController cpu�ontroller;
        private Mock<ICpuMetricsRepository> mock;

        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<ICpuMetricsRepository>();
            cpu�ontroller = new CpuMetricsController(mock.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            mock.Setup(repository =>
            repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            // ��������� �������� �� �����������
            var result = cpu�ontroller.Create(new
            MetricsAgent.Requests.CpuMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()),Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;
           
            var result = cpu�ontroller.GetCpuMetrics(fromTime, toTime);
            
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }
    
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController dotnet�ontroller;
        private Mock<IDotNetMetricsRepository> mock;


        public DotNetMetricsControllerUnitTests()
        {
            mock = new Mock<IDotNetMetricsRepository>();
            dotnet�ontroller = new DotNetMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            mock.Setup(repository =>
            repository.Create(It.IsAny<DotNetMetric>())).Verifiable();
            // ��������� �������� �� �����������
            var result = dotnet�ontroller.Create(new
            MetricsAgent.Requests.DotNetMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetMetricsFromErrorsCount_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = dotnet�ontroller.GetErrorsCount(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }

    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController hdd�ontroller;
        private Mock<IHddMetricsRepository> mock;


        public HddMetricsControllerUnitTests()
        {
            mock = new Mock<IHddMetricsRepository>();
            hdd�ontroller = new HddMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            mock.Setup(repository =>
            repository.Create(It.IsAny<HddMetric>())).Verifiable();
            // ��������� �������� �� �����������
            var result = hdd�ontroller.Create(new
            MetricsAgent.Requests.HddMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = hdd�ontroller.GetLeftSpace(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }

    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController network�ontroller;
        private Mock<INetworkMetricsRepository> mock;


        public NetworkMetricsControllerUnitTests()
        {
            mock = new Mock<INetworkMetricsRepository>();
            network�ontroller = new NetworkMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            mock.Setup(repository =>
            repository.Create(It.IsAny<NetworkMetric>())).Verifiable();
            // ��������� �������� �� �����������
            var result = network�ontroller.Create(new
            MetricsAgent.Requests.NetworkMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = network�ontroller.GetNetworkBandwidth(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }

    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController ram�ontroller;
        private Mock<IRamMetricsRepository> mock;


        public RamMetricsControllerUnitTests()
        {
            mock = new Mock<IRamMetricsRepository>();
            ram�ontroller = new RamMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            mock.Setup(repository =>
            repository.Create(It.IsAny<RamMetric>())).Verifiable();
            // ��������� �������� �� �����������
            var result = ram�ontroller.Create(new
            MetricsAgent.Requests.RamMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = ram�ontroller.GetAvailableSpace(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }
}
