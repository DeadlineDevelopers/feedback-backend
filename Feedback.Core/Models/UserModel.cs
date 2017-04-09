using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Feedback.Core.Models
{
    [Table("[USER]")]
    public class UserModel : BaseModel
    {
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [EmailAddress]
        public string MAIL { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
