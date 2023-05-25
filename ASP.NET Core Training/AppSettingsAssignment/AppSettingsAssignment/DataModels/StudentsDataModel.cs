using System.ComponentModel.DataAnnotations.Schema;

namespace AppSettingsAssignment.DataModels
{
    [Table("Students", Schema = "dbo")]
    public class StudentsDataModel
    {
        public int Id { get; set; }
        public int AdmsnNo { get; set; }
        public string? Name { get; set; }
        public int Class { get; set; }
        public string? Address { get; set; }

    }
}
