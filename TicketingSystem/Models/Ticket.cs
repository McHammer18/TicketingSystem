using System;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a name")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a sprint number")]
        public string SprintNum { get; set; }
        [Required(ErrorMessage = "Please enter a point value")]
        [Range(1,5)]
        public string Point { get; set; }

        [Required(ErrorMessage ="Please enter a Status (Checking in, Waiting to start, in Race, and done")]
        public string StatusId { get; set; }

        public Status? Status { get; set; }


    }
}
