using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaQuejas.CapaDominio
{
    public static class clsSQLITE
    {
        public static SQLiteConnection atrConexion;
        private static string atrUbicacion= "";
        public static string atrMensajeResultado;
        public static void UbicacionBase(string parUbicacion)
        {
            atrUbicacion = parUbicacion;
        }

        public static void ConectarBase()
        {
            try
            {
                //C:\Program Files (x86)\Microsoft\InstaladorAppQuejas
               atrConexion = new SQLiteConnection(@"Data source=" +atrUbicacion+@"\Quejas.db;version=3;Pooling=true");
                //atrConexion = new SQLiteConnection(@"Data Source=C:\Users\Daniel\Documents\Quejas.db;Version=3;Pooling=true");
               // atrConexion = new SQLiteConnection(@"Data Source= Quejas.db;Version=3;Pooling=true");
                atrConexion.Open();
                atrMensajeResultado = "Conexión realizada con éxito";
            }
            catch (Exception e)
            {
                atrMensajeResultado = "Fallo en conexión, contacte al administrador y anexe el siguiente mensaje: " + e.Message;

            }
        }

        public static DataTable TablaCliente()
 {
                clsSQLITE.ConectarBase();
          string consulta = "select * from Cliente";
 

         // Adaptador de datos, DataSet y tabla
         SQLiteDataAdapter db = new SQLiteDataAdapter(consulta, atrConexion);

         DataSet ds = new DataSet();
         ds.Reset();

         DataTable dt = new DataTable();
         db.Fill(ds);

 
         //Asigna al DataTable la primer tabla (ciudades) 
         // y la mostramos en el DataGridView
         dt = ds.Tables[0];

                // Y ya podemos cerrar la conexion

                return dt;
 }

        public static DataTable TablaRemitente()
        {
            clsSQLITE.ConectarBase();
            string consulta = "select * from Remitente";


            // Adaptador de datos, DataSet y tabla
            SQLiteDataAdapter db = new SQLiteDataAdapter(consulta, atrConexion);

            DataSet ds = new DataSet();
            ds.Reset();

            DataTable dt = new DataTable();
            db.Fill(ds);


            //Asigna al DataTable la primer tabla (ciudades) 
            // y la mostramos en el DataGridView
            dt = ds.Tables[0];

            // Y ya podemos cerrar la conexion

            return dt;
        }
        public static DataTable TablaSolicitud()
        {
            clsSQLITE.ConectarBase();
            string consulta = "select * from Solicitud";


            // Adaptador de datos, DataSet y tabla
            SQLiteDataAdapter db = new SQLiteDataAdapter(consulta, atrConexion);

            DataSet ds = new DataSet();
            ds.Reset();

            DataTable dt = new DataTable();
            db.Fill(ds);


            // y la mostramos en el DataGridView
            dt = ds.Tables[0];

            // Y ya podemos cerrar la conexion

            return dt;
        }
        public static DataTable TablaPresenta()
        {
            clsSQLITE.ConectarBase();
            string consulta = "select * from Presenta";


            // Adaptador de datos, DataSet y tabla
            SQLiteDataAdapter db = new SQLiteDataAdapter(consulta, atrConexion);

            DataSet ds = new DataSet();
            ds.Reset();

            DataTable dt = new DataTable();
            db.Fill(ds);


            // y la mostramos en el DataGridView
            dt = ds.Tables[0];

            // Y ya podemos cerrar la conexion

            return dt;
        }
        public static DataTable TablaExcel()
        {
            clsSQLITE.ConectarBase();
            string consulta = " Select* FROM(select* FROM Solicitud S, Remitente R where S.IdRemitente= R.Id)X,(select * FROM Presenta P, Cliente C where P.Cedula = C.Cedula)Y where X.Carp = Y.Carp;";


            // Adaptador de datos, DataSet y tabla
            SQLiteDataAdapter db = new SQLiteDataAdapter(consulta, atrConexion);

            DataSet ds = new DataSet();
            ds.Reset();

            DataTable dt = new DataTable();
            db.Fill(ds);


            // y la mostramos en el DataGridView
            dt = ds.Tables[0];

            // Y ya podemos cerrar la conexion

            return dt;
           
        }


    }
}
