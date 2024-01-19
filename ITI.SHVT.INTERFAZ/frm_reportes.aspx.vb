
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Reporting.WebForms
Imports Newtonsoft.Json

Public Class frm_reportes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then



            Dim vli_id_EstadoPago = Request.QueryString("id")
            Dim pvi_NumeroContrato = Request.QueryString("idc")
            Dim pvi_NumeroEquipo = Request.QueryString("idr")
            Dim pvi_idEquipo = Request.QueryString("idrc")
            Dim pvs_RutCliente = Request.QueryString("rutCliente")

            Dim pvs_RutFacturacion = Request.QueryString("RutFact")
            Dim pvs_Periodo = Request.QueryString("Periodo")
            Dim pvs_Anho = Request.QueryString("Anho")
            Dim pvi_Tipo = Request.QueryString("TipoFact")
            Dim pviSucursal = Request.QueryString("pviSucursal")

            Dim RutCliente = Request.QueryString("RutCliente")
            Dim pvi_EstadoContrato = Request.QueryString("pvi_EstadoContrato")
            Dim pvi_Sucursal = Request.QueryString("pvi_Sucursal")
            'Dim pvs_FechaTermino = Request.QueryString("pvs_FechaTermino")
            Dim pvs_IdEstados = Request.QueryString("List")
            Dim pvi_idOT = Request.QueryString("pvi_idOT")
            Dim pvi_idCotizacion = Request.QueryString("pvi_idCotizacion")

            Dim RutClienteRecuperacionVenta = Request.QueryString("RutClienteRecuperacionVenta")
            Dim RutClienteRecuperacionVentaTodos = Request.QueryString("RutClienteRecuperacionVentaTodos")
            Dim pvi_SucursalRecVenta = Request.QueryString("pvi_SucursalRecVenta")

            Dim tipoReporte = Integer.Parse(Request.QueryString("tiporeporte"))
            Dim TipoEquipo = Request.QueryString("TipoEquipo")
            Dim EstadoEquipo = Request.QueryString("EstadoEquipo")
            Dim Sucursal = Request.QueryString("Sucursal")

            Dim pvi_Familia = Request.QueryString("pvi_Familia")
            Dim pvi_EstadoEquipo = Request.QueryString("pvi_EstadoEquipo")
            Dim pvi_SucursalInforme = Request.QueryString("pvi_SucursalInforme")
            Dim pvs_Cliente = Request.QueryString("pvs_Cliente")

            Dim RutClientePagoFactura = Request.QueryString("RutClientePagoFactura")
            Dim pvd_DesdePagoFactura = Request.QueryString("pvd_DesdePagoFactura")
            Dim pvd_HastaPagoFactura = Request.QueryString("pvd_HastaPagoFactura")
            Dim pvi_idEquipoBitacora = Request.QueryString("pvi_idEquipoBitacora")

            Dim id_OC = Request.QueryString("pvi_idOC")
            Dim idProveedor = Request.QueryString("idProveedor")
            Dim EstadoFactura = Request.QueryString("EstadoFactura")


            Dim idProveedorInfGastos = Request.QueryString("idProveedorInfGastos")
            Dim EstadoFacturaInfGastos = Request.QueryString("EstadoFacturaInfGastos")
            Dim CCPadreInfGastos = Request.QueryString("CCPadreInfGastos")
            Dim CCHijoInfGastos = Request.QueryString("CCHijoInfGastos")
            Dim MesInfGastos = Request.QueryString("MesInfGastos")
            Dim AnhoInfGastos = Request.QueryString("AnhoInfGastos")




            Select Case tipoReporte
                Case 1 'Estados de pago

                    sds_DatosEP.SelectParameters("id_EstadoPago").DefaultValue = vli_id_EstadoPago
                    sds_DatosEP.DataBind()
                    Dim dt_DatosEP As DataTable = CType(sds_DatosEP.Select(DataSourceSelectArguments.Empty), DataView).Table


                    Dim Cliente As String = dt_DatosEP.Rows(0).Item("NombreCliente").ToString()
                    Dim AFI As String = dt_DatosEP.Rows(0).Item("id_Equipo").ToString()
                    Dim Mes As String = dt_DatosEP.Rows(0).Item("Mes").ToString()


                    Dim prueba = New bd_parqueDataSetTableAdapters.up_parque_s_EstadosPagoXidEPTableAdapter,
                    tabla = New bd_parqueDataSet.up_parque_s_EstadosPagoXidEPDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "EstadosDePago.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, vli_id_EstadoPago)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_EstadosDePago", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "E.D.P" + " " + Mes + " " + AFI + " (" + Cliente + ")"
                    End Using

                Case 2 'Actas de entrega
                    Dim actaEntregaTA = New ds_ActaEntregaTableAdapters.up_parque_s_infActaEntregaTableAdapter,
                        actaEntregaDT = New ds_ActaEntrega.up_parque_s_infActaEntregaDataTable,
                        actaEntregaActividadesTA = New ds_ActaEntregaTableAdapters.up_parque_s_infActaEntregaActividadesTableAdapter,
                        actaEntregaActividadesDT = New ds_ActaEntrega.up_parque_s_infActaEntregaActividadesDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "ActaEntrega.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        actaEntregaTA.Fill(actaEntregaDT, pvi_NumeroContrato)
                        actaEntregaActividadesTA.Fill(actaEntregaActividadesDT, pvi_NumeroContrato)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_ActaEntrega", DirectCast(actaEntregaDT, DataTable))
                        Dim rd2 As ReportDataSource = New ReportDataSource("ds_ActaEntregaActividades", DirectCast(actaEntregaActividadesDT, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DataSources.Add(rd2)
                    End Using
                Case 3 'Pautas de mantención
                    Dim prueba = New ds_PautaMantencionTableAdapters.up_parque_s_infPautaMantencionTableAdapter,
                        tabla = New ds_PautaMantencion.up_parque_s_infPautaMantencionDataTable,
                        RepuestosTA = New ds_RepuestosMantencionTableAdapters.up_parque_s_infPautaMantencionRepuestosTableAdapter,
                        RepuestosDT = New ds_RepuestosMantencion.up_parque_s_infPautaMantencionRepuestosDataTable,
                        LubricantesTA = New ds_LubricantesMantencionTableAdapters.up_parque_s_infPautaMantencionLubricantesTableAdapter,
                        LubricantesDT = New ds_LubricantesMantencion.up_parque_s_infPautaMantencionLubricantesDataTable,
                        ActividadesTA = New ds_ActividadesMantencionTableAdapters.up_parque_s_infPautaMantencionActividadesTableAdapter,
                        ActividadesDT = New ds_ActividadesMantencion.up_parque_s_infPautaMantencionActividadesDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "PautaDeMantencion.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, pvi_NumeroEquipo)
                        RepuestosTA.Fill(RepuestosDT, pvi_NumeroEquipo)
                        LubricantesTA.Fill(LubricantesDT, pvi_NumeroEquipo)
                        ActividadesTA.Fill(ActividadesDT, pvi_NumeroEquipo)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_PautaDeMantencion", DirectCast(tabla, DataTable))
                        Dim rd2 As ReportDataSource = New ReportDataSource("ds_RepuestosMantencion", DirectCast(RepuestosDT, DataTable))
                        Dim rd3 As ReportDataSource = New ReportDataSource("ds_LubricantesMantencion", DirectCast(LubricantesDT, DataTable))
                        Dim rd4 As ReportDataSource = New ReportDataSource("ds_ActividadesMantencion", DirectCast(ActividadesDT, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DataSources.Add(rd2)
                        ReportViewer1.LocalReport.DataSources.Add(rd3)
                        ReportViewer1.LocalReport.DataSources.Add(rd4)
                        ReportViewer1.LocalReport.DisplayName = "Pauta de mantención" + " " + pvi_NumeroEquipo
                    End Using
                Case 4 'Certificados de mantencion 
                    Dim prueba = New ds_CertificadoMantencionTableAdapters.up_parque_s_infCertificadoMantencionTableAdapter,
                    tabla = New ds_CertificadoMantencion.up_parque_s_infCertificadoMantencionDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "CertificadoMantencion.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, pvi_idEquipo, pvs_RutCliente)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_CertificadoMantencion", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "Certificado de mantención" + " " + pvi_idEquipo
                    End Using
                Case 5 'Facturación 
                    Dim prueba = New ds_FacturacionTableAdapters.up_parque_s_infFacturacionXfiltrosTableAdapter,
                    tabla = New ds_Facturacion.up_parque_s_infFacturacionXfiltrosDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "Facturacion.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, pvs_RutFacturacion, pvs_Periodo, pvs_Anho, pvi_Tipo, pviSucursal)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_Facturacion", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "Facturación" + " " + pvs_Anho + "/" + pvs_Anho
                    End Using
                Case 6 'Contratos 
                    Dim prueba = New ds_ContratosTableAdapters.up_parque_s_infContratosFiltradosPruebaTableAdapter,
                    tabla = New ds_Contratos.up_parque_s_infContratosFiltradosPruebaDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "Contratos.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, RutCliente, pvi_EstadoContrato, pvi_SucursalInforme)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_Contratos", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                    End Using
                Case 7 'Estados de pago agrupados
                    Dim dt As New DataTable
                    dt = CType(JsonConvert.DeserializeObject(pvs_IdEstados, (GetType(DataTable))), DataTable)
                    Dim prueba = New ds_EstadoDePagoAgrupadoTableAdapters.up_parque_s_EstadosPagoXAgrupacionTableAdapter,
                   tabla = New ds_EstadoDePagoAgrupado.up_parque_s_EstadosPagoXAgrupacionDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "EstadosDePagoAgrupados.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, dt)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_EstadoDePagoAgrupado", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "Estados de pago"
                    End Using
                Case 8 'Recuperación de venta
                    Dim prueba = New ds_RecuperacionVentaTableAdapters.up_parque_s_infRecuperacionVentaTableAdapter,
                    tabla = New ds_RecuperacionVenta.up_parque_s_infRecuperacionVentaDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "RecuperacionVenta.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, RutClienteRecuperacionVenta, pvi_SucursalRecVenta)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_RecuperacionVenta", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "Recuperación de venta"
                    End Using
                Case 9 'Orden de trabajo

                    Dim prueba = New ds_OT2TableAdapters.up_parque_s_OTxIDTableAdapter,
                    tabla = New ds_OT2.up_parque_s_OTxIDDataTable

                    Dim ActividadesTA = New ds_ActividadesXOT2TableAdapters.up_parque_s_ActividadesXOTTableAdapter,
                        ActividadesDT = New ds_ActividadesXOT2.up_parque_s_ActividadesXOTDataTable

                    Dim TrabajadoresTA = New ds_TrabajadoresXOT2TableAdapters.up_parque_s_TrabajadoresXOTTableAdapter,
                        TrabajadoresDT = New ds_TrabajadoresXOT2.up_parque_s_TrabajadoresXOTDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "OT2.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, pvi_idOT)
                        ActividadesTA.Fill(ActividadesDT, pvi_idOT)
                        TrabajadoresTA.Fill(TrabajadoresDT, pvi_idOT)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_OT2", DirectCast(tabla, DataTable))
                        Dim rd2 As ReportDataSource = New ReportDataSource("ds_ActividadesXOT2", DirectCast(ActividadesDT, DataTable))
                        Dim rd3 As ReportDataSource = New ReportDataSource("ds_TrabajadoresXOT2", DirectCast(TrabajadoresDT, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DataSources.Add(rd2)
                        ReportViewer1.LocalReport.DataSources.Add(rd3)
                        ReportViewer1.LocalReport.DisplayName = "Orden de trabajo" + " " + pvi_idOT
                    End Using

                Case 10 'Cotizaciones 

                    sds_CotiXID.SelectParameters("id_Cotizacion").DefaultValue = pvi_idCotizacion
                    sds_CotiXID.DataBind()
                    Dim dt_Coti As DataTable = CType(sds_CotiXID.Select(DataSourceSelectArguments.Empty), DataView).Table
                    Dim Equipo As String = dt_Coti.Rows(0).Item("NombreEquipo").ToString()

                    Dim prueba = New ds_CotizacionesTableAdapters.up_parque_inf_CotizacionXidTableAdapter,
                    tabla = New ds_Cotizaciones.up_parque_inf_CotizacionXidDataTable,
                    ImpleXCotiTA = New ds_ImplementacionXcotiTableAdapters.up_parque_s_ImplementacionesXidCotizacionTableAdapter,
                    ImpleXCotiDT = New ds_ImplementacionXcoti.up_parque_s_ImplementacionesXidCotizacionDataTable,
                    CondiXcotiTA = New ds_CondicionesXcotiTableAdapters.up_parque_s_CondicionesXidCotizacionTableAdapter,
                    CondiXcotiDT = New ds_CondicionesXcoti.up_parque_s_CondicionesXidCotizacionDataTable
                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "Cotizaciones.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, pvi_idCotizacion)
                        ImpleXCotiTA.Fill(ImpleXCotiDT, pvi_idCotizacion)
                        CondiXcotiTA.Fill(CondiXcotiDT, pvi_idCotizacion)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_Cotizaciones", DirectCast(tabla, DataTable))
                        Dim rd2 As ReportDataSource = New ReportDataSource("ds_ImplementacionXcoti", DirectCast(ImpleXCotiDT, DataTable))
                        Dim rd3 As ReportDataSource = New ReportDataSource("ds_CondicionesXcoti", DirectCast(CondiXcotiDT, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DataSources.Add(rd2)
                        ReportViewer1.LocalReport.DataSources.Add(rd3)
                        ReportViewer1.LocalReport.EnableHyperlinks = True
                        ReportViewer1.LocalReport.DisplayName = "Cotización " + pvi_idCotizacion + " (" + Equipo + ")"
                    End Using
                Case 11 'Mantenciones 
                    Dim prueba = New ds_MantencionesTableAdapters.up_parque_s_MantencionEquiposinformeTableAdapter,
                    tabla = New ds_Mantenciones.up_parque_s_MantencionEquiposinformeDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "Mantenciones.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, TipoEquipo, EstadoEquipo, Sucursal)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_MantencionesInforme", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "Informe de mantenciones"
                    End Using
                Case 12 'Informe de equipos 
                    Dim prueba = New ds_EquiposInformeTableAdapters.up_parque_s_InformeEquiposTableAdapter,
                    tabla = New ds_EquiposInforme.up_parque_s_InformeEquiposDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "Equipos.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, pvi_Familia, pvi_EstadoEquipo, pvi_Sucursal, pvs_Cliente)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_EquiposInforme", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "Informe de Equipos"
                    End Using
                Case 13 'Recuperación de venta Todos
                    Dim prueba = New ds_RecuperacionVentasTodosTableAdapters.up_parque_s_infRecuperacionVentaTodosTableAdapter,
                    tabla = New ds_RecuperacionVentasTodos.up_parque_s_infRecuperacionVentaTodosDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "RecuperacionVentaTodos.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, RutClienteRecuperacionVentaTodos, pvi_SucursalRecVenta)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_RecuperacionVentaTodos", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "Recuperación de venta Todos"
                    End Using
                Case 14 'Recuperación de venta Todos
                    Dim prueba = New ds_PagoFacturasTableAdapters.up_parque_s_infPagosTableAdapter,
                    tabla = New ds_PagoFacturas.up_parque_s_infPagosDataTable,
                    prueba2 = New ds_AbonoFacturasTableAdapters.up_parque_s_infAbonosTableAdapter,
                    tabla2 = New ds_AbonoFacturas.up_parque_s_infAbonosDataTable


                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "PagoFacturas.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, pvd_DesdePagoFactura, pvd_HastaPagoFactura, RutClientePagoFactura)
                        prueba2.Fill(tabla2, pvd_DesdePagoFactura, pvd_HastaPagoFactura, RutClientePagoFactura)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_PagoFacturas", DirectCast(tabla, DataTable))
                        Dim rd2 As ReportDataSource = New ReportDataSource("ds_AbonoFacturas", DirectCast(tabla2, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DataSources.Add(rd2)
                        ReportViewer1.LocalReport.DisplayName = "Pago de Facturas"
                    End Using
                Case 15 'Bitacora de por equipo
                    Dim prueba = New ds_BitacoraTableAdapters.up_parque_s_SoloEquipoTableAdapter,
                    tabla = New ds_Bitacora.up_parque_s_SoloEquipoDataTable,
                    prueba2 = New ds_ContratosXEquipoTableAdapters.up_parque_s_ContratosXEquipoTableAdapter,
                    tabla2 = New ds_ContratosXEquipo.up_parque_s_ContratosXEquipoDataTable,
                    prueba3 = New ds_MantencionesXEquipoTableAdapters.up_parque_s_MantencionesXEquipoTableAdapter,
                    tabla3 = New ds_MantencionesXEquipo.up_parque_s_MantencionesXEquipoDataTable,
                    prueba4 = New ds_OTXEquipoTableAdapters.up_parque_s_OTXEquipoTableAdapter,
                    tabla4 = New ds_OTXEquipo.up_parque_s_OTXEquipoDataTable


                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "BitacoraEquipo.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, pvi_idEquipoBitacora)
                        prueba2.Fill(tabla2, pvi_idEquipoBitacora)
                        prueba3.Fill(tabla3, pvi_idEquipoBitacora)
                        prueba4.Fill(tabla4, pvi_idEquipoBitacora)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_Bitacora", DirectCast(tabla, DataTable))
                        Dim rd2 As ReportDataSource = New ReportDataSource("ds_ContratosXEquipo", DirectCast(tabla2, DataTable))
                        Dim rd3 As ReportDataSource = New ReportDataSource("ds_MantencionesXEquipo", DirectCast(tabla3, DataTable))
                        Dim rd4 As ReportDataSource = New ReportDataSource("ds_OTXEquipo", DirectCast(tabla4, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DataSources.Add(rd2)
                        ReportViewer1.LocalReport.DataSources.Add(rd3)
                        ReportViewer1.LocalReport.DataSources.Add(rd4)
                        ReportViewer1.LocalReport.DisplayName = "Bitacora Equipo - " + pvi_idEquipoBitacora + "."
                    End Using
                Case 16 ' Ordenes de compra 
                    Dim prueba = New ds_EncabezadoOCTableAdapters.up_parque_inf_OCxIDTableAdapter,
                    tabla = New ds_EncabezadoOC.up_parque_inf_OCxIDDataTable,
                    prueba2 = New ds_DetalleOC2TableAdapters.up_parque_inf_DetalleOCxIDTableAdapter,
                    tabla2 = New ds_DetalleOC2.up_parque_inf_DetalleOCxIDDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "OC.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, id_OC)
                        prueba2.Fill(tabla2, id_OC)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_EncabezadoOC", DirectCast(tabla, DataTable))
                        Dim rd2 As ReportDataSource = New ReportDataSource("ds_DetalleOC2", DirectCast(tabla2, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DataSources.Add(rd2)
                        ReportViewer1.LocalReport.DisplayName = "Orden de Compra N°" & id_OC
                    End Using
                Case 17 'Pago de Proveedores
                    Dim prueba = New ds_PagoProveedoresTableAdapters.up_parque_s_FacturacionPendienteOCTableAdapter,
                    tabla = New ds_PagoProveedores.up_parque_s_FacturacionPendienteOCDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "PagoProveedores.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, idProveedor, EstadoFactura)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_PagoProveedores", DirectCast(tabla, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DisplayName = "Informe pago proveedores"
                    End Using
                Case 18 'Informe de gastos
                    Dim prueba = New ds_InformeGastosTableAdapters.up_parque_inf_InformeGastosTableAdapter,
                    tabla = New ds_InformeGastos.up_parque_inf_InformeGastosDataTable,
                    prueba2 = New ds_GastosPorProveedorTableAdapters.up_parque_inf_InformeGastosProveedorTableAdapter,
                    tabla2 = New ds_GastosPorProveedor.up_parque_inf_InformeGastosProveedorDataTable,
                    prueba3 = New ds_GastosPorEstadoTableAdapters.up_parque_inf_InformeGastosEstadoTableAdapter,
                    tabla3 = New ds_GastosPorEstado.up_parque_inf_InformeGastosEstadoDataTable,
                    prueba4 = New ds_GastosPorCCostoTableAdapters.up_parque_inf_InformeGastosCCostoTableAdapter,
                    tabla4 = New ds_GastosPorCCosto.up_parque_inf_InformeGastosCCostoDataTable

                    ReportViewer1.ProcessingMode = ProcessingMode.Local
                    ReportViewer1.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Reportes"), "InformeGastos.rdlc")
                    Using conexion = New SqlConnection(ConfigurationManager.ConnectionStrings("SHVTBDConnectionString").ConnectionString)
                        prueba.Fill(tabla, idProveedorInfGastos, EstadoFacturaInfGastos, CCPadreInfGastos, CCHijoInfGastos, MesInfGastos, AnhoInfGastos)
                        prueba2.Fill(tabla2, idProveedorInfGastos, EstadoFacturaInfGastos, CCPadreInfGastos, CCHijoInfGastos, MesInfGastos, AnhoInfGastos)
                        prueba3.Fill(tabla3, idProveedorInfGastos, EstadoFacturaInfGastos, CCPadreInfGastos, CCHijoInfGastos, MesInfGastos, AnhoInfGastos)
                        prueba4.Fill(tabla4, idProveedorInfGastos, EstadoFacturaInfGastos, CCPadreInfGastos, CCHijoInfGastos, MesInfGastos, AnhoInfGastos)
                        Dim rd As ReportDataSource = New ReportDataSource("ds_InfGastos", DirectCast(tabla, DataTable))
                        Dim rd2 As ReportDataSource = New ReportDataSource("ds_GastosPorProveedor", DirectCast(tabla2, DataTable))
                        Dim rd3 As ReportDataSource = New ReportDataSource("ds_GastosPorEstado", DirectCast(tabla3, DataTable))
                        Dim rd4 As ReportDataSource = New ReportDataSource("ds_GastosPorCCosto", DirectCast(tabla4, DataTable))
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(rd)
                        ReportViewer1.LocalReport.DataSources.Add(rd2)
                        ReportViewer1.LocalReport.DataSources.Add(rd3)
                        ReportViewer1.LocalReport.DataSources.Add(rd4)
                        ReportViewer1.LocalReport.DisplayName = "Informe de Gastos"
                    End Using
                Case Else






            End Select



        End If
    End Sub



End Class