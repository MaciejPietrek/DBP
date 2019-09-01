using System.Linq;
using DB.Model.Implementation;

namespace DB.Model
{
    public static class CurrentRepairChecker
    {
        private static int idx { get; set; } = 1;

        public static CurrentRepairModel checkRepair(Naprawy naprawa)
        {
            using (var ctx = new DBProjectEntities())
            {
                var repair = ctx.Usterki.Single(x => x.id == naprawa.id_usterki);

                var mieszkanie = repair.Mieszkania.numer;
                var adres = repair.Mieszkania.Budynki.adres_budynku;

                var repairModel = new CurrentRepairModel
                {
                    Id = idx,
                    id_usterki = naprawa.id_usterki,
                    id_firmy = naprawa.id_firmy,
                    lokalizacja = $"{adres}/{mieszkanie}",
                    nr_telefonu = naprawa.nr_telefonu,
                    data_zlecenia = naprawa.data_zlecenia,
                    data_rozpoczecia = naprawa.data_rozpoczecia
                };
                idx++;

                return repairModel;
            }
        }
    }
}
