namespace WebApi.ModelViews
{
    public class DoctorGetView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Department { get; set; } = null!;
    }
}
