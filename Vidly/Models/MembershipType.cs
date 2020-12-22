using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Data.Entity;

namespace Vidly.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte Percentage { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}