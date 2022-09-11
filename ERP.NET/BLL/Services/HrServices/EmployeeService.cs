using BLL.Entities;
using DAL.DataAccessFactory;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.HrServices
{
    public class EmployeeService
    {
        public static List<EmployeeModel> Get()
        {
            var data = DataAccessFactory.EmployeeDataAccess().Get();
            var employees = new List<EmployeeModel>();
            foreach(var e in data)
            {
                employees.Add(new EmployeeModel()
                  {
                    employee_id = e.employee_id,
                    employee_name = e.employee_name,
                    gender = e.gender,
                    supervisor = e.supervisor,
                    present_address = e.present_address,
                    phone = e.phone,
                    job_position = e.job_position,
                    employee_group = e.employee_group,
                    start_time = e.start_time,
                    end_time = e.end_time,
                    hours_worked = e.hours_worked,
                    employement_start_date = e.employement_start_date
                   });
            }
            return employees;
        }
        public static bool Create(EmployeeModel e)
        {
            var emp = new Employee();


            emp.employee_id = e.employee_id;

            emp.employee_name = e.employee_name;
            emp.gender = e.gender;
            emp.supervisor = e.supervisor;
            emp.present_address = e.present_address;
            emp.phone = e.phone;
            emp.job_position = e.job_position;
            emp.employee_group = "N/A";
            emp.start_time = e.start_time;
            emp.end_time = e.end_time;
            emp.hours_worked = e.hours_worked;
            emp.employement_start_date = e.employement_start_date;


            return DataAccessFactory.EmployeeDataAccess().Create(emp);
        }
        public static EmployeeModel Get(int id)
        {
            var e = DataAccessFactory.EmployeeDataAccess().Get(id);

            var employee = new EmployeeModel()
            {
                id = e.id,
                employee_id = e.employee_id,
                employee_name = e.employee_name,
                gender = e.gender,
                supervisor = e.supervisor,
                present_address = e.present_address,
                phone = e.phone,
                job_position = e.job_position,
                employee_group = e.employee_group,
                start_time = e.start_time,
                end_time = e.end_time,
                hours_worked = e.hours_worked,
                employement_start_date = e.employement_start_date
            };
            return employee;

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.EmployeeDataAccess().Delete(id);
        }
        public static bool Update(EmployeeModel e)
        {
            var employee = new Employee()
            {
                id = e.id,
                employee_id = e.employee_id,
                employee_name = e.employee_name,
                gender = e.gender,
                supervisor = e.supervisor,
                present_address = e.present_address,
                phone = e.phone,
                job_position = e.job_position,
                employee_group = e.employee_group,
                start_time = e.start_time,
                end_time = e.end_time,
                hours_worked = e.hours_worked,
                employement_start_date = e.employement_start_date
            };
            return DataAccessFactory.EmployeeDataAccess().Update(employee);
        }
    }
}
