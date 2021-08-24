using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticeApplication.WebUI.Models
{
    public class ComposerViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Date of Death")]
        public DateTime? Died { get; set; }

        public List<PieceViewModel> Pieces { get; set; }
    }
}
