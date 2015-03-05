using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace AIronMan.Domain {
    public class SliderHeader {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public string Transition { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Speed { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Pause { get; set; }

        public ICollection<SliderStep> SliderSteps { get; set; }

        public User CrUser { get; set; }
        public User LmUser { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CrDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LmDate { get; set; }
    }
}
