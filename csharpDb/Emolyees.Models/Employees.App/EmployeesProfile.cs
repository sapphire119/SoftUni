namespace Employees.App
{
    using AutoMapper;
    using Employees.Models;
    using Employees.App.ModelsDto;

    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            //ManagerDto
            CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.Employees, config =>
                            config.MapFrom(e => e.Employees));

            CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.EmployeeCount, config =>
                            config.MapFrom(e => e.Employees.Count));

            //EmployeeDto
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.FirstName,
                            confg => confg.MapFrom(emp => emp.FirstName));

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.LastName,
                            confg => confg.MapFrom(emp => emp.LastName));

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.Salary,
                            confg => confg.MapFrom(emp => emp.Salary));

            //EmployeeDto Ignore
            CreateMap<EmployeeDto, Employee>()
                .ForMember(e => e.Birthday, opt => opt.Ignore());

            CreateMap<EmployeeDto, Employee>()
                .ForMember(e => e.Address, opt => opt.Ignore());

            //EmployeeManagerIdDto
            CreateMap<Employee, EmployeeManagerIdDto>()
                .ForMember(dto => dto.ManagerId, config =>
                            config.MapFrom(e => e.ManagerId));
        }
    }
}
