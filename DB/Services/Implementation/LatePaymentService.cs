using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Model.Implementation;
using DB.Model.Interfaces;
using DB.Services.Interfaces;

namespace DB.Services.Implementation
{
    public class LatePaymentService : ILatePaymentService
    {
        public void AddOrUpdate(ILatePaymentModel model)
        {
            throw new NotImplementedException();
        }

        public List<ILatePaymentModel> GetAll()
        {
            List<ILatePaymentModel> result = new List<ILatePaymentModel>();
            try
            {
                foreach (var obiekt in GetLatePayments())
                {
                    result.Add(Mapper.ModelMapper.Mapper.Map<ILatePaymentModel>(obiekt));
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public ILatePaymentModel GetSingle(int id)
        {
            try
            {
                var queryResult = GetLatePayments().FirstOrDefault(x => x.Id == id);
                return Mapper.ModelMapper.Mapper.Map<ILatePaymentModel>(queryResult);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                return null;
            }
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ILatePaymentModel model)
        {
            throw new NotImplementedException();
        }

        private List<LatePaymentModel> GetLatePayments()
        {
            List<LatePaymentModel> latePayments = new List<LatePaymentModel>();

            foreach (var rental in GetActiveRentals())
            {
                var lp = LatePaymentChecker.CheckForDebts(rental);
                if (lp != null)
                {
                    latePayments.Add(lp);
                }
            }
            return latePayments;
        }

        private List<Wynajmy> GetActiveRentals()
        {
            using (var ctx = new DBProjectEntities())
            {
                var result = ctx.Wynajmy.Where(
                    x => x.data_rozpoczecia < DateTime.Now &&
                         x.data_zakonczenia > DateTime.Now).ToList();
                return result;
            }
        }
    }
}
