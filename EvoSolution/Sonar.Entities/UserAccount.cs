using HFRural.Framework.DataAnnotations;
using Sonar.Framework.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.Entities
{
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [SonarRequired]
        [SonarStringLength(100)]
        public string Name { get; set; }

        [SonarRequired]
        [SonarStringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [SonarRequired]
        [SonarStringLength(64)]
        public string Password { get; set; }

    } 
}
