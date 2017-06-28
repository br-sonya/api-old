using System.ComponentModel.DataAnnotations;

namespace Sonar.Framework.DataAnnotations
{
    public class SonarDateAttribute : RegularExpressionAttribute
    {
        public SonarDateAttribute() : base(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d(( [0-2][0-9]:[0-5][0-9]:[0-5][0-9])*)$")
        {
            ErrorMessage = "A data deve ser no formato dd/MM/yyyy";
        }
    }
}
