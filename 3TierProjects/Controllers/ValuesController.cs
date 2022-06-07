using _3TierProject.Services;
using _3TierProjects3.DAL.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace _3TierProjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly StudentService    StServices;
        public ValuesController(StudentService _StudentServices)
        {
            this.StServices = _StudentServices;
        }
        [HttpGet]
        [Route("Test/GetDetail")]
        public List<StudentModel> GetDetail()
        {
            var rat = StServices.Get();
            return rat;
        }
        [HttpPost]
        [Route("Test/SetDetail")]
        public bool SetDetail(StudentModel obj)
        {
             
            try
            {
                StServices.Set(obj);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [HttpDelete]
        [Route("Test/DeleteDetail")]
        public bool DeleteDetail(int Id)
        {
            try
            {
                StServices.DeleteStudent(Id);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        [HttpPut]
        [Route("Test/UpdateDetail")]
        public bool UpdateDetail(StudentModel abj, int Id)
        {
            try
            {
                StServices.EditStudent(abj,Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
