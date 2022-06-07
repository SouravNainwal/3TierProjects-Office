using _3TierProjects2.Service.IServices;
using _3TierProjects3.DAL.model;
using System;
using System.Collections.Generic;

namespace _3TierProject.Services
{
    public class StudentService
    {
        private readonly IStudent _StudentServices;
        public StudentService(IStudent _StudentServices)
        {
            this._StudentServices = _StudentServices;
        }
        public List<StudentModel> Get()
        {
            var rat = _StudentServices.TableShow();
            return rat;
        }
        public StudentModel Set(StudentModel obj)
        {
            var res=_StudentServices.Save(obj);
            return res;
        }
        public bool DeleteStudent(int Id)
        {
            try
            {
                _StudentServices.delete(Id);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public bool EditStudent(StudentModel abj,int Id)
        {
            try
            {
                _StudentServices.Edit(abj,Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
