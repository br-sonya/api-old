using System.ComponentModel.DataAnnotations;

namespace HFRural.Framework.DataAnnotations
{
    public class SonarRequiredAttribute : RequiredAttribute
    {
        public SonarRequiredAttribute() : base()
        {
            ErrorMessage = "Este campo é obrigatório";
        } 
    }
}
