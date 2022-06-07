using _3TierProjects1.BAL;
using _3TierProjects2.Service.IServices;
using _3TierProjects2.Service.Repository;
using _3TierProjects3.DAL.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREPO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IStudent StudentServices;
        public ValuesController(IStudent _StudentServices)
        {
            this.StudentServices = _StudentServices;
        }


        [HttpGet]
        [Route("Test/GetDetail")]
        public List<StudentModel> GetAllMembers()
        {
            return StudentServices.TableShow();
        }
       

    }
}
