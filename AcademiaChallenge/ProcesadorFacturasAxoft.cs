using AcademiaChallenge.Exceptions;
using AcademiaChallenge.Model;
using System.Runtime.CompilerServices;

namespace AcademiaChallenge
{
    /// <summary>
    /// Representa un conjunto de facturas.
    /// Proporciona métodos para validarlas y para realizar consultas sobre las mismas.
    /// </summary>
    /// <param name="facturas">
    /// Lista de facturas que serán procesadas y validadas.
    /// </param>
    public class ProcesadorFacturasAxoft(List<Factura> facturas)
    {
        private readonly List<Factura> facturas = facturas;

        #region private validations
        /// <summary>
        /// Valida que la numeración de las facturas comienza en 1, está en orden correlativo y sin huecos.
        /// </summary>
        /// <exception cref="NumeracionInvalidaException">
        /// Se lanza cuando la numeración no es correlativa o presenta huecos.
        /// </exception>
        private void ValidarNumeracionCorrelativa()
        {
            for (int i = 1; i <= facturas.Count; i++)
            {
                if (facturas[i - 1].Numero != i)
                {
                    throw new NumeracionInvalidaException();
                }
            }
        }

        /// <summary>
        /// Verificar que las facturas están emitidas en orden cronológico.
        /// </summary>
        /// <exception cref="OrdenCronologicoInvalidoException">
        /// Se lanza cuando las facturas no están emitidas en orden cronológico.
        /// </exception>
        private void ValidarOrdenCronologicoFacturas()
        {
            for (int i = 1; i < facturas.Count; i++)
            {
                if (facturas[i].Fecha < facturas[i - 1].Fecha)
                {
                    throw new OrdenCronologicoInvalidoException();
                }
            }
        }

        /// <summary>
        /// Verificar que el cliente tenga el mismo CUIL,CodigoCliente y porcentaje de IVA.
        /// </summary>
        /// <exception cref="DatosClienteInvalidoException">
        /// Se lanza cuando el cliente no tiene los mismos datos.
        /// </exception>
        private void ValidarDatosConsistentesCliente()
        {
            var clientes = facturas.GroupBy(f => f.RazonSocial);
            foreach (var cliente in clientes)
            {

                var primerFactura = cliente.First();
                foreach (var factura in cliente)
                {
                    if (factura.Cuil != primerFactura.Cuil || factura.CodigoCliente != primerFactura.CodigoCliente || factura.PorcentajeIva != primerFactura.PorcentajeIva)
                    {
                        throw new DatosClienteInvalidoException();
                    }
                }
            }

        }

        /// <summary>
        /// Verificar que un articulo tenga el mismo codigo, descripcion y precio unitario en todas las facturas.
        /// </summary>
        /// <exception cref="ValidarDatosArticulosFacturaException">
        /// Se lanza cuando el articulo no tiene los mismos datos.
        /// </exception>
        private void ValidarConsistenciaArticulo()
        {
            var codigoArticulos = new Dictionary<string, (string Descripcion, double PrecioUnitario)>();
            var codigosDescripcion = new Dictionary<string, string>();

            foreach (var factura in facturas)
            {
                foreach (var renglon in factura.Renglones)
                {
                    if (codigoArticulos.ContainsKey(renglon.CodigoArticulo))
                    {
                        var datosArticulo = codigoArticulos[renglon.CodigoArticulo];

                        if (datosArticulo.Descripcion != renglon.DescripcionArtigulo || datosArticulo.PrecioUnitario != renglon.PrecioUnitario)
                        {
                            throw new ValidarDatosArticulosFacturaException();
                        }
                    }
                    else
                    {
                        codigoArticulos[renglon.CodigoArticulo] = (renglon.DescripcionArtigulo, renglon.PrecioUnitario);
                    }

                    if (codigosDescripcion.ContainsKey(renglon.DescripcionArtigulo))
                    {
                        if (codigosDescripcion[renglon.DescripcionArtigulo] != renglon.CodigoArticulo)
                        {
                            throw new ValidarDatosArticulosFacturaException();
                        }
                    }
                    else
                    {
                        codigosDescripcion[renglon.DescripcionArtigulo] = renglon.CodigoArticulo;
                    }
                }
            }

        }

        /// <summary>
        /// Verificar que el orden de numeración de los renglones dentro de cada factura debe ser correcto.
        /// </summary>
        /// <exception cref="NumeracionInvalidaRenglonesException">
        /// Se lanza cuando los renglones no estan en el orden de numeracion correcto.
        /// </exception>
        private void ValidarOrdenNumeracionRenglones()
        {
            foreach (var factura in facturas)
            {

                var renglones = factura.Renglones;
                for (int i = 0; i < renglones.Count; i++)
                {
                    if (renglones[i].NumeroRenglon != i + 1)
                    {
                        throw new NumeracionInvalidaRenglonesException();
                    }
                }
            }
        }

