using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace propellerhead.dac.Models
{
    [Table("TBL_Customer_Contact_Detail")]
    [Description("Represents a customer's data")]
    public class CustomerContactDetailEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Primary Key")]
        public int ContactId { get; set; }

        //Foreing Key
        [Description("Customer number the status from table TBL_Customer")]
        public int CustomerNumber { get; set; }

        [MaxLength(10)]
        [Description("Phone contact")]
        public long ContactPhone { get; set; }

        [MaxLength(255)]
        [Description("Email Contact")]
        public string ContactEmail { get; set; }

        [MaxLength(255)]
        [Description("Direction Contact")]
        public string ContactDirection { get; set; }

        [DefaultValue(true)]
        [Description("Reason for the change of customer status")]
        public bool ContactStatus { get; set; }
    }
}