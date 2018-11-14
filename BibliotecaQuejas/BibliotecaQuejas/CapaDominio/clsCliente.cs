using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaQuejas.CapaDominio
{
    public class clsCliente
    {
        #region Atributos
        private long atrCedula;
        private string atrNombre;
        private long atrTelefono;
        private string atrCorreo;
        private string atrDireccion;
        private string atrMunicipio;
        #endregion

        #region Set-Get
        public string ObtenerNombre
        {
            get
            {
                return atrNombre;
            }
           
        }
        public long ObtenerCedula
        {
            get
            {
                return this.atrCedula;
            }

        }
        public long ObtenerTelefono
        {
            get
            {
                return this.atrTelefono;
            }

        }
        public string ObtenerDireccion
        {
            get
            {
                return this.atrDireccion;
            }

        }
        public string ObtenerMunicipio
        {
            get
            {
                return this.atrMunicipio;
            }

        }
        public string ObtenerCorreo
        {
            get
            {
                return this.atrCorreo;
            }

        }
        #endregion

        #region Constructores
        public clsCliente()
        {

        }
        public clsCliente(long parCedula, string parNombre, long parTelefono, string parCorreo, string parDireccion, string parMunicipio, ref string parMensajeResultado)
        {
           
            this.atrCedula = parCedula;
            this.atrNombre = parNombre;
            this.atrTelefono = parTelefono;
            this.atrCorreo = parCorreo;
            this.atrDireccion = parDireccion;
            this.atrMunicipio = parMunicipio;
            
        }
        #endregion
        #region Métodos
        public string Insertar(long parCedula, string parNombre, long parTelefono, string parCorreo, string parDireccion, string parMunicipio)
        {
            string varComando = "";
            try
            {

                if (Encontrar(parCedula) == null)
                {
                    clsSQLITE.ConectarBase();
                    //Escribimos la cadena sql

                    varComando = "insert into Cliente values(" + parCedula + ",'" + parNombre + "'," + parTelefono + ",'" + parCorreo + "','" + parDireccion +"','"+parMunicipio + "'" + ");";

                    //preparamos la cadena pra insercion (Cedula,Nombre,Telefono,Correo,Direccion,Municipio)
                    SQLiteCommand varInsercion = new SQLiteCommand(varComando, clsSQLITE.atrConexion);
                    //y la ejecutamos
                    varInsercion.ExecuteNonQuery();
                    //finalmente cerramos la conexion ya que solo debe servir para una sola orden


                    return "Cliente Insertado Correctamente";
                }
                else
                {
                    return "Cédula duplicada, inserte otra";
                }

            }
            catch (Exception e)
            {
                return e.Message;

            }
        }
        public clsCliente Encontrar(long parCedula)
        {
            try
            {
                clsSQLITE.ConectarBase();
                //Escribimos la cadena sql
                string varConsulta = "select * from Cliente where Cedula=" + parCedula;
                SQLiteCommand cmd = new SQLiteCommand(varConsulta, clsSQLITE.atrConexion);
                SQLiteDataReader datos = cmd.ExecuteReader();
                clsCliente varObjCliente = new clsCliente();

                while (datos.Read())
                {
                    this.atrCedula = (long)datos[0];
                    this.atrNombre = Convert.ToString(datos[1]);
                    this.atrTelefono = (long)datos[2];
                    this.atrCorreo = Convert.ToString(datos[3]);
                    this.atrDireccion = Convert.ToString(datos[4]);
                    this.atrMunicipio = Convert.ToString(datos[5]);
                }
                cmd.Dispose();
                if (varObjCliente.ObtenerCedula != 0)
                {
                    return varObjCliente;
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

                    return "Error, por favor contacte al administrador y anexe el siguiente mensaje: "+ e.Message;
                }
         }
        #endregion



    }

}

  


