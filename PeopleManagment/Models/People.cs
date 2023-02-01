using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PeopleManagment.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public Team? Team { get; set; }
    }
}
