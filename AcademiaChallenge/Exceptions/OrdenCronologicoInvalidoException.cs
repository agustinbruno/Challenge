namespace AcademiaChallenge.Exceptions
{
    public class OrdenCronologicoInvalidoException : ValidacionFacturaException
    {
        public OrdenCronologicoInvalidoException() : base("Orden cronologico inválido")
        {
        }
    }
}
