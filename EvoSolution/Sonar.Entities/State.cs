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
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [SonarRequired]
        [SonarStringLength(2)]
        public string Uf { get; set; }

        [SonarRequired]
        [SonarStringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }


    }

}
