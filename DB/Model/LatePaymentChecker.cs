using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Implementation;

namespace DB.Model
{
    public static class LatePaymentChecker
    {
        public static int idx { get; set; } = 1;
        public static LatePaymentModel CheckForDebts(Wynajmy rental)
        {
            var expectedAmount = 0.0;
            var totalPayments = 0.0;

            var dateDifference = DateTime.Today - rental.data_rozpoczecia;
            var months = Math.Round(dateDifference.Value.TotalDays / 30);

            if ((dateDifference.Value.TotalDays / 30) > 0
                && (dateDifference.Value.TotalDays / 30) < 1)
                months = 1;

            expectedAmount = months * Convert.ToDouble(rental.cena_miesieczna);

            using (var dbContext = new DBProjectEntities())
            {
                var allPaymentsForRental = dbContext.Platnosci.Where(x => x.id_wynajmu == rental.id).ToList();

                totalPayments = allPaymentsForRental.Sum(x => x.cena);

                if (expectedAmount <= totalPayments)
                {
                    return null;
                }

                var flat = dbContext.Mieszkania.First(x => x.id == rental.id_mieszkania);
                var building = dbContext.Budynki.First(x => x.id == flat.id_budynku);
                var debtor = dbContext.Najemcy.First(x => x.id == rental.id_najemcy);

                string resident = $"{debtor.imie} {debtor.nazwisko}";
                string telephone = $"{debtor.nr_telefonu}";
                string location = $"{building.adres_budynku}/{flat.numer}";

                var latePayment = new LatePaymentModel
                {
                    Id = idx,
                    id_najemcy = debtor.id,
                    kwota = expectedAmount - totalPayments,
                    imie = resident,
                    nr_telefonu = telephone,
                    adres = location
                };
                idx++;
                return latePayment;
            }
        }
    }
}
