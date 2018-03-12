using JeffCoUniversity.API.Controllers;
using JeffCoUniversity.DTO.Inbound;
using JeffCoUniversity.DTO.Outbound;
using JeffCoUniversity.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Results;
using System.Web.Http.Routing;

namespace JeffCoUniversity.Tests
{
    [TestClass]
    public class UnitTestInstructorController
    {
        List<InstructorOut> _instructorsOut;
        InstructorOut _instructorOut;
        InstructorWithCoursesIn _instructorWithCoursesIn;

        Mock<IInstructorService> _instructorServiceMock;
        Mock<HttpConfiguration> _configMock = new Mock<HttpConfiguration>();
        Mock<HttpRequestMessage> _requestMock = new Mock<HttpRequestMessage>();
        Mock<HttpRouteData> _routeDataMock;

        [TestInitialize]
        public void Setup()
        {
            _instructorOut = TestDataHelper.InstructorData.GetInstructorOut();
            _instructorsOut = TestDataHelper.InstructorData.GetInstructorsOut().ToList();
            _instructorWithCoursesIn = TestDataHelper.InstructorData.GetInstructorWithCoursesIn();

            _instructorServiceMock = new Mock<IInstructorService>();
            _requestMock = new Mock<HttpRequestMessage>(HttpMethod.Get, "http://localhost:54025");
        }

        [TestMethod]
        public async Task GetReturnsInstructorOut()
        {
            //Arrange
            var route = _configMock.Object.Routes.MapHttpRoute("default", "api/{controller}/{id}");
            _routeDataMock = new Mock<HttpRouteData>(route, new HttpRouteValueDictionary { { "controller", "Instructor" } });
            _instructorServiceMock.Setup(mock => mock.GetInstructor(3)).ReturnsAsync(() => _instructorOut);

            var controller = new InstructorController(_instructorServiceMock.Object);
            controller.ControllerContext = new HttpControllerContext(_configMock.Object, _routeDataMock.Object, _requestMock.Object);
            controller.Request = _requestMock.Object;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = _configMock.Object;

            //Act
            IHttpActionResult actionResult = await controller.Get(3);
            var contentResult = actionResult as OkNegotiatedContentResult<InstructorOut>;
            InstructorOut instructor = contentResult.Content as InstructorOut;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsInstanceOfType(instructor,typeof(InstructorOut));
            Assert.AreEqual(instructor.Id, 3);
        }

        [TestMethod]
        public async Task GetReturnsInstructorOutNotFound()
        {
            //Arrange
            var route = _configMock.Object.Routes.MapHttpRoute("default", "api/{controller}/{id}");
            _routeDataMock = new Mock<HttpRouteData>(route, new HttpRouteValueDictionary { { "controller", "Instructor" } });
            _instructorServiceMock.Setup(mock => mock.GetInstructor(3)).ReturnsAsync(() => _instructorOut);

            var controller = new InstructorController(_instructorServiceMock.Object);
            controller.ControllerContext = new HttpControllerContext(_configMock.Object, _routeDataMock.Object, _requestMock.Object);
            controller.Request = _requestMock.Object;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = _configMock.Object;

            //Act
            IHttpActionResult actionResult = await controller.Get(9999999);
            

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            
        }


        [TestMethod]
        public async Task GetReturnsCollectionOfInstructorOut()
        {
            //Arrange
            var route = _configMock.Object.Routes.MapHttpRoute("default", "api/{controller}/{id}");
            _routeDataMock = new Mock<HttpRouteData>(route, new HttpRouteValueDictionary { { "controller", "Instructor" } });

            _instructorServiceMock.Setup(mock => mock.GetAllInstructors()).ReturnsAsync(() => _instructorsOut);

            var controller = new InstructorController(_instructorServiceMock.Object)
            {
                ControllerContext = new HttpControllerContext(_configMock.Object, _routeDataMock.Object, _requestMock.Object),
                Request = _requestMock.Object
            };
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = _configMock.Object;
            
            //Act
            IHttpActionResult actionResult = await controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<InstructorOut>>;
            List<InstructorOut> instructors = contentResult.Content as List<InstructorOut>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(5, instructors.Count);
        }
    }
}
