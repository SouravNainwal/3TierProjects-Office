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
            if (obj.Id == 0)
            {
                _db.EmployeeTable.Add(obj);
                _db.SaveChanges();
            }
            else 
            {
                _db.EmployeeTable.Update(obj);
                _db.SaveChanges();
            }
        }
    }
}

