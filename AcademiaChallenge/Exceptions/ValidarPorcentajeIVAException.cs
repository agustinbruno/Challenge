namespace AcademiaChallenge.Exceptions
{
    public class ValidarPorcentajeIVAException : ValidacionFacturaException
    {
        public ValidarPorcentajeIVAException() : base("Porcentaje IVA inválido")
        {
        }
    }
}

