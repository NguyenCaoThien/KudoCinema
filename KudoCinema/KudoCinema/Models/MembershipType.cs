using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KudoCinema.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public byte Discount { get; set; }
        public byte DurationInMonths { get; set; }
        public short SignUpFee { get; set; }

        public enum MemberShipType_TypeCode
        {
            PaysAsYouGo = 1,
            Monthly = 2,
            Quaterly = 3,
            Annual = 4
        }
    }
}