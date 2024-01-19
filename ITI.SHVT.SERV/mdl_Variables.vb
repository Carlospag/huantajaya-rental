''' <summary>
''' Módulo de variables globales.
''' </summary>
''' <remarks>Marcelo Woloszyn - 01/07/2009</remarks>
Public Module mdl_Variables
    Public Const vgs_NombreSistema As String = "Sistema hoja de vida del trabajador" 'Nombre aplicación
    Public vgs_DirectorioArchivosTemporales As String = System.AppDomain.CurrentDomain.BaseDirectory & "\Equipos\" 'Ruta archivos temporales
    Public vgs_Contratos As String = System.AppDomain.CurrentDomain.BaseDirectory & "\Contratos\" 'Ruta archivos temporales
    Public Const vgl_NroExcepcionReglaNegocio As Long = 0
    Public Const vgs_MensajeGeneralExcepcionReglaNegocio As String = "Ha ocurrido un error al intentar realizar la operación."
    Public Const vgl_NroExcepcionAccesoDatos As Long = 0
    Public Const vgs_MensajeGeneralExcepcionAccesoDatos As String = "Ha ocurrido un error al intentar realizar la operación."
    Public Const vgi_CantidadCerosRUT As Integer = 12
    Public Const vgs_MensajeGeneralDeError As String = "Ha ocurrido un error al intentar realizar la operación."
    Public Const vgsh_TiempoSesion As Short = 15 'Tiempo en minutos de duración de sesión   
    Public Const vgs_URLServidorInformes As String = "http://192.168.66.46/ReportServer" 'URL de servidor de informes - Desarrollo: http://192.168.66.46/ReportServer - Explotación: http://192.168.66.73/ReportServer_SQLEXP2008
    Public Const vgs_UsuarioServidorInformes As String = "servidor_informes" 'Usuario de servidor de informes
    Public Const vgs_ContrasenaUsuarioServidorInformes As String = "serinfo2011" 'Contraseña de usuario de servidor de informes
    Public Const vgs_DominioUsuarioURLServidorInformes As String = "ITISA" 'Dominio de usuario de servidor de informes
    Public Const vgs_DominioActiveDirectory As String = "LDAP://DC=ITI,DC=CL" 'Dominio
    Public Const vgs_URLJavaScript As String = "http://sistemas.iti.cl/app/js/general.js"
    Public Const vgs_URLJavaScriptRUT As String = "http://sistemas.iti.cl/app/js/RUT.js"

    ''' <summary>
    ''' Enumeradores de colocación
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enm_Colocacion As Short
        izquierda
        derecha
    End Enum
    ''' <summary>
    ''' Operaciones de acceso a datos.
    ''' </summary>
    ''' <remarks>Marcelo Woloszyn - 25/09/2009</remarks>
    Public Enum enm_OperacionAccesoDatos As Short
        insercion
        actualizacion
        eliminacion
        seleccion
    End Enum
    ''' <summary>
    ''' Capas de excepciones.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enm_CapaExcepciones As Short
        acceso_datos
        regla_de_negocio
        interfaz_de_usuarioss
    End Enum
    ''' <summary>
    ''' Tipos de formato para informes
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enm_TipoFormato As Short
        pdf = 1
        excel = 2
    End Enum

End Module