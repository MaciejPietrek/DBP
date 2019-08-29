using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model.Implementation;

namespace DB.Model
{
    public static class IncomeChecker
    {
        public static IncomeModel checkIncome(Budynki budynek, DateTime? startDate, DateTime? endDate)
        {
            List<FakturyNapraw> expenseBills;
            List<Platnosci> incomeBills;

            double totalIncome = 0;
            double totalExpense = 0;

            var buildingCosts = new IncomeModel();


            using (var ctx = new DBProjectEntities())
            {
                var residences = ctx.Mieszkania.Where(x => x.id_budynku == budynek.id)
                    .Include(i => i.Usterki
                        .Select(s => s.Naprawy
                            .Select(ss => ss.FakturyNapraw)))
                    .Include(i => i.Wynajmy.Select(s => s.Platnosci));

                if (startDate == null && endDate == null)
                {
                    foreach (var residence in residences)
                    {
                        incomeBills = residence.Wynajmy.SelectMany(s => s.Platnosci).ToList();
                        incomeBills.ForEach(x => totalIncome += x.cena);

                        expenseBills = residence.Usterki.SelectMany(s => s.Naprawy.SelectMany(ss => ss.FakturyNapraw)).ToList();
                        expenseBills.ForEach(x => totalExpense += x.cena);
                    }
                }
                else
                {
                    foreach (var residence in residences)
                    {
                        incomeBills = residence.Wynajmy.SelectMany(s => s.Platnosci).Where(x => x.data_platnosci > startDate && x.data_platnosci < endDate).ToList();
                        incomeBills.ForEach(x => totalIncome += x.cena);

                        expenseBills = residence.Usterki.SelectMany(s => s.Naprawy.SelectMany(ss => ss.FakturyNapraw).Where(x => x.data_platnosci > startDate && x.data_platnosci < endDate)).ToList();
                        expenseBills.ForEach(x => totalExpense += x.cena);
                    }
                }
            }

            buildingCosts.Income = totalIncome;
            buildingCosts.Expense = totalExpense;
            buildingCosts.Profit = totalIncome - totalExpense;

            return buildingCosts;
        }
    }
}
