using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaQuejas.CapaDominio
{
    public class clsPresenta
    {
        #region Atributos
        private clsCliente atrObjCliente;
        private clsSolicitud atrObjSolicitud;
        private string atrFecha;
        private string atrEnvioRespuesta;
        private string atrFechaEnvioRespuesta;
        private string atrEntregaMx;
        private string atrCumplimiento;
        private string atrJustificacion;
        #endregion
        #region Set-Get
        public clsCliente ObtenerCliente
        {
            get
            {
                return atrObjCliente;
            }

        }
        public clsSolicitud ObtenerSolicitud
        {
            get
            {
                return atrObjSolicitud;
            }

        }
        public string ObtenerFecha
        {
            get
            {
                return atrFecha;
            }

        }
        public string ObtenerEnvioRespuesta
        {
            get
            {
                return atrEnvioRespuesta;
            }

        }
        public string ObtenerEntregaMx
        {
            get
            {
                return atrEntregaMx;
            }

        }
        public string ObtenerFechaEnvioRespuesta
        { 
            get
            {
                return atrFechaEnvioRespuesta;
            }

        }
        public string ObtenerCumplimiento
        {
            get
            {
                return atrCumplimiento;
            }

        }
        public string ObtenerJustificacion
        {
            get
            {
                return atrJustificacion;
            }

        }
        #endregion



        #region Constuctores
        public clsPresenta()
        {

        }
        public clsPresenta(clsCliente parObjCliente, clsSolicitud parObjSolicitud, string parFecha, string parEnvioRespuesta, string parFechaEnvioRespuesta, string parEntregaMx, string parCumplimiento, string parJustificacion)
        {
            this.atrObjCliente = parObjCliente;
            this.atrObjSolicitud = parObjSolicitud;
            this.atrFecha = parFecha;
            this.atrEnvioRespuesta = parEnvioRespuesta;
            this.atrFechaEnvioRespuesta = parFechaEnvioRespuesta;
            this.atrEntregaMx = parEntregaMx;
            this.atrCumplimiento = parCumplimiento;
            this.atrJustificacion = parJustificacion;

        }
        #endregion

        #region Metodos
        public clsPresenta Encontrar(long parCedula, int parCarp)
        {
            try
            {

                clsSQLITE.ConectarBase();
                //Escribimos la cadena sql
                string varConsulta = "select * from Presenta where (Cedula=" + parCedula + " and Carp=" + parCarp + ");";
                SQLiteCommand cmd = new SQLiteCommand(varConsulta, clsSQLITE.atrConexion);
                SQLiteDataReader datos = cmd.ExecuteReader();
                clsPresenta varObjPresenta = new clsPresenta();
                clsSolicitud varObjSolicitud = new clsSolicitud();
                clsCliente varObjCliente = new clsCliente();

                while (datos.Read())
                {
                    this.atrObjCliente = varObjCliente.Encontrar((long)datos[0]);
                    this.atrObjSolicitud = varObjSolicitud.Encontrar((int)datos[1]);
                    this.atrFecha = Convert.ToString(datos[2]);
                    this.atrEnvioRespuesta = Convert.ToString(datos[3]);
                    this.atrFechaEnvioRespuesta = Convert.ToString(datos[4]);
                    this.atrEntregaMx = Convert.ToString(datos[5]);
                    this.atrCumplimiento = Convert.ToString(datos[6]);
                    this.atrJustificacion = Convert.ToString(datos[7]);

                }
                datos.Dispose();
                cmd.Dispose();


                if ((varObjPresenta.ObtenerCliente!=null) &&(varObjPresenta.ObtenerSolicitud!=null))
                {
                    return varObjPresenta;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
               
                return null;
            }
           

            }
        public string Insertar(long parCedula,int parCarp, string parFecha, string parEnvioRespuesta, string parFechaEnvioRespuesta, string parEntregaMx, string parCumplimiento, string parJustificacion, string parInf)
        {

            string varComando = "";
            try
            {
                        clsSQLITE.ConectarBase();
                        //Escribimos la cadena sql
                        //insert into Presenta values(48600804,1,'24/12/2018','Si','25/12/2018','Si','si','no responden');
                        varComando = "insert into Presenta values(" + parCedula + "," + parCarp + ",'" + parFecha + "','" + parEnvioRespuesta + "','" + parFechaEnvioRespuesta + "','" + parEntregaMx + "','" + parCumplimiento + "','" + parJustificacion +"','"+parInf+"');";

                        //preparamos la cadena pra insercion (Cedula,Nombre,Telefono,Correo,Direccion,Municipio)
                        SQLiteCommand varInsercion = new SQLiteCommand(varComando, clsSQLITE.atrConexion);
                        //y la ejecutamos
                        varInsercion.ExecuteNonQuery();
                //finalmente cerramos la conexion ya que solo debe servir para una sola orden
                return "Exito";

            }
            catch (Exception e)
            {
                return e.Message;

            }
        }


        }
        #endregion

    }

