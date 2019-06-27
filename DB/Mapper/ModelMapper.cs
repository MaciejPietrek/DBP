using DB.Model.Implementation;
using DB.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DB.Mapper
{
    static class ModelMapper
    {
        public static IMapper Mapper { get; } = new MapperConfiguration(cfg =>
        {
            //Building----------------------
            cfg.CreateMap<Budynki, BuildingModel>();
            cfg.CreateMap<BuildingModel, Budynki>();
            cfg.CreateMap<IBuildingModel, BuildingModel>();
            cfg.CreateMap<BuildingModel, IBuildingModel>();
            cfg.CreateMap<IBuildingModel, Budynki>();
            cfg.CreateMap<Budynki, IBuildingModel>();
            //Company-----------------------
            cfg.CreateMap<Firmy, CompanyModel>();
            cfg.CreateMap<CompanyModel, Firmy>();
            cfg.CreateMap<ICompanyModel, CompanyModel>();
            cfg.CreateMap<CompanyModel, ICompanyModel>();
            cfg.CreateMap<ICompanyModel, Firmy>();
            cfg.CreateMap<Firmy, ICompanyModel>();
            //Fault-------------------------
            cfg.CreateMap<Usterki, FaultModel>();
            cfg.CreateMap<FaultModel, Usterki>();
            cfg.CreateMap<IFaultModel, FaultModel>();
            cfg.CreateMap<FaultModel, IFaultModel>();
            cfg.CreateMap<IFaultModel, Usterki>();
            cfg.CreateMap<Usterki, IFaultModel>();
            //Flat--------------------------
            cfg.CreateMap<Mieszkania, FlatModel>();
            cfg.CreateMap<FlatModel, Mieszkania>();
            cfg.CreateMap<IFlatModel, FlatModel>();
            cfg.CreateMap<FlatModel, IFlatModel>();
            cfg.CreateMap<IFlatModel, Mieszkania>();
            cfg.CreateMap<Mieszkania, IFlatModel>();
            //RentalBill--------------------
            cfg.CreateMap<FakturyWynajem, RentalBillModel>();
            cfg.CreateMap<RentalBillModel, FakturyWynajem>();
            cfg.CreateMap<IRentalBillModel, RentalBillModel>();
            cfg.CreateMap<RentalBillModel, IRentalBillModel>();
            cfg.CreateMap<IRentalBillModel, FakturyWynajem>();
            cfg.CreateMap<FakturyWynajem, IRentalBillModel>();
            //Rental------------------------
            cfg.CreateMap<Wynajmy, RentalModel>();
            cfg.CreateMap<RentalModel, Wynajmy>();
            cfg.CreateMap<IRentalModel, RentalModel>();
            cfg.CreateMap<RentalModel, IRentalModel>();
            cfg.CreateMap<IRentalModel, Wynajmy>();
            cfg.CreateMap<Wynajmy, IRentalModel>();
            //RepairBill--------------------
            cfg.CreateMap<FakturyNapraw, RepairBillModel>();
            cfg.CreateMap<RepairBillModel, FakturyNapraw>();
            cfg.CreateMap<IRepairBillModel, RepairBillModel>();
            cfg.CreateMap<RepairBillModel, IRepairBillModel>();
            cfg.CreateMap<IRepairBillModel, FakturyNapraw>();
            cfg.CreateMap<FakturyNapraw, IRepairBillModel>();
            //Repair------------------------
            cfg.CreateMap<Naprawy, RepairModel>();
            cfg.CreateMap<RepairModel, Naprawy>();
            cfg.CreateMap<IRepairModel, RepairModel>();
            cfg.CreateMap<RepairModel, IRepairModel>();
            cfg.CreateMap<IRepairModel, Naprawy>();
            cfg.CreateMap<Naprawy, IRepairModel>();
            //Supervising-------------------
            cfg.CreateMap<Dozorowania, SupervisingModel>();
            cfg.CreateMap<SupervisingModel, Dozorowania>();
            cfg.CreateMap<ISupervisingModel, SupervisingModel>();
            cfg.CreateMap<SupervisingModel, ISupervisingModel>();
            cfg.CreateMap<ISupervisingModel, Dozorowania>();
            cfg.CreateMap<Dozorowania, ISupervisingModel>();
            //Supervisor--------------------
            cfg.CreateMap<Dozorcy, SupervisorModel>();
            cfg.CreateMap<SupervisorModel, Dozorcy>();
            cfg.CreateMap<ISupervisorModel, SupervisorModel>();
            cfg.CreateMap<SupervisorModel, ISupervisorModel>();
            cfg.CreateMap<ISupervisorModel, Dozorcy>();
            cfg.CreateMap<Dozorcy, ISupervisorModel>();
            //Tenant------------------------
            cfg.CreateMap<Najemcy, TenantModel>();
            cfg.CreateMap<TenantModel, Najemcy>();
            cfg.CreateMap<ITenantModel, TenantModel>();
            cfg.CreateMap<TenantModel, ITenantModel>();
            cfg.CreateMap<ITenantModel, Najemcy>();
            cfg.CreateMap<Najemcy, ITenantModel>();
        }).CreateMapper();
    }
}
