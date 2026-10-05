using System;

namespace ControlInventario
{
    internal class Program
    {
        // Arreglos globales para almacenar los productos
        static string[] productos = new string[3];
        static int[] cantidades = new int[3];

        static void Main(string[] args)
        {
            int opcion = 0;

            // Primero se registran los productos
            IngresarProductos();

            // Menu principal
            while (opcion != 3)
            {
                Console.WriteLine();
                Console.WriteLine("SISTEMA DE CONTROL DE INVENTARIO");
                Console.WriteLine("================================");
                Console.WriteLine("1. Mostrar inventario");
                Console.WriteLine("2. Vender producto");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opcion: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            MostrarInventario();
                            break;

                        case 2:
                            VenderProducto();
                            break;

                        case 3:
                            Console.WriteLine("Saliendo del sistema...");
                            break;

                        default:
                            Console.WriteLine("Opcion no valida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Debe ingresar un numero.");
                    opcion = 0;
                }
            }

            Console.WriteLine("Presione una tecla para finalizar...");
            Console.ReadKey();
        }

        // Metodo para registrar los productos
        static void IngresarProductos()
        {
            Console.WriteLine("REGISTRO DE PRODUCTOS");
            Console.WriteLine("=====================");
            Console.WriteLine();

            for (int i = 0; i < productos.Length; i++)
            {
                Console.WriteLine("Producto #" + (i + 1));

                Console.Write("Digite el nombre del producto: ");
                productos[i] = Console.ReadLine();

                bool cantidadValida = false;

                while (cantidadValida == false)
                {
                    Console.Write("Digite la cantidad disponible: ");

                    if (int.TryParse(Console.ReadLine(), out cantidades[i]))
                    {
                        if (cantidades[i] >= 0)
                        {
                            cantidadValida = true;
                        }
                        else
                        {
                            Console.WriteLine(
                                "Error: la cantidad no puede ser negativa."
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            "Error: debe ingresar un numero entero."
                        );
                    }
                }

                Console.WriteLine();
            }
        }

        // Metodo para mostrar el inventario
        static void MostrarInventario()
        {
            Console.WriteLine();
            Console.WriteLine("INVENTARIO ACTUAL");
            Console.WriteLine("=================");

            for (int i = 0; i < productos.Length; i++)
            {
                Console.WriteLine(
                    (i + 1) + ". " +
                    productos[i] +
                    " - Unidades disponibles: " +
                    cantidades[i]
                );
            }
        }

        // Metodo para realizar una venta
        static void VenderProducto()
        {
            int opcionProducto;
            int cantidadVenta;

            MostrarInventario();

            Console.WriteLine();
            Console.Write("Digite el numero del producto que desea vender: ");

            if (int.TryParse(Console.ReadLine(), out opcionProducto))
            {
                // Se resta 1 porque los arreglos empiezan en posicion 0
                opcionProducto = opcionProducto - 1;

                if (opcionProducto >= 0 &&
                    opcionProducto < productos.Length)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "Producto seleccionado: " +
                        productos[opcionProducto]
                    );

                    Console.WriteLine(
                        "Unidades disponibles: " +
                        cantidades[opcionProducto]
                    );

                    Console.Write("Cantidad que desea vender: ");

                    if (int.TryParse(Console.ReadLine(), out cantidadVenta))
                    {
                        if (cantidadVenta <= 0)
                        {
                            Console.WriteLine(
                                "La cantidad debe ser mayor que cero."
                            );
                        }
                        else if (
                            cantidadVenta <= cantidades[opcionProducto]
                        )
                        {
                            cantidades[opcionProducto] =
                                cantidades[opcionProducto] - cantidadVenta;

                            Console.WriteLine();
                            Console.WriteLine(
                                "Venta realizada correctamente."
                            );

                            Console.WriteLine(
                                "Producto: " +
                                productos[opcionProducto]
                            );

                            Console.WriteLine(
                                "Cantidad vendida: " +
                                cantidadVenta
                            );

                            Console.WriteLine(
                                "Unidades restantes: " +
                                cantidades[opcionProducto]
                            );
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine(
                                "Venta rechazada."
                            );

                            Console.WriteLine(
                                "No hay suficientes unidades disponibles."
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            "La cantidad ingresada no es valida."
                        );
                    }
                }
                else
                {
                    Console.WriteLine(
                        "El producto seleccionado no existe."
                    );
                }
            }
            else
            {
                Console.WriteLine(
                    "Debe ingresar un numero de producto valido."
                );
            }
        }
    }
}