namespace Nubi.Core.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
