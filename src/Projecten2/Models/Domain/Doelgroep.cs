using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projecten2.Models.Domain.KostenVragen;

namespace Projecten2.Models.Domain
{
    public class Doelgroep
    {
        public int DoelgroepId { get; set; }
        public string DoelgroepText { get; set; }
        public double DoelgroepValue { get; set; }
        public double DoelgroepMaxLoon { get; set; }
        public Boolean IsVerwijderd { get; set; }

        public Doelgroep()
        {
            IsVerwijderd = false;
            DoelgroepText = "Standaard";
            DoelgroepMaxLoon = 0;
            DoelgroepValue = 0;
        }
    }
}
