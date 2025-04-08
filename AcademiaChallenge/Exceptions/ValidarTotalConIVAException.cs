namespace AcademiaChallenge.Exceptions
{
    public class ValidarTotalConIVAException : ValidacionFacturaException
    {
        public ValidarTotalConIVAException() : base("Calculo total con IVA inválido")
        {
        }
    }
}

