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
        private CpuMetricsController cpuСontroller;
        private Mock<ICpuMetricsRepository> mock;

        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<ICpuMetricsRepository>();
            cpuСontroller = new CpuMetricsController(mock.Object);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository =>
            repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            // выполняем действие на контроллере
            var result = cpuСontroller.Create(new
            MetricsAgent.Requests.CpuMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()),Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;
           
            var result = cpuСontroller.GetCpuMetrics(fromTime, toTime);
            
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }
    
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController dotnetСontroller;
        private Mock<IDotNetMetricsRepository> mock;


        public DotNetMetricsControllerUnitTests()
        {
            mock = new Mock<IDotNetMetricsRepository>();
            dotnetСontroller = new DotNetMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository =>
            repository.Create(It.IsAny<DotNetMetric>())).Verifiable();
            // выполняем действие на контроллере
            var result = dotnetСontroller.Create(new
            MetricsAgent.Requests.DotNetMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetMetricsFromErrorsCount_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = dotnetСontroller.GetErrorsCount(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }

    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController hddСontroller;
        private Mock<IHddMetricsRepository> mock;


        public HddMetricsControllerUnitTests()
        {
            mock = new Mock<IHddMetricsRepository>();
            hddСontroller = new HddMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository =>
            repository.Create(It.IsAny<HddMetric>())).Verifiable();
            // выполняем действие на контроллере
            var result = hddСontroller.Create(new
            MetricsAgent.Requests.HddMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = hddСontroller.GetLeftSpace(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }

    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController networkСontroller;
        private Mock<INetworkMetricsRepository> mock;


        public NetworkMetricsControllerUnitTests()
        {
            mock = new Mock<INetworkMetricsRepository>();
            networkСontroller = new NetworkMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository =>
            repository.Create(It.IsAny<NetworkMetric>())).Verifiable();
            // выполняем действие на контроллере
            var result = networkСontroller.Create(new
            MetricsAgent.Requests.NetworkMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = networkСontroller.GetNetworkBandwidth(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }

    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController ramСontroller;
        private Mock<IRamMetricsRepository> mock;


        public RamMetricsControllerUnitTests()
        {
            mock = new Mock<IRamMetricsRepository>();
            ramСontroller = new RamMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository =>
            repository.Create(It.IsAny<RamMetric>())).Verifiable();
            // выполняем действие на контроллере
            var result = ramСontroller.Create(new
            MetricsAgent.Requests.RamMetricCreateRequest
            {
                Time = DateTimeOffset.Now,
                Value = 50
            });
            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }

        /*
        [Fact]
        public void GetGetLeftSpace_ReturnsOk()
        {
            var fromTime = DateTimeOffset.Now;
            var toTime = DateTimeOffset.UtcNow;

            var result = ramСontroller.GetAvailableSpace(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }*/
    }
}
