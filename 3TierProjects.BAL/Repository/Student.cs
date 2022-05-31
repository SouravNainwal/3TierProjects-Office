using _3TierProjects1.BAL;
using _3TierProjects2.Service.IServices;
using _3TierProjects3.DAL.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3TierProjects2.Service.Repository
{
    public class Student:IStudent
    {
        private readonly StudentContext _db;

        public Student(StudentContext db)
        {
            _db = db;
        }

        public void delete(int Id)
        {
            var deleteitem = _db.EmployeeTable.Where(m => m.Id == Id).First();
            _db.EmployeeTable.Remove(deleteitem);
            _db.SaveChanges();

            //return _db.EmployeeTable.ToList();

        }


        public void Save(StudentModel obj)
        {
            if (obj.Id == 0)
            {
                _db.EmployeeTable.Add(obj);
                _db.SaveChanges();
            }
            else
            {
                _db.Entry(obj).State = EntityState.Modified;
                _db.SaveChanges();
            }

        }



        public List<StudentModel> TableShow()
        {
            //var res = _db.EmployeeTable.ToList();
            return _db.EmployeeTable.ToList();

        }

        public StudentModel Edit(StudentModel abj, int Id)
        {


            var edititem = _db.EmployeeTable.Where(m => m.Id == Id).FirstOrDefault();

            abj.Id = edititem.Id;
            abj.Name = edititem.Name;
            abj.Email = edititem.Email;
            abj.PhoneNo = edititem.PhoneNo;
            abj.Address = edititem.Address;
            abj.Class = edititem.Class;
            abj.StudentId = edititem.StudentId;

            return abj;

        }
    }
}
