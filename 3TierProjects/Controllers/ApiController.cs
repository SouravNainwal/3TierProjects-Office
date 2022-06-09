using _3TierProjects2.Service.IServices;
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
    //[Route("api/[controller]")]
    //[ApiController]
    public class ApiController : ControllerBase
    {
        readonly IStudent _StudentServices;
        public ApiController(IStudent _StudentServices)
        {
            this._StudentServices = _StudentServices;
        }
        [HttpGet]
        [Route("Test/GetDetail")]
        public List<StudentModel> GetDetail()
        {
                var rat = _StudentServices.TableShow();
                return rat;            
        }
        [HttpPost]
        [Route("Api/SetDetail")]
        public bool  SetDetail(StudentModel obj)
        {
            try
            {
                 _StudentServices.Save(obj);
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
                _StudentServices.delete(Id);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        [HttpPut]
        [Route("Test/UpdateDetail")]
        public bool UpdateDetail(StudentModel obj,int Id)
        {
            try
            {
                _StudentServices.Edit(obj,Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }   
        
    }
}
