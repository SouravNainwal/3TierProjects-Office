using _3TierProjects2.Service.IServices;
using _3TierProjects3.DAL.model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient.Memcached;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace _3TierProjectapi.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IStudent _StudentServices;
        public ValuesController(IStudent _StudentServices)
        {
            this._StudentServices = _StudentServices;
        }
        [HttpGet]
        [Route("Test/GetDetail")]
        public List<StudentModel> Get()
        {
            var rat = _StudentServices.TableShow();
            return rat;
        }
        [HttpPost]
        [Route("Test/SetDetail")]
        public StudentModel AddPerson(StudentModel obj)
        {           
             return  _StudentServices.Save(obj);                    
        }
    
    }
}
