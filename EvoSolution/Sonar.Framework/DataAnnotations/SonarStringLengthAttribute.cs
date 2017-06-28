using System;
using System.ComponentModel.DataAnnotations;

namespace Sonar.Framework.DataAnnotations
{
    public class SonarStringLengthAttribute : StringLengthAttribute
    {
        public SonarStringLengthAttribute(int maximumLength) : base(maximumLength)
        {
            ErrorMessage = $"Este campo pode ter no máximo {maximumLength} caracteres.";
        }
    }
}
