using AutoMapper;
using InfraKeep.Application.Shared.Employees;
using InfraKeep.Domain.Employees;

namespace InfraKeep.Application.Employees.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}