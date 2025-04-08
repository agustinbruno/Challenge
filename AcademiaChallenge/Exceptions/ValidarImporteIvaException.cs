namespace AcademiaChallenge.Exceptions
{
    public class ValidarImporteIvaException : ValidacionFacturaException
    {
        public ValidarImporteIvaException() : base("Calculo de importe de IVA inválido")
        {
        }
    }
}

