using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaQuejas.CapaDominio
{
   public class clsSolicitud
    {
        #region Atributos
        private int atrCarp;
        private string atrConsecutivo;
        private string atrDepartamento;
        private string atrEstado;
        private string atrTipo;
        private string atrMedio;
        private string atrMotivo;
        private string atrMedicamento;
        private string atrCapitaEvento;
        private string atrMunicipioAplica;
        private clsRemitente atrObjRemitente;
        #endregion
        #region Set-Get
        public int ObtenerCarp
        {
            get
            {
                return this.atrCarp;
            }
        }
        public string ObtenerConsecutivo
        {
            get
            {
                return this.atrConsecutivo;
            }
        }
        public string ObtenerDepartamento
        {
            get
            {
                return this.atrDepartamento;
            }
        }
        public string ObtenerEstado
        {
            get
            {
                return this.atrEstado;
            }
        }
        public string ObtenerTipo
        {
            get
            {
                return this.atrTipo;
            }
        }
        public string ObtenerMedio
        {
            get

            {
                return this.atrMedio;
            }
        }
        public string ObtenerMotivo
        {
            get
            {
                return this.atrMotivo;
            }
        }
        public string ObtenerMedicamento
        {
            get
            {
                return this.atrMedicamento;
            }
        }
        public string ObtenerCapitaEvento
        {
            get
            {
                return this.atrCapitaEvento
;
            }
        }
        public string ObtenerMunicipioAplica
        { 
            get
            {
                return this.atrMunicipioAplica;
            }
        }
        public clsRemitente ObtenerRemitente
        {
            get
            {
                return this.atrObjRemitente;
            }
        }
        #endregion

        #region Constructores
        public clsSolicitud()
        {

        }
        public clsSolicitud(int parCarp, string parConsecutivo, string parDepartamento, string parEstado, string parTipo, string parMedio, string parMotivo, string parMedicamento, string parCapitaEvento, string parMunicipioAplica, clsRemitente parObjRemitente, ref string parMensajeResultado)
        {
            this.atrCarp = parCarp;
            this.atrConsecutivo = parConsecutivo;
            this.atrDepartamento = parDepartamento;
            this.atrEstado = parEstado;
            this.atrTipo = parTipo;
            this.atrMedio = parMedio;
            this.atrMotivo = parMotivo;
            this.atrMedicamento = parMedicamento;
            this.atrCapitaEvento = parCapitaEvento;
            this.atrMunicipioAplica = parMunicipioAplica;
            this.atrObjRemitente = parObjRemitente;
           parMensajeResultado= Insertar(parCarp, parConsecutivo, parDepartamento, parEstado, parTipo, parMedio, parMotivo, parMedicamento, parCapitaEvento, parMunicipioAplica, parObjRemitente);
        }

        #endregion
        #region Métodos
        public string Insertar(int parCarp, string parConsecutivo, string parDepartamento, string parEstado, string parTipo, string parMedio, string parMotivo, string parMedicamento, string parCapitaEvento, string parMunicipioAplica, clsRemitente parObjRemitente)
        {
            try
            {
                clsSolicitud v = new clsSolicitud();
                if (true)
                {
                    clsSQLITE.ConectarBase();
                    //Escribimos la cadena sql

                    string varComando = "insert into Solicitud values(" + parCarp + ",'" + parConsecutivo + "','" + parDepartamento + "','" + parEstado + "','" + parTipo + "','" + parMedio + "','" + parMotivo + "','" + parMedicamento + "','" + parCapitaEvento + "','" + parMunicipioAplica + "'," + parObjRemitente.ObtenerId + ");";
                    SQLiteCommand varInsercion = new SQLiteCommand(varComando, clsSQLITE.atrConexion);
                    //y la ejecutamos
                    varInsercion.ExecuteNonQuery();
                    return "Solicitud Insertada con éxito";
                }
                else
                {
                    return "Ya existe una Solicitud con ese mismo CARP o el CARP insertado corresponde a un valor incorrecto";
                }


                }
            catch (Exception e)
            {

                return e.Message;
            }   
                    
                }
 
        public clsSolicitud Encontrar(int parCarp)
                    {
                        try
                        {
                            clsSQLITE.ConectarBase();
                            //Escribimos la cadena sql
                            string varConsulta = "select * from Solicitud where Carp=" + parCarp;
                            SQLiteCommand cmd = new SQLiteCommand(varConsulta, clsSQLITE.atrConexion);
                            SQLiteDataReader datos = cmd.ExecuteReader();
                            clsSolicitud varObjSolicitud = new clsSolicitud();
                            clsRemitente varObjRemitente = new clsRemitente();
                            int varId;

                            while (datos.Read())
                            {
                                                this.atrCarp = (int)datos[0];
                                                this.atrConsecutivo = Convert.ToString(datos[1]);
                                                this.atrDepartamento = Convert.ToString(datos[2]);
                                                this.atrEstado = Convert.ToString(datos[3]);
                                                this.atrTipo = Convert.ToString(datos[4]);
                                                this.atrMedio = Convert.ToString(datos[5]);
                                                this.atrMotivo= Convert.ToString(datos[6]);
                                                this.atrMedicamento = Convert.ToString(datos[7]);
                                                this.atrCapitaEvento = Convert.ToString(datos[8]);
                                                 this.atrMunicipioAplica = Convert.ToString(datos[9]);
                                                varId = (int)datos[10];
                              
                            }
                    this.atrObjRemitente = varObjRemitente.Encontrar((int)datos[9]);
                cmd.Dispose();
                if (varObjSolicitud.ObtenerCarp != 0)
                            {
                                return varObjSolicitud;
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
        public string Actualizar(int parCarp, string parConsecutivo, string parDepartamento, string parEstado, string parTipo, string parMedio, string parMotivo, string parMedicamento, string parCapitaEvento, string parMunicipioAplica, clsRemitente parObjRemitente)
        {
            
            try
            {
                
     
                if (true)
                {
                    clsSQLITE.ConectarBase();
                    string varComando = "update Solicitud set Carp=" + parCarp + ",Consecutivo='" + parConsecutivo + "',Departamento='" + parDepartamento + "',Estado='" + parEstado + "',Tipo='" + parTipo + "',Medio='" + parMedio + "',Motivo='" + parMotivo + "',Medicamento='" + parMedicamento + "',CapitaEvento='" + parCapitaEvento + "',MunicipioAplica='" + parMunicipioAplica + "',IdRemitente=" + parObjRemitente.ObtenerId + " where Carp=" + parCarp + ";";
                    SQLiteCommand varActualizacion = new SQLiteCommand(varComando, clsSQLITE.atrConexion);
                    //y la ejecutamos
                    varActualizacion.ExecuteNonQuery();
                    //finalmente cerramos la conexion ya que solo debe servir para una sola orden

                    return "Actualizado Correctamente";
                }
                else
                {
                    return "eas";
                }
            }
            catch (Exception e)
            {

                return "Error, por favor contacte al administrador y anexe el siguiente mensaje: " + e.Message;
            }

           
        }
        #endregion

    }
}
