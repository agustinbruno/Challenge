namespace AcademiaChallenge.Exceptions
{
    public class ValidarTotalSinIVAException : ValidacionFacturaException
    {
        public ValidarTotalSinIVAException() : base("Calculo total sin IVA inválido")
        {
        }
    }
}

