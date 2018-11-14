using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaQuejas.CapaDominio
{
    public class clsRemitente
    {
        #region atributos
            private int atrId;
            private string atrNombre;
            private string atrContrato;
            private string atrTipo;
            private string atrCorreo;
        #endregion
        #region Set-Get
        public void MutarId(int parId)
        {
            this.atrId = parId;
        }
        public int ObtenerId
        {
            get
            {
                return atrId;
            }
            set
            {
                this.atrId = value;
            }

        }
        public string ObtenerNombre
        {
            get
            {
                return this.atrNombre;
            }
            set
            {
                this.atrNombre = value;
            }

        }
        public string ObtenerContrato
        {
            get
            {
                return this.atrContrato;
            }
            set
            {
                this.atrContrato= value;
            }
        }
        public string ObtenerTipo
        {
            get
            {
                return this.atrTipo;
            }
            set
            {
                this.atrTipo = value;
            }

        }
        public string ObtenerCorreo
        {
            get
            {
                return this.atrCorreo;
            }
            set
            {
                this.atrCorreo = value;
            }

        }

        #endregion
        #region Constructores
        public clsRemitente()
            {
            }
        public clsRemitente(int parId, string parNombre, string parContrato, string parTipo, string parCorreo, ref string parMensajeResultado)
        {
            this.atrId = parId;
            this.atrNombre = parNombre;
            this.atrContrato = parContrato;
            this.atrTipo = parTipo;
            this.atrCorreo = parCorreo;
        }
    

        #endregion
        #region Métodos
            public string Insertar(int parId, string parNombre, string parContrato, string parTipo, string parCorreo, ref string parMensaje)
            {
                string varComando = "";
                try
                {
                    
                    if (Encontrar(parId)==null)
                    {
                        clsSQLITE.ConectarBase();
                        //Escribimos la cadena sql

                         varComando = "insert into Remitente values(" + parId+ ",'" + parNombre + "','" + parContrato + "','" + parTipo + "','" + parCorreo + "'"+");";

                        //preparamos la cadena pra insercion (Cedula,Nombre,Telefono,Correo,Direccion,Municipio)
                        SQLiteCommand varInsercion = new SQLiteCommand(varComando, clsSQLITE.atrConexion);
                        //y la ejecutamos
                        varInsercion.ExecuteNonQuery();
                        //finalmente cerramos la conexion ya que solo debe servir para una sola orden


                        return "Remitente Insertado Correctamente";
                    }
                    else
                    {
                        return "ID duplicado, inserte otro ID";
                    }

                }
            catch (Exception e)
            {
                return e.Message;

            }
        }
            public clsRemitente Encontrar(int parId)
            {
                try
                {
                    clsSQLITE.ConectarBase();
                    //Escribimos la cadena sql
                    string varConsulta = "select * from Remitente where Id=" + parId;
                    SQLiteCommand cmd = new SQLiteCommand(varConsulta, clsSQLITE.atrConexion);
                    SQLiteDataReader datos = cmd.ExecuteReader();
                    clsRemitente varObjRemitente = new clsRemitente();

                    while (datos.Read())
                    {
                    
                        this.atrId = (int)datos[0];
                        this.atrNombre= Convert.ToString(datos[1]);
                        this.atrContrato = Convert.ToString(datos[2]);
                        this.atrTipo= Convert.ToString(datos[3]);
                        this.atrCorreo = Convert.ToString(datos[4]);
                        
                    }
                    if (varObjRemitente.ObtenerId != 0)
                    {
                        return varObjRemitente;
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
            public string Actualizar(long parCedula, string parNombre, long parTelefono, string parCorreo, string parDireccion, string parMunicipio)
            {
                try
                {
                    if ((parCedula > 0))
                    {
                        clsSQLITE.ConectarBase();
                        string varComando = "update Cliente set Cedula=" + parCedula + ",Nombre='" + parNombre + "',Telefono=" + parTelefono + ",Correo='" + parCorreo + "',Direccion='" + parDireccion + "',Municipio='" + parMunicipio + "' where Cedula=" + parCedula + ";";
                        //preparamos la cadena pra insercion (Cedula,Nombre,Telefono,Correo,Direccion,Municipio)
                        SQLiteCommand varActualizacion = new SQLiteCommand(varComando, clsSQLITE.atrConexion);
                        //y la ejecutamos
                        varActualizacion.ExecuteNonQuery();
                        varActualizacion.Dispose();
                        //finalmente cerramos la conexion ya que solo debe servir para una sola orden

                        return "Cliente Actualizado Correctamente";
                    }
                    else
                    {
                        return "La cédula ingresada no se encuentra en la base de datos o corresponde a un tipo de dato diferente";
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
