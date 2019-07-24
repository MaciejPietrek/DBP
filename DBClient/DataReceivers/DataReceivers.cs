using DB.Model.Implementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClient.DataReceivers
{
    class CompanyDataReceiver : DataReceiver<CompanyModel>
    {
        public CompanyDataReceiver()
            : base("http://localhost:51950/api/Company")
        {

        }
    }

    class BuildingDataReceiver : DataReceiver<BuildingModel>
    {
        public BuildingDataReceiver()
            : base("http://localhost:51950/api/Building")
        {

        }
    }

    class FaultDataReceiver : DataReceiver<FaultModel>
    {
        public FaultDataReceiver()
            : base("http://localhost:51950/api/Fault")
        {

        }
    }

    class FlatDataReceiver : DataReceiver<FlatModel>
    {
        public FlatDataReceiver()
            : base("http://localhost:51950/api/Flat")
        {

        }
    }

    class RentalBillDataReceiver : DataReceiver<RentalBillModel>
    {
        public RentalBillDataReceiver()
            : base("http://localhost:51950/api/RentalBill")
        {

        }
    }

    class RentalDataReceiver : DataReceiver<RentalModel>
    {
        public RentalDataReceiver()
            : base("http://localhost:51950/api/Rental")
        {

        }
    }

    class RepairBilDataReceiver : DataReceiver<RepairBillModel>
    {
        public RepairBilDataReceiver()
            : base("http://localhost:51950/api/RepairBill")
        {

        }
    }

    class RepairDataReceiver : DataReceiver<RepairModel>
    {
        public RepairDataReceiver()
            : base("http://localhost:51950/api/Repair")
        {

        }
    }

    class SupervisingDataReceiver : DataReceiver<SupervisingModel>
    {
        public SupervisingDataReceiver()
            : base("http://localhost:51950/api/Supervising")
        {

        }
    }

    class SupervisorDataReceiver : DataReceiver<SupervisorModel>
    {
        public SupervisorDataReceiver()
            : base("http://localhost:51950/api/Supervisor")
        {

        }
    }

    class TenantDataReceiver : DataReceiver<TenantModel>
    {
        public TenantDataReceiver()
            : base("http://localhost:51950/api/Tenant")
        {

        }
    }
}
