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
    public class Student : IStudent
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
        public List<StudentModel> TableShow()
        {
            List<StudentModel> list = new List<StudentModel>();
            var res= _db.EmployeeTable.ToList();         
            foreach (var item in res)
            {
                list.Add(new StudentModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    PhoneNo = item.PhoneNo,
                    Address=item.Address,
                    Class=item.Class,
                    StudentId=item.StudentId,
                });
            }
            return list;
        }

        public void Edit(int Id)
        {
            
        }
        public async Task<StudentModel> Save(StudentModel obj,int Id)
        {
            var edititem = _db.EmployeeTable.Where(m => m.Id == Id).First();
            if (obj.Id == 0)
            {
                var res = await _db.EmployeeTable.AddAsync(obj);
                _db.SaveChanges();
                return res.Entity;
            }
            else
            {
                _db.Entry(obj).State = EntityState.Modified;
                _db.SaveChanges();
                return obj;
            }
            
        }
    }
}
