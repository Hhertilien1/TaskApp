using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserTaskApp.Models
{
    public class UserTask
    {
        public int Id { get; set; } // Unique identifier for the UserTask

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } // Title of the UserTask

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } // Description of the UserTask

        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("^(To Do|In Progress|Completed)$", ErrorMessage = "Status must be 'To Do', 'In Progress', or 'Completed'")]
        public string Status { get; set; } // Status of the UserTask (e.g., To Do, In Progress, Completed)

        [Required(ErrorMessage = "Name is required")]
        public string CreatedBy { get; set; } // User who created the UserTask

        [Required(ErrorMessage = "Name is required")]
        public string AssignedTo { get; set; } // User to whom the UserTask is assigned

        [Required(ErrorMessage = "Date is required")]
        [RegularExpression("^(00/00/000)$", ErrorMessage = "Date must be typed in this format: 00/00/0000. (please include slashes)")]
        public string DueDt { get; set; } // Due date of the UserTask
    }
}