        /// <summary>
        /// Realiza las validaciones sobre el total de cada renglon.
        /// </summary>
        /// <exception cref= "ValidarTotalRenglonException">
        /// Se lanza cuando el total de cada renglón no esta calculado correctamente.
        /// </exception>
        private void ValidarTotalRenglon()
        {
            foreach (var factura in facturas)
            {
                var renglones = factura.Renglones;
                foreach (var renglon in renglones)
                {
                    var calculoTotal = renglon.Cantidad * renglon.PrecioUnitario;
                    if (calculoTotal != renglon.Total)
                    {
                        throw new ValidarTotalRenglonException();
                    }

                }
            }
        }

        /// <summary>
        /// Realiza las validaciones del total sin IVA de cada factura.
        /// </summary>
        /// <exception cref= "ValidarTotalSinIVAException">
        /// Se lanza cuando el total sin IVA de cada factura no es correcto.
        /// </exception>
        private void ValidarTotalSinIVA()
        {
            foreach (var factura in facturas)
            {
                double calculoTotalSinIva = 0;
                var renglones = factura.Renglones;
                foreach (var renglon in renglones)
                {
                    var calculoTotal = renglon.Cantidad * renglon.PrecioUnitario;
                    calculoTotalSinIva += calculoTotal;
                }
                if (calculoTotalSinIva != factura.ImporteTotalSinIva)
                {
                    throw new ValidarTotalSinIVAException();
                }
            }
        }

        /// <summary>
        /// Realiza la validacion del porcentaje de IVA aplicado en cada factura.
        /// </summary>
        /// <exception cref= "ValidarPorcentajeIVAException">
        /// Se lanza cuando el porcentaje de IVA aplicado no es el correcto.
        /// </exception>
        private void ValidarPorcentajeIVA()
        {
            List<double> porcentajes = [0, 10.5, 21, 27];
            foreach (var factura in facturas)
            {
                if (!porcentajes.Contains(factura.PorcentajeIva))
                {
                    throw new ValidarPorcentajeIVAException();
                }
            }
        }

        /// <summary>
        /// Realiza la validacion del porcentaje de IVA aplicado en cada factura.
        /// </summary>
        /// <exception cref= "ValidarPorcentajeIVAException">
        /// Se lanza cuando el porcentaje de IVA aplicado no es el correcto.
        /// </exception>
        private void ValidarImporteIVA()
        {
            foreach (var factura in facturas)
            {
                var calculoImporteIva = (factura.PorcentajeIva / 100) * factura.ImporteTotalSinIva;
                if (calculoImporteIva != factura.ImporteIva)
                {
                    throw new ValidarImporteIvaException();
                }
            }
        }

        /// <summary>
        /// Realiza la validacion del calculo total con IVA aplicado en cada factura.
        /// </summary>
        /// <exception cref= "ValidarTotalConIVAException">
        /// Se lanza cuando el calculo total con IVA no es el correcto.
        /// </exception>
        private void ValidarTotalConIVA()
        {
            foreach (var factura in facturas)
            {
                var calculoTotalConIva = factura.ImporteIva + factura.ImporteTotalSinIva;
                if (calculoTotalConIva != factura.TotalConIva)
                {
                    throw new ValidarTotalConIVAException();
                }
            }
        }
        public void Validar()
        {
            ValidarNumeracionCorrelativa();
            ValidarOrdenCronologicoFacturas();
            ValidarDatosConsistentesCliente();
            ValidarConsistenciaArticulo();
            ValidarOrdenNumeracionRenglones();
            ValidarTotalRenglon();
            ValidarTotalSinIVA();
            ValidarPorcentajeIVA();
            ValidarImporteIVA();
            ValidarTotalConIVA();
        }
        #endregion


        #region Consultas
        /// <summary>
        /// Calcula el total facturado sumando los totales de todas las facturas.
        /// </summary>
        /// <returns>El total facturado con IVA incluido.</returns>
        public double TotalFacturado()
        {
            double total = 0;
            for (int i = 0; i < facturas.Count; i++)
            {
                total += facturas[i].TotalConIva;
            }
            return total;
        }

