using _3TierProjects3.DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3TierProject.Services.Interface
{
    public interface IApiStudent
    {
        List<StudentModel> TableShow();
        public void delete(int Id);
        public void Save(StudentModel obj);
        void Edit(StudentModel obj,int Id);
    }
}
