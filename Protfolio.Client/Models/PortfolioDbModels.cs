using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Protfolio.Client.Models
{
    [Table("admins", Schema = "portfolio")]
    public class Admins
    {
        [Key]
        public int id { get; set; }
        public string? email_hash { get; set; }
        public string? pass_hash { get; set; }
        public char? auth_level { get; set; }
        public DateTime timestamp { get; set; }
    }
    [Table("project_steps", Schema = "portfolio")]
    public class Project_steps
    {
        [Key]
        public int id { get; set; }
        public string? step { get; set; }
    }

    [Table("projects", Schema = "portfolio")]
    public class Projects
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("users")]
        public int? user_id { get; set; }
        public string? company_name { get; set; }
        public string? project_name { get; set; }
        public string? project_details { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
    }
    [Table("skills", Schema = "portfolio")]
    public class Skills
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("users")]
        public int? user_id { get; set; }
        [ForeignKey("Projects")]
        public int? project_id { get; set; }
        public string? skill_name { get; set; }
        public string? skill_desc { get; set; }
        public double? skill_percentage { get; set; }
    }
    [Table("socials_links", Schema = "portfolio")]
    public class Socials_links
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("users")]
        public int? user_id { get; set; }
        public string? social_link { get; set; }
        public string? social_name { get; set; }
    }
    [Table("users", Schema = "portfolio")]
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? last_name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public DateTime? date_birth { get; set; }
        public string? description { get; set; }
        public DateTime? created_at { get; set; }
        public string? job { get; set; }
    }
}