        /// <summary>
        /// Artículo que ha sido vendido en mayor cantidad.
        /// </summary>
        /// <returns>Código del artículo.</returns>
        public string ArticuloMasVendido()
        {
            Dictionary<string, int> ventasPorArticulo = new Dictionary<string, int>();
            string articuloMasVendido = string.Empty;
            int cantidadMaxima = 0;

            foreach (var factura in facturas)
            {
                foreach (var renglon in factura.Renglones)
                {
                    string codigo = renglon.CodigoArticulo;
                    int cantidad = renglon.Cantidad;

                    if (ventasPorArticulo.ContainsKey(codigo))
                    {
                        ventasPorArticulo[codigo] += cantidad;
                    }
                    else
                    {
                        ventasPorArticulo[codigo] = cantidad;
                    }
                }
            }

            foreach (var articulo in ventasPorArticulo)
            {
                if (articulo.Value > cantidadMaxima)
                {
                    cantidadMaxima = articulo.Value;
                    articuloMasVendido = articulo.Key;
                }

            }
            return articuloMasVendido;
        }

        /// <summary>
        /// Cliente que realizó el mayor gasto total
        /// </summary>
        /// <returns>Razón social del cliente.</returns>
        public string ClienteQueMasGasto()
        {
            string clienteConMasGasto = string.Empty;
            double totalMaximo = 0;
            Dictionary<string, double> clientesDatos = new Dictionary<string, double>();
            foreach (var factura in facturas)
            {
                double totalFactura = factura.TotalConIva;

                if (clientesDatos.ContainsKey(factura.RazonSocial))
                {
                    clientesDatos[factura.RazonSocial] += totalFactura;
                }
                else
                {
                    clientesDatos[factura.RazonSocial] = totalFactura;
                }
            }
            foreach (var cliente in clientesDatos)
            {

                if (cliente.Value > totalMaximo)
                {
                    totalMaximo = cliente.Value;
                    clienteConMasGasto = cliente.Key;
                }
            }
            return clienteConMasGasto;
        }

        /// <summary>
        /// Artículo mas comprado por un cliente
        /// </summary>
        /// <param name="codigoCliente">Código del cliente</param>
        /// <returns>Descripción del artículo</returns>
        public string ArticuloMasCompradoDeCliente(string codigoCliente)
        {
            int cantidadMaxima = 0;
            string descripcionArticulo = string.Empty;
            Dictionary<string, int> datosArticulo = new Dictionary<string, int>();
            foreach (var factura in facturas)
            {
                if (factura.CodigoCliente == codigoCliente)
                {
                    foreach (var renglon in factura.Renglones)
                    {
                        if (datosArticulo.ContainsKey(renglon.DescripcionArtigulo))
                        {
                            datosArticulo[renglon.DescripcionArtigulo] += renglon.Cantidad;
                        }
                        else
                        {
                            datosArticulo[renglon.DescripcionArtigulo] = renglon.Cantidad;
                        }
                    }
                }
            }
            foreach (var articulo in datosArticulo)
            {
                if (articulo.Value > cantidadMaxima)
                {
                    cantidadMaxima = articulo.Value;
                    descripcionArticulo = articulo.Key;
                }
            }
            if (string.IsNullOrEmpty(descripcionArticulo))
            {
                return "No se encontraron articulos para este cliente.";
            }

            return descripcionArticulo;
        }

        /// <summary>
        /// Calcula el total facturado para la fecha.
        /// </summary>
        /// <param name="fecha">Fecha para la que se va a calcular el total facturado</param>
        /// <returns>Total facturado para la fecha</returns>
        public double TotalFacturadoDeFecha(DateTime fecha)
        {

            double totalFacturado = 0;
            foreach (var factura in facturas)
            {
                if (factura.Fecha == fecha)
                {
                    totalFacturado += factura.TotalConIva;
                }
            }
            return totalFacturado;
        }

        /// <summary>
        /// Cliente que copró mas cantidad de un artículo
        /// </summary>
        /// <param name="codigoArticulo">Código del artículo</param>
        /// <returns>CUIL del cliente</returns>
        public string ClienteQueMasComproArticulo(string codigoArticulo)
        {
            int cantidadMaxima = 0;
            string clienteCuil = string.Empty;
            Dictionary<string, int> datosArticulo = new Dictionary<string, int>();

            foreach (var factura in facturas)
            {
                foreach (var renglon in factura.Renglones)
                {
                    if (renglon.CodigoArticulo == codigoArticulo)
                    {
                        if (datosArticulo.ContainsKey(factura.Cuil))
                        {
                            datosArticulo[factura.Cuil] += renglon.Cantidad;
                        }
                        else
                        {
                            datosArticulo[factura.Cuil] = renglon.Cantidad;
                        }
                    }
                }
            }
            foreach (var articulo in datosArticulo)
            {
                if (articulo.Value > cantidadMaxima)
                {
                    cantidadMaxima = articulo.Value;
                    clienteCuil = articulo.Key;
                }
            }
            if (string.IsNullOrEmpty(clienteCuil))
            {
                return "No se encontraron compras realizadas para ese articulo.";
            }

            return clienteCuil;

        }
        #endregion
    }
}