
global using libPedidos;
using _01_cf_app_pedidos;

int opcion = 0;
do
{
    Console.WriteLine(" --- MENÚ DE OPCIONES ---");
    Console.WriteLine("1. Ejemplo de cliente.");
    Console.WriteLine("2. Ejemplo de record de producto.");
    Console.WriteLine("3. Ejemplo de pasar parámetros a un método");
    Console.WriteLine("4. Ejemplo de colección de clientes.");
    Console.WriteLine("5. Ejemplo de diccionario.");
    Console.WriteLine("20. Salir.");
    opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            FuncionesPrincipales.EjemploCliente();
            break;
        case 2:
            FuncionesPrincipales.EjemploRecordProducto();
            break;
        case 3:
            FuncionesPrincipales.EjemploDesglosaImpuestos();
            break;
        case 4:
            FuncionesPrincipales.EjemploColeccionesClientes();
            break;
        case 5:
            FuncionesPrincipales.EjemploDiccionario();
            break;
        default:
            break;
    }
} while (opcion != 20);