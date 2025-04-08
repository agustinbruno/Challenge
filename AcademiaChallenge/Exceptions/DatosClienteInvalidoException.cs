namespace AcademiaChallenge.Exceptions
{
    public class DatosClienteInvalidoException : ValidacionFacturaException
    {
        public DatosClienteInvalidoException() : base("Datos cliente inválido")
        {
        }
    }
}

