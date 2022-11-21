namespace WebApi.ModelViews
{
    public class HistoryGetView
    {
        public int Id { get; set; }
        public string PatientFullName { get; set; } = null!;
        public string PatientContacts { get; set; } = null!;
        public string Diagnosis { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Treatment { get; set; } = null!;
    }
}
