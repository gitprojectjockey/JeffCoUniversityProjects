using JeffCoUniversity.DTO.Inbound;
using JeffCoUniversity.DTO.Outbound;
using JeffCoUniversity.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace JeffCoUniversity.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/jeffCoUniversity/Instructors")]
    public class InstructorController : ApiController
    {
        IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var instructorsOut = await _instructorService.GetAllInstructors();
             
            return new Helpers.ActionResultBuilder
                .CreateActionResult<IEnumerable<InstructorOut>>(Request, instructorsOut, System.Net.HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var instructorOut = await _instructorService.GetInstructor(id);

            if (instructorOut != null)
            {
                return new Helpers.ActionResultBuilder
                                  .CreateActionResult<InstructorOut>(Request, instructorOut, System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new Helpers.ActionResultBuilder
                                  .CreateActionResult<int>(Request, id, System.Net.HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("WithCourses")]
        public async Task<IHttpActionResult> GetInstructorsWithCourses()
        {
            var instructorsWithCoursesOut = await _instructorService.GetInstructorsWithCourses();
            return new Helpers.ActionResultBuilder
                              .CreateActionResult<IEnumerable<InstructorWithCoursesOut>>(Request, instructorsWithCoursesOut, System.Net.HttpStatusCode.OK);

        }

        [HttpGet]
        [Route("WithCourses/{id}")]
        public async Task<IHttpActionResult> GetInstructorWithCourses(int id)
        {
            var instructorWithCoursesOut = await _instructorService.GetInstructorWithCourses(id);

            if (instructorWithCoursesOut != null)
            {
                return new Helpers.ActionResultBuilder
                                  .CreateActionResult<InstructorWithCoursesOut>(Request, instructorWithCoursesOut, System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new Helpers.ActionResultBuilder
                  .CreateActionResult<int>(Request, id, System.Net.HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(InstructorWithCoursesIn instructorWithCoursesIn)
        {
            if (instructorWithCoursesIn == null)
            {
                return new Helpers.ActionResultBuilder
                             .CreateActionResult<InstructorWithCoursesIn>(Request, null, System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                _instructorService.CreateInstructor(instructorWithCoursesIn);
                return new Helpers.ActionResultBuilder
                             .CreateActionResult<InstructorWithCoursesIn>(Request, instructorWithCoursesIn, System.Net.HttpStatusCode.OK);
            }
        }

        [HttpPost]
        [Route("Range")]
        public IHttpActionResult Create(IEnumerable<InstructorWithCoursesIn> instructorsWithCoursesIn)
        {
            if (instructorsWithCoursesIn == null)
            {
                return new Helpers.ActionResultBuilder
                             .CreateActionResult<InstructorWithCoursesIn>(Request, null, System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                _instructorService.CreateInstructors(instructorsWithCoursesIn);
                return new Helpers.ActionResultBuilder
                             .CreateActionResult<IEnumerable<InstructorWithCoursesIn>>(Request, instructorsWithCoursesIn, System.Net.HttpStatusCode.OK);
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(InstructorWithCoursesIn instructorWithCoursesIn)
        {
            if (instructorWithCoursesIn == null)
            {
                return new Helpers.ActionResultBuilder
                             .CreateActionResult<InstructorWithCoursesIn>(Request, null, System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                _instructorService.UpdateInstructor(instructorWithCoursesIn);
                return new Helpers.ActionResultBuilder
                             .CreateActionResult<InstructorWithCoursesIn>(Request, instructorWithCoursesIn, System.Net.HttpStatusCode.OK);
            }
        }
    }
}
