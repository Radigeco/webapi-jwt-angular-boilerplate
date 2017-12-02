using System.Web.Http;
using Services.Interface;
using Services.ServiceModels;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/movie")]
    public class MovieController : BaseApiController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadAll()
        {
            var movies = _movieService.GetAll();
            return Ok(movies);
        }


        [HttpGet]
        [Route("getjoined")]
        public IHttpActionResult ReadAllJoined()
        {
            var movies = _movieService.GetJoined();
            return Ok(movies);
        }

        [HttpGet]
        [Route("mapperget")]
        public IHttpActionResult ReadAllMapped()
        {
            var movies = _movieService.MapperGetAll();
            return Ok(movies);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Read(int id)
        {
            var movie = _movieService.GetById(id);
            return Ok(movie);
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(MovieModel model)
        {
            var movie = _movieService.Add(model);
            return Ok(movie);
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(MovieModel model)
        {
            var movie = _movieService.Update(model);
            return Ok(movie);
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
    }
}
