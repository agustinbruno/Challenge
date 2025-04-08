using AcademiaChallenge;
using AcademiaChallenge.Exceptions;
using AcademiaChallenge.Model;

namespace AcademiaChallengeTest
{
    [TestClass]
    public class ProcesadorFacturasAxoftTest
    {
        #region Validar
        #region Validar casos correctos
        [TestMethod]
        public void Validar_CasoCorrecto00_SinFacturas_NoTiraExcepcion()
        {
            List<Factura> facturas = [];

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();
        }

        [TestMethod]
        public void Validar_CasoCorrecto01_UnaFacturaUnRenglon_NoTiraExcepcion()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();
        }

        [TestMethod]
        public void Validar_CasoCorrecto02_UnaFacturaDosRenglones_NoTiraExcepcion()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 5,
                        Total = 5
                    },
                    new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 5,
                        Cantidad = 1,
                        Total = 5
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();
        }

        [TestMethod]
        public void Validar_CasoCorrecto03_DosFacturas_NoTiraExcepcion()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();
        }

        [TestMethod]
        public void Validar_CasoCorrecto04_DosFacturasMismoCliente_NoTiraExcepcion()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();
        }
        #endregion

        #region Validar numeración correlativa
        [TestMethod]
        public void Validar_NumeracionCorrelativa01_PimerFactura0TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 0,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<NumeracionInvalidaException>(procesadorFacturas.Validar, "Numeración inválida");
        }

        [TestMethod]
        public void Validar_NumeracionCorrelativa03_SegundaFactura3TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 3,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<NumeracionInvalidaException>(procesadorFacturas.Validar, "Numeración inválida");
        }

        [TestMethod]
        public void Validar_NumeracionCorrelativa02_PimerFactura2TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<NumeracionInvalidaException>(procesadorFacturas.Validar, "Numeración inválida");
        }
        #endregion

        #region Validar Orden Cronologico
        [TestMethod]
        public void Validar_OrdenCronologico01_SegundaFactura2TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 03, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "155456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<OrdenCronologicoInvalidoException>(procesadorFacturas.Validar, "Orden cronologico inválido");

        }

        [TestMethod]
        public void Validar_OrdenCronologico02_TercerFactura3TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });
            facturas.Add(new Factura()
            {
                Numero = 3,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli03",
                RazonSocial = "Cliente 03 SA",
                Cuil = "987654364",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<OrdenCronologicoInvalidoException>(procesadorFacturas.Validar, "Orden cronologico inválido");

        }
        #endregion

        #region Validar Datos Cliente
        [TestMethod]
        public void Validar_DatosCliente01_Cuil_SegundaFactura2TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456799",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 3,
                Fecha = new DateTime(2024, 01, 03),
                CodigoCliente = "Cli03",
                RazonSocial = "Cliente 03 SA",
                Cuil = "987654364",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<DatosClienteInvalidoException>(procesadorFacturas.Validar, "Datos cliente inválido");
        }

        [TestMethod]
        public void Validar_DatosCliente02_PorcentajeIVA_SegundaFactura2TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 50,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 3,
                Fecha = new DateTime(2024, 01, 03),
                CodigoCliente = "Cli03",
                RazonSocial = "Cliente 03 SA",
                Cuil = "987654364",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<DatosClienteInvalidoException>(procesadorFacturas.Validar, "Datos cliente inválido");
        }

        [TestMethod]
        public void Validar_DatosCliente03_CodigoCliente_PrimerFactura1TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli011",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 3,
                Fecha = new DateTime(2024, 01, 03),
                CodigoCliente = "Cli03",
                RazonSocial = "Cliente 03 SA",
                Cuil = "987654364",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<DatosClienteInvalidoException>(procesadorFacturas.Validar, "Datos cliente inválido");
        }
        #endregion

        #region Validar Consistencia Articulo
        [TestMethod]
        public void Validar_ConsistenciaArticulo01_Codigo_SegundaFactura2_Renglon1_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art08",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarDatosArticulosFacturaException>(procesadorFacturas.Validar, "Datos articulo inválido");
        }

        [TestMethod]
        public void Validar_ConsistenciaArticulo02_PrecioUnitario_SegundaFactura2_Renglon1_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 5,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarDatosArticulosFacturaException>(procesadorFacturas.Validar, "Datos articulo inválido");

        }

        [TestMethod]
        public void Validar_ConsistenciaArticulo03_Descripcion_SegundaFactura2_Renglon2_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art02",
                                    DescripcionArtigulo = "SoyElArticulo2",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                },
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 2,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo9",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarDatosArticulosFacturaException>(procesadorFacturas.Validar, "Datos articulo inválido");
        }
        #endregion

        #region Validar numeracion correlativa renglones
        [TestMethod]
        public void Validar_NumeracionCorrelativaRenglones01_PimerFactura1_Renglon0_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 0,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<NumeracionInvalidaRenglonesException>(procesadorFacturas.Validar, "Numeración de renglones inválida");

        }

        [TestMethod]
        public void Validar_NumeracionCorrelativaRenglones02_PrimerFactura1_Renglon3_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                     new RenglonFactura()
                    {
                        NumeroRenglon = 3,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<NumeracionInvalidaRenglonesException>(procesadorFacturas.Validar, "Numeración de renglones inválida");
        }

        [TestMethod]
        public void Validar_NumeracionCorrelativaRenglones03_SegundaFactura1_Renglon0_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                     new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "123456711",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 0,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<NumeracionInvalidaRenglonesException>(procesadorFacturas.Validar, "Numeración de renglones inválida");
        }
        #endregion

        #region Validar total renglon
        [TestMethod]
        public void Validar_TotalRenglon01_PimerFactura1_Renglon1_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 12,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 12
                    }
                ]
            });
            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarTotalRenglonException>(procesadorFacturas.Validar, "Calculo total de renglon inválido");
        }

        [TestMethod]
        public void Validar_TotalRenglon02_PimerFactura1_Renglon2_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 22,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                    new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 2,
                        Cantidad = 10,
                        Total = 12
                    }
                ]
            });
            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarTotalRenglonException>(procesadorFacturas.Validar, "Calculo total de renglon inválido");
        }
        #endregion

        #region Validar total sin IVA
        [TestMethod]
        public void Validar_TotalSinIva01_PimerFactura1_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 12,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                     new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarTotalSinIVAException>(procesadorFacturas.Validar, "Calculo total sin IVA inválido");
        }

        [TestMethod]
        public void Validar_TotalSinIva02_SegundaFactura2_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "123451234",
                ImporteTotalSinIva = 90,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                    new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 2,
                        Cantidad = 20,
                        Total = 40
                    }
                ]
            });
            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarTotalSinIVAException>(procesadorFacturas.Validar, "Calculo total sin IVA inválido");
        }
        #endregion

        #region Validar porcentaje IVA
        [TestMethod]
        public void Validar_PorcentajeIva01_PimerFactura1_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 30,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarPorcentajeIVAException>(procesadorFacturas.Validar, "Porcentaje IVA inválido");
        }

        [TestMethod]
        public void Validar_PorcentajeIva02_SegundaFactura2_TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "123451234",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 3,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarPorcentajeIVAException>(procesadorFacturas.Validar, "Porcentaje IVA inválido");
        }
        #endregion

        #region Validar Importe IVA
        [TestMethod]
        public void Validar_ImporteIva01_PrimerFactura1TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "155456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 4,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarImporteIvaException>(procesadorFacturas.Validar, "Calculo de importe de IVA inválido");
        }

        [TestMethod]
        public void Validar_ImporteIva02_TercerFactura3TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });
            facturas.Add(new Factura()
            {
                Numero = 3,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli03",
                RazonSocial = "Cliente 03 SA",
                Cuil = "987654364",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 0,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarImporteIvaException>(procesadorFacturas.Validar, "Calculo de importe de IVA inválido");

        }
        #endregion

        #region Validar Importe Total Con IVA
        [TestMethod]
        public void Validar_ImporteTotalConIva01_PrimerFactura1TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "155456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 80,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarTotalConIVAException>(procesadorFacturas.Validar, "Calculo de importe de IVA inválido");
        }

        [TestMethod]
        public void Validar_ImporteTotalConIva02_SegundaFactura2TiraError()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "987654321",
                ImporteTotalSinIva = 30,
                PorcentajeIva = 27,
                ImporteIva = 8.1,
                TotalConIva = 12.1,
                Renglones =
                            [
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 1,
                                    CodigoArticulo = "Art01",
                                    DescripcionArtigulo = "SoyElArticulo1",
                                    PrecioUnitario = 1,
                                    Cantidad = 10,
                                    Total = 10
                                },
                                new RenglonFactura()
                                {
                                    NumeroRenglon = 2,
                                    CodigoArticulo = "Art02",
                                    DescripcionArtigulo = "SoyElArticulo2",
                                    PrecioUnitario = 2,
                                    Cantidad = 10,
                                    Total = 20
                                }
                            ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            Assert.ThrowsException<ValidarImporteIvaException>(procesadorFacturas.Validar, "Calculo de importe de IVA inválido");

        }
        #endregion
        #endregion

        #region Consultas
        #region Consultas TotalFacturado
        [TestMethod]
        public void TotalFacturado00_SinFacturasEsCero()
        {
            List<Factura> facturas = [];

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar(); // Validamos antes de procesar

            Assert.AreEqual(0, procesadorFacturas.TotalFacturado());
        }

        [TestMethod]
        public void TotalFacturado01_UnaFactura_TotalFacturadoEsIgualAlLaunicaFactura()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar(); // Validamos antes de procesar

            Assert.AreEqual(12.1, procesadorFacturas.TotalFacturado());
        }

        [TestMethod]
        public void TotalFacturado02_DosFactura_TotalFacturadoEsIgualALaSuma()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 100,
                PorcentajeIva = 21,
                ImporteIva = 21,
                TotalConIva = 121,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 100,
                        Total = 100
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar(); // Validamos antes de procesar

            Assert.AreEqual(133.1, procesadorFacturas.TotalFacturado());
        }
        #endregion

        #region Consultas articulo mas vendido
        [TestMethod]
        public void ArticuloMasVendido00_SinFacturasEsCero()
        {
            List<Factura> facturas = [];

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("", procesadorFacturas.ArticuloMasVendido());
        }

        [TestMethod]
        public void ArticuloMasVendido01_UnaFactura_UnicoArticuloMasVendido()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("Art01", procesadorFacturas.ArticuloMasVendido());
        }

        [TestMethod]
        public void ArticuloMasVendido02_DosFacturas_Articulo2MasVendido()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 100,
                PorcentajeIva = 21,
                ImporteIva = 21,
                TotalConIva = 121,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                    new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 1,
                        Cantidad = 90,
                        Total = 90
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("Art02", procesadorFacturas.ArticuloMasVendido());
        }
        #endregion

        #region Consultas cliente que mas gasto
        [TestMethod]
        public void ClienteConMasGasto00_SinFacturasEsBlank()
        {
            List<Factura> facturas = [];

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("", procesadorFacturas.ClienteQueMasGasto());
        }

        [TestMethod]
        public void ClienteConMasGasto01_UnaFactura_UnicoClienteConGasto()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("Cliente 01 SA", procesadorFacturas.ClienteQueMasGasto());
        }

        [TestMethod]
        public void ClienteConMasGasto02_DosFacturas_Cliente2ConMasGasto()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "123456678",
                ImporteTotalSinIva = 100,
                PorcentajeIva = 21,
                ImporteIva = 21,
                TotalConIva = 121,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                    new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 1,
                        Cantidad = 90,
                        Total = 90
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("Cliente 02 SA", procesadorFacturas.ClienteQueMasGasto());
        }
        #endregion

        #region Consultas Artículo más comprado por un cliente
        [TestMethod]
        public void ArticuloMasCompradoPorUnCliente00_SinFacturasLanzaMensaje()
        {
            List<Factura> facturas = [];

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("No se encontraron articulos para este cliente.", procesadorFacturas.ArticuloMasCompradoDeCliente("Cli02"));
        }

        [TestMethod]
        public void ArticuloMasCompradoPorUnCliente01_UnaFactura_UnicoClienteConGasto()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("SoyElArticulo1", procesadorFacturas.ArticuloMasCompradoDeCliente("Cli01"));
        }

        [TestMethod]
        public void ArticuloMasCompradoPorUnCliente02_DosFacturas_Cliente2ConMasGasto()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "123456678",
                ImporteTotalSinIva = 100,
                PorcentajeIva = 21,
                ImporteIva = 21,
                TotalConIva = 121,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                    new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 1,
                        Cantidad = 90,
                        Total = 90
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("SoyElArticulo2", procesadorFacturas.ArticuloMasCompradoDeCliente("Cli02"));
        }
        #endregion

        #region Consultas Total facturado en una fecha específica
        [TestMethod]
        public void TotalFacturadoFechaEspecifica00_SinFacturasEsCero()
        {
            List<Factura> facturas = [];

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual(0, procesadorFacturas.TotalFacturadoDeFecha(new DateTime(2024, 01, 01)));
        }

        [TestMethod]
        public void TotalFacturadoFechaEspecifica01_UnaFactura_UnicaFactura()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual(12.1, procesadorFacturas.TotalFacturadoDeFecha(new DateTime(2024, 01, 01)));
        }

        [TestMethod]
        public void TotalFacturadoFechaEspecifica02_DosFacturas_FechaEspecifica()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "123456678",
                ImporteTotalSinIva = 100,
                PorcentajeIva = 21,
                ImporteIva = 21,
                TotalConIva = 121,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    },
                    new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 1,
                        Cantidad = 90,
                        Total = 90
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual(121, procesadorFacturas.TotalFacturadoDeFecha(new DateTime(2024, 01, 02)));
        }
        #endregion

        #region Consultas Cliente que más compró un artículo
        [TestMethod]
        public void ArticuloMasCompradoPorCliente00_SinFacturasLanzaMensaje()
        {
            List<Factura> facturas = [];

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual(0, procesadorFacturas.TotalFacturadoDeFecha(new DateTime(2024, 01, 01)));
        }

        [TestMethod]
        public void ArticuloMasCompradoPorCliente01_UnaFactura_UnicoCliente()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("123456789", procesadorFacturas.ClienteQueMasComproArticulo("Art01"));
        }

        [TestMethod]
        public void ArticuloMasCompradoPorCliente02_DosFacturas_Cliente2_Articulo1()
        {
            List<Factura> facturas = [];
            facturas.Add(new Factura()
            {
                Numero = 1,
                Fecha = new DateTime(2024, 01, 01),
                CodigoCliente = "Cli01",
                RazonSocial = "Cliente 01 SA",
                Cuil = "123456789",
                ImporteTotalSinIva = 10,
                PorcentajeIva = 21,
                ImporteIva = 2.1,
                TotalConIva = 12.1,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });
            facturas.Add(new Factura()
            {
                Numero = 2,
                Fecha = new DateTime(2024, 01, 02),
                CodigoCliente = "Cli02",
                RazonSocial = "Cliente 02 SA",
                Cuil = "123456678",
                ImporteTotalSinIva = 100,
                PorcentajeIva = 21,
                ImporteIva = 21,
                TotalConIva = 121,
                Renglones =
                [
                    new RenglonFactura()
                    {
                        NumeroRenglon = 1,
                        CodigoArticulo = "Art01",
                        DescripcionArtigulo = "SoyElArticulo1",
                        PrecioUnitario = 1,
                        Cantidad = 90,
                        Total = 90
                    },
                    new RenglonFactura()
                    {
                        NumeroRenglon = 2,
                        CodigoArticulo = "Art02",
                        DescripcionArtigulo = "SoyElArticulo2",
                        PrecioUnitario = 1,
                        Cantidad = 10,
                        Total = 10
                    }
                ]
            });

            ProcesadorFacturasAxoft procesadorFacturas = new(facturas);
            procesadorFacturas.Validar();

            Assert.AreEqual("123456678", procesadorFacturas.ClienteQueMasComproArticulo("Art01"));
        }
        #endregion
        #endregion
    }
}