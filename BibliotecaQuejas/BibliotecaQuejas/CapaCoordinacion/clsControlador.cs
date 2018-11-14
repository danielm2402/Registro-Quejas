using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using BibliotecaQuejas.CapaDominio;
using System.Threading.Tasks;

namespace BibliotecaQuejas.CapaCoordinacion
{
    public static class clsControlador
    {
        
        public static string atrMensajeResultado;


        #region Cliente
        public static void AddCliente(long parCedula, string parNombre, long parTelefono, string parCorreo, string parDireccion, string parMunicipio)
        {
            clsCliente varObjCliente = new clsCliente(parCedula, parNombre, parTelefono, parCorreo, parDireccion, parMunicipio, ref atrMensajeResultado);
            atrMensajeResultado = varObjCliente.Insertar(parCedula, parNombre, parTelefono, parCorreo, parDireccion, parMunicipio);
        }

        public static void EncontrarCliente(long parCedula)
        {
            clsCliente varObjCliente = new clsCliente();
            varObjCliente.Encontrar(parCedula);
            atrMensajeResultado = varObjCliente.ObtenerNombre;

        }
        public static void ActualizarCliente(long parCedula, string parNombre, long parTelefono, string parCorreo, string parDireccion, string parMunicipio)
        {
            clsCliente varObjCliente = new clsCliente();
            atrMensajeResultado = varObjCliente.Actualizar(parCedula, parNombre, parTelefono, parCorreo, parDireccion, parMunicipio);
        }
        #endregion
        #region Remitente
        public static void AddRemitente(int parId, string parNombre, string parContrato, string parTipo, string parCorreo)
        {
            clsRemitente varObjRemitente = new clsRemitente(parId, parNombre, parContrato, parTipo, parCorreo, ref atrMensajeResultado);
            atrMensajeResultado=varObjRemitente.Insertar(parId, parNombre, parContrato, parTipo, parCorreo, ref atrMensajeResultado);
        }
        public static void EncontrarRemitente(int parId)
        {
            clsRemitente varObjRemitente = new clsRemitente();
            varObjRemitente.Encontrar(parId);
            atrMensajeResultado=Convert.ToString( varObjRemitente.ObtenerId);

        }
        public static void ActualizarRemitente(long parCedula, string parNombre, long parTelefono, string parCorreo, string parDireccion, string parMunicipio)
        {
            clsCliente varObjCliente = new clsCliente();
            atrMensajeResultado = varObjCliente.Actualizar(parCedula, parNombre, parTelefono, parCorreo, parDireccion, parMunicipio);
        }
        #endregion
        #region Solicitud
        public static void AddSolicitud(int parCarp, string parConsecutivo, string parDepartamento, string parEstado, string parTipo, string parMedio, string parMotivo, string parMedicamento, string parCapitaEvento, string parMunicipioAplica, int parIdRemitente)
        {
            clsRemitente varObjRemitente = new clsRemitente();
            varObjRemitente.Encontrar(parIdRemitente);
            if (varObjRemitente.ObtenerId != 0)
            {
                clsSolicitud varObjSolicitud = new clsSolicitud();
                atrMensajeResultado = varObjSolicitud.Insertar(parCarp, parConsecutivo, parDepartamento, parEstado, parTipo, parMedio, parMotivo, parMedicamento, parCapitaEvento, parMunicipioAplica, varObjRemitente);

            }
            else
                atrMensajeResultado = "ID del remitente no encontrada";




        }
        public static void EncontrarSolicitud(int parCarp)
        {
            clsSolicitud varObjSolicitud = new clsSolicitud();
            varObjSolicitud.Encontrar(parCarp);
            atrMensajeResultado = varObjSolicitud.ObtenerConsecutivo;
        }
        public static void ActualizarSolicitud(int parCarp, string parConsecutivo, string parDepartamento, string parEstado, string parTipo, string parMedio, string parMotivo, string parMedicamento, string parCapitaEvento, string parMunicipioAplica, int parIdRemitente)
        {
            clsSolicitud varObjSolicitud = new clsSolicitud();
            clsRemitente varObjRemitente = new clsRemitente();
            varObjRemitente.Encontrar(parIdRemitente);
            atrMensajeResultado = varObjSolicitud.Actualizar(parCarp, parConsecutivo, parDepartamento, parEstado, parTipo, parMedio, parMotivo, parMedicamento, parCapitaEvento, parMunicipioAplica, varObjRemitente);
        }
        #endregion
        #region Presenta
        public static void EncontrarPresentacion(long parCedula, int parCarp)
        {
            clsPresenta varObjPresenta = new clsPresenta();
            varObjPresenta.Encontrar(parCedula,parCarp);
            atrMensajeResultado= varObjPresenta.ObtenerFecha;

            

        }
        public static void InsertarPresentacion(long parCedulaCliente, int parCarpSolicitud, string parFecha, string parEnvioRespuesta, string parFechaEnvioRespuesta, string parEntregaMx, string parCumplimiento, string parJustificacion,string parInf)
        {
            clsCliente varObjCliente = new clsCliente();
            varObjCliente.Encontrar(parCedulaCliente);

            clsSolicitud varObjSolicitud = new clsSolicitud();
            varObjSolicitud.Encontrar(parCarpSolicitud);


            if (varObjCliente.ObtenerCedula!=0 && varObjSolicitud.ObtenerCarp!=0)
            {
                clsPresenta varObjPresenta = new clsPresenta();
                atrMensajeResultado = varObjPresenta.Insertar(parCedulaCliente, parCarpSolicitud, parFecha, parEnvioRespuesta, parFechaEnvioRespuesta, parEntregaMx, parCumplimiento, parJustificacion, parInf);
            }
            else
            {
                atrMensajeResultado = "Verifique que la cedula y carp ingresados ya estén previamente registrados";
            }
                
        }
        #endregion


    }
}
