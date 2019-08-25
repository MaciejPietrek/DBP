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
            : base(Properties.Settings.Default.ServerIPAdress + "api/Company")
        {

        }
    }

    class BuildingDataReceiver : DataReceiver<BuildingModel>
    {
        public BuildingDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/Building")
        {
            
        }
    }

    class FaultDataReceiver : DataReceiver<FaultModel>
    {
        public FaultDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/Fault")
        {

        }
    }

    class FlatDataReceiver : DataReceiver<FlatModel>
    {
        public FlatDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/Flat")
        {

        }
    }

    class RentalBillDataReceiver : DataReceiver<RentalBillModel>
    {
        public RentalBillDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/RentalBill")
        {

        }
    }

    class RentalDataReceiver : DataReceiver<RentalModel>
    {
        public RentalDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/Rental")
        {

        }
    }

    class RepairBilDataReceiver : DataReceiver<RepairBillModel>
    {
        public RepairBilDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/RepairBill")
        {

        }
    }

    class RepairDataReceiver : DataReceiver<RepairModel>
    {
        public RepairDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/Repair")
        {

        }
    }

    class SupervisingDataReceiver : DataReceiver<SupervisingModel>
    {
        public SupervisingDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/Supervising")
        {

        }
    }

    class SupervisorDataReceiver : DataReceiver<SupervisorModel>
    {
        public SupervisorDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/Supervisor")
        {

        }
    }

    class TenantDataReceiver : DataReceiver<TenantModel>
    {
        public TenantDataReceiver()
            : base(Properties.Settings.Default.ServerIPAdress + "api/Tenant")
        {

        }
    }
}
