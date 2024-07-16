
using libClientes;

clsClientes cliente;
cliente = new clsClientes();

cliente.idCliente = 1;
cliente.NombreCompleto = "Xaxi Pistachi";
cliente.Rfc = "HEHM010165";

Console.WriteLine($"cliente.idCliente tiene valor {cliente.idCliente} y es de tipo {cliente.idCliente.GetType()}.");
Console.WriteLine($"cliente.NombreCompleto tiene valor {cliente.NombreCompleto} y es de tipo {cliente.NombreCompleto.GetType()}.");
Console.WriteLine($"cliente.Rfc tiene valor {cliente.Rfc} y es de tipo {cliente.Rfc.GetType()}.");
Console.WriteLine(cliente.ToString());
