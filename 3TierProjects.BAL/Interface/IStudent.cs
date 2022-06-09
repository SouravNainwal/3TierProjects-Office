using _3TierProjects3.DAL.model;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3TierProjects2.Service.IServices
{
    public interface IStudent
    {
        List<StudentModel> TableShow();
        public void delete(int Id);
        public void Save(StudentModel obj);
        void Edit(StudentModel obj,int Id);

    }
}
