using _3TierProject.Services.Interface;
using _3TierProjects1.BAL;
using _3TierProjects3.DAL.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3TierProject.Services.Repository
{
   public class ApiStudent : IApiStudent
    {
        private readonly StudentContext _db;

        public ApiStudent(StudentContext db)
        {
            _db = db;
        }
        public void delete(int Id)
        {
            var deleteitem = _db.EmployeeTable.Where(m => m.Id == Id).First();
            _db.EmployeeTable.Remove(deleteitem);
            _db.SaveChanges();
        }

        public void Edit(StudentModel obj,int Id)
        {
            var edititem = _db.EmployeeTable.Where(m => m.Id == Id).First();
            if (obj.Id == 0)
            {
                Console.WriteLine("There is no ID in Database");
            }
            else
            {
                edititem.Id = obj.Id;
                edititem.Name = obj.Name;
                edititem.Email = obj.Email;
                edititem.PhoneNo = obj.PhoneNo;
                edititem.Address = obj.Address;
                edititem.Class = obj.Class;
                edititem.StudentId = obj.StudentId;

                _db.Entry(edititem).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void Save(StudentModel obj)
        {                    
                _db.EmployeeTable.AddAsync(obj);
                _db.SaveChanges();                           
        }

        public List<StudentModel> TableShow()
        {
            List<StudentModel> list = new List<StudentModel>();
            var res = _db.EmployeeTable.ToList();
            foreach (var item in res)
            {
                list.Add(new StudentModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    PhoneNo = item.PhoneNo,
                    Address = item.Address,
                    Class = item.Class,
                    StudentId = item.StudentId,
                });
            }
            return list;
        }
    }
}
