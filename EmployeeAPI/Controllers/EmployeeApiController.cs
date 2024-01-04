using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class EmployeeApiController : ApiController
    {
        EmployeeEntities db = new EmployeeEntities();

        public string Post(empDetail emp)
        {
            try
            {
                db.empDetails.Add(emp);
                db.SaveChanges();
                return "Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<empDetail> Get()
        {
            return db.empDetails.ToList();
        }

        public empDetail Get(int id)
        {
            empDetail emp = db.empDetails.Find(id);
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }

        public string Put(int id, empDetail emp)
        {
            try
            {
                var empPresent = db.empDetails.Find(id);

                if (empPresent != null)
                {
                    empPresent.empName = emp.empName;
                    empPresent.empPlace = emp.empPlace;
                    empPresent.empName = emp.empName;
                    empPresent.empSalary = emp.empSalary;
                    db.SaveChanges();
                    return "Updated Successfully";
                }
                else
                {
                    return "Details not found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Delete(int id)
        {
            try
            {
                empDetail emp = db.empDetails.Find(id);
                if (emp != null)
                {
                    db.empDetails.Remove(emp);
                    db.SaveChanges();
                    return "Deleted Successfully";
                }
                else
                {
                    return "Details not found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
