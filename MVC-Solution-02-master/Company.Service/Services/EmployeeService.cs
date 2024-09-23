using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Helper;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(EmployeeDto employeeDto)
        {
            // Manual Mapping
            //Employee employee = new Employee
            //{
            //    Name = employeeDto.Name,
            //    Age = employeeDto.Age,
            //    Address = employeeDto.Address,
            //    Salary = employeeDto.Salary,
            //    Email = employeeDto.Email,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    DepartmentId = employeeDto.DepartmentId



            //};

            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");

            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Add(employee);

            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Name = employeeDto.Name,
            //    Age = employeeDto.Age,
            //    Address = employeeDto.Address,
            //    Salary = employeeDto.Salary,
            //    Email = employeeDto.Email,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    DepartmentId = employeeDto.DepartmentId


            //};

            Employee employee = _mapper.Map<Employee>(employeeDto); 

            _unitOfWork.EmployeeRepository.Delete(employee);

            _unitOfWork.Complete();

        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();

            //var mappedEmployees = employees.Select(x => new EmployeeDto

            //{

            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    Id = x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    CreateAt = x.CreateAt
            //});

           IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);


            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {

            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee is null)
                return null;

            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Address = employee.Address,
            //    Salary = employee.Salary,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    HiringDate = employee.HiringDate,
            //    DepartmentId = employee.DepartmentId,
            //    ImageUrl = employee.ImageUrl,
            //    Id = employee.Id,
            //    CreateAt = employee.CreateAt


            //};

            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;

        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
          var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);

            //var mappedEmployees = employees.Select(x => new EmployeeDto

            //{

            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    Id = x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    CreateAt = x.CreateAt
            //});

            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployees;

        }
         

        public void Update(EmployeeDto employee)
        {
            throw new NotImplementedException();
        }
    }
}
