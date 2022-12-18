using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace propellerhead.dac.Models
{
    [Table("TBL_Status")]
    [Description("Represents a status of customer")]
    public class StatusEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Primary Key")]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(100)]
        [Description("First Name customer")]
        public String StatusName { get; set; }
    }
}