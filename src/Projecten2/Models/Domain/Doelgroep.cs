using System;

namespace Projecten2.Models.Domain
{
    public class Doelgroep
    {
        public int DoelgroepId { get; set; }
        public string DoelgroepText { get; set; }
        public double DoelgroepValue { get; set; }
        public Boolean IsVerwijderd { get; set; }

        public Doelgroep()
        {
            IsVerwijderd = false;
            DoelgroepText = "< 25 laaggeschoold";
            DoelgroepValue = 1550;
        }
    }
}
