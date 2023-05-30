namespace AppSettingsAssignment.ViewModels.Request
{
    public class UpdateStudentRequest
    {
        public int Id { get; set; }
        public int AdmsnNo { get; set; }
        public string? Name { get; set; }
        public int Class { get; set; }
        public string? Address { get; set; }
    }
}
