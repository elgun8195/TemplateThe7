using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_7.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Position { get; set; }
        public string Insta { get; set; }
        public string Twitter { get; set; }
        public string Googleplus { get; set; }
        public string Linkedin { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
