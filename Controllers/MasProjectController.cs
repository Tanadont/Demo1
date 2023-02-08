using Demo1.Models;
using Demo1.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Demo1.Controllers
{
    [Route("v1/[controller]")]
    public class MasProjectController : Controller
    {
        private readonly IMasProject masProject;

        public MasProjectController(IMasProject masProject)
        {
            this.masProject = masProject;
        }

        [HttpGet()]
        public ApiResponse GetAll(Models.Query query)
        {
            return masProject.GetAll(query);
        }

        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            return masProject.Get(id);
        }
    }
}
