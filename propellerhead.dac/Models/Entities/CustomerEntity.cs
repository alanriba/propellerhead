using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace propellerhead.dac.Models
{
	[Table("TBL_Customer")]
	[Description("Represents a customer's data")]
    public class CustomerEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Primary Key")]
        public int CustomerNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [Description("First Name customer")]
        public String CustomerFirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Description("Last name customer")]
        public string CustomerLastName { get; set; }

        //Foreing Key
        [Description("Id the status from table TBL_Estatus")]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(255)]
        [Description("Creation Date")]
        public DateTime CustomerDateCreation { get; set; } = DateTime.Now;

        [JsonIgnore]
        public virtual ICollection<CustomerContactDetailEntity> CustomerDetailsContactEntities { get; set; }
         

        public CustomerEntity()
        {
            CustomerDetailsContactEntities = new HashSet<CustomerContactDetailEntity>();
        }
    }

}

