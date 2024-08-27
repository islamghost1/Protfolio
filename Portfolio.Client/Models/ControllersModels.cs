namespace Portfolio.Client.Models
{
    public class ControllersModels
    {
        public class AllUserDetails
        {
            public Users Users { get; set; }
            public List<Experience> Experiences { get; set; }
            public List<Skills> userSkills { get; set; }
            public List<Education> userEducation { get; set; }
        }
    }
}
