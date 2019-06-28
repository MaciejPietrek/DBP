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

    class BuildingDataReceiver : DataReceiver<CompanyModel>
    {
        public BuildingDataReceiver()
            : base("http://localhost:51950/api/Building")
        {

        }
    }

    class FaultDataReceiver : DataReceiver<CompanyModel>
    {
        public FaultDataReceiver()
            : base("http://localhost:51950/api/Fault")
        {

        }
    }

    class FlatDataReceiver : DataReceiver<CompanyModel>
    {
        public FlatDataReceiver()
            : base("http://localhost:51950/api/Flat")
        {

        }
    }

    class RentalBillDataReceiver : DataReceiver<CompanyModel>
    {
        public RentalBillDataReceiver()
            : base("http://localhost:51950/api/RentalBill")
        {

        }
    }

    class RentalDataReceiver : DataReceiver<CompanyModel>
    {
        public RentalDataReceiver()
            : base("http://localhost:51950/api/RentalData")
        {

        }
    }

    class RepairBilDataReceiver : DataReceiver<CompanyModel>
    {
        public RepairBilDataReceiver()
            : base("http://localhost:51950/api/RepairBill")
        {

        }
    }

    class RepairDataReceiver : DataReceiver<CompanyModel>
    {
        public RepairDataReceiver()
            : base("http://localhost:51950/api/Repai")
        {

        }
    }

    class SupervisingDataReceiver : DataReceiver<CompanyModel>
    {
        public SupervisingDataReceiver()
            : base("http://localhost:51950/api/Supervising")
        {

        }
    }

    class SupervisorDataReceiver : DataReceiver<CompanyModel>
    {
        public SupervisorDataReceiver()
            : base("http://localhost:51950/api/Supervisor")
        {

        }
    }

    class TenantDataReceiver : DataReceiver<CompanyModel>
    {
        public TenantDataReceiver()
            : base("http://localhost:51950/api/Tenant")
        {

        }
    }
}
