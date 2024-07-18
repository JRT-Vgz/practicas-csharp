using libPedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_cf_app_pedidos
{
    public static class FuncionesPrincipales
    {
        #region Propiedades
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        public static void EjemploCliente()
        {
            Console.WriteLine("############################################################################################");
            Console.WriteLine("#################### PRUEBAS CLASE CLIENTES (QUE HEREDA DE PERSONAS ########################");
            Console.WriteLine("############################################################################################\n");
            clsClientes cliente;
            cliente = new clsClientes();

            cliente.idCliente = 1;
            cliente.NombreCompleto = "Xaxi Pistachi";
            cliente.Rfc = "HEHM010165";

            Console.WriteLine($"cliente.idCliente tiene valor {cliente.idCliente} y es de tipo {cliente.idCliente.GetType()}.");
            Console.WriteLine($"cliente.NombreCompleto tiene valor {cliente.NombreCompleto} y es de tipo {cliente.NombreCompleto.GetType()}.");
            Console.WriteLine($"cliente.Rfc tiene valor {cliente.Rfc} y es de tipo {cliente.Rfc.GetType()}.");
            Console.WriteLine(cliente.ToString());

            Console.WriteLine("\n############################################################################################");
            Console.WriteLine("############################################################################################\n");
        }

        public static void EjemploRecordProducto()
        {
            Console.WriteLine("\n############################################################################################");
            Console.WriteLine("########################## PRUEBAS CLASE PRODUCTOS Y REGISTRO ##############################");
            Console.WriteLine("############################################################################################");
            clsProductos Producto = new clsProductos();
            Producto.idProducto = 1;
            Producto.Descripcion = "Refresco de Manzana";
            Producto.CodigoBarras = "0001";

            clsProductos Producto2 = new clsProductos();
            Producto2 = Producto;

            recProductos rProducto = new recProductos(1, "Refresco de Manzana", "0001");
            recProductos rProducto2 = rProducto;

            Console.WriteLine(" Producto: " + Producto);
            Console.WriteLine(" Producto2: " + Producto2);
            Console.WriteLine(" rProducto: " + rProducto);
            Console.WriteLine(" rProducto2: " + rProducto2);

            if (Producto == Producto2)
                Console.WriteLine("\nLos objetos son iguales");
            else
                Console.WriteLine("\nLos objetos son diferentes");

            if (rProducto == rProducto2)
                Console.WriteLine("Los registros son iguales");
            else
                Console.WriteLine("Los registros son diferentes");

            Console.WriteLine("\n################## CAMBIAMOS UNA VARIABLE DEL OBJETO 2 (DE LA CLASE) ######################");
            Console.WriteLine("####### CREAMOS UN REGISTRO CON WITH, DECLARANDO NUEVA VARIABLE EN LA INSTANCIACION #######");
            Producto2.CodigoBarras = "0";
            recProductos rProducto3 = rProducto with { CodigoBarras = "0" };

            Console.WriteLine(" Producto: " + Producto);
            Console.WriteLine(" Producto2: " + Producto2);
            Console.WriteLine(" rProducto: " + rProducto);
            Console.WriteLine(" rProducto3: " + rProducto3);

            if (Producto == Producto2)
                Console.WriteLine("\nLos objetos son iguales");
            else
                Console.WriteLine("\nLos objetos son diferentes");

            if (rProducto == rProducto3)
                Console.WriteLine("Los registros son iguales");
            else
                Console.WriteLine("Los registros son diferentes");

            Console.WriteLine("\n############################################################################################");
            Console.WriteLine("############################################################################################\n");
        }

        public static void EjemploDesglosaImpuestos()
        {
            Console.WriteLine("\n############################################################################################");
            Console.WriteLine("########################## PRUEBAS PASAR PARAMETROS A METODOS ##############################");
            Console.WriteLine("############################################################################################");

            clsProductosPrecios Producto = new clsProductosPrecios();

            Producto.idProducto = 1;
            Producto.Descripcion = "Refresco de Manzana";
            Producto.CodigoBarras = "0001";

            Producto.PrecioPublico = 17.5m;
            Producto.PrecioMayoreo = 17;
            Producto.PorcentajeIva = 16;
            Producto.PorcentajeIeps = 8;

            Console.WriteLine(Producto);

            recMontosImpuestos Montos = new recMontosImpuestos(0,0);

            decimal precioSinImpuestos = Producto.DesglosaImpuestos(Montos);
            Console.WriteLine($"Precio sin impuestos: {precioSinImpuestos.ToString("C")}");
            Console.WriteLine($"Montos: {Montos}");

            Console.WriteLine("\n############################################################################################");
            Console.WriteLine("############################################################################################\n");
        }
        #endregion
    }
}
