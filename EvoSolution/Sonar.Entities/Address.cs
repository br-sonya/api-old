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
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [SonarRequired]
        public Guid UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        [SonarRequired]
        [SonarStringLength(120)]
        public string Description { get; set; }

        [SonarRequired]
        public int StateId { get; set; }
        public State State { get; set; }

        [SonarRequired]
        [SonarStringLength(60)]
        public string City { get; set; }

        [SonarRequired]
        [SonarStringLength(9)]
        public string Cep { get; set; }

        [SonarRequired]
        [SonarStringLength(255)]
        public string Location { get; set; }

        [SonarRequired]
        [SonarStringLength(8)]
        public string Number { get; set; }

        [SonarRequired]
        [SonarStringLength(30)]
        public string Complement { get; set; }

        [SonarRequired]
        [SonarStringLength(30)]
        public string Neighborhood { get; set; }
    }
}
