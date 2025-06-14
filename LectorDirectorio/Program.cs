using System;
using System.IO;

string cargarDatos;
Console.WriteLine("Ingrese la ruta del archivo");
cargarDatos = Console.ReadLine();

while(!Directory.Exists(cargarDatos) )
{
    Console.WriteLine("No se a encontrado el archivo");
    Console.WriteLine("Ingrese la ruta del archivo");
    cargarDatos = Console.ReadLine();
}

string[] directorios = Directory.GetDirectories(cargarDatos);
string[] archivos = Directory.GetFiles(cargarDatos);

int aux = 0;
Console.WriteLine($"Directorios que se encuentran en {cargarDatos}");
foreach(string mostrar in directorios)
{
    aux++;
    Console.WriteLine($"Directorio {aux}: {mostrar}");
}

if(aux == 0)
{
    Console.WriteLine($"No se encontraron directorios en: {cargarDatos}");
} else {
    aux = 0;
}

Console.WriteLine($"Archivos que se encuentran en {cargarDatos}");
foreach(string mostrar in archivos)
{
    aux++;
    FileInfo informacion = new FileInfo(mostrar);
    Console.WriteLine($"Archvo {aux}: {mostrar} ({informacion.Length}KB)");
}

if(aux == 0)
{
    Console.WriteLine($"No se encontraron archivos en: {cargarDatos}");
} else {
    aux = 0;
}

string RutaCSV = cargarDatos + "/reporte_archivos.csv";

if(!File.Exists(RutaCSV))
{
    File.Create(RutaCSV);
}

try
{
    using (StreamWriter writer = new StreamWriter(RutaCSV, true))
    //true es para escribir al final del archivo
    {
        writer.WriteLine("Nombre del archhivo, Tamaño, Fecha de ultima modificacion");
        //Esto escribira una cabecera

        foreach (string archivo in archivos)
        {
            FileInfo informacion = new FileInfo(archivo);
            string nombre = informacion.FullName;
            string tamaño = informacion.Length.ToString();
            string fecha = informacion.LastWriteTime.ToString("dd-MM-yyyy");

            string linea = $"{nombre}, {tamaño}, {fecha}";

            writer.WriteLine(linea);
        }
    }
    Console.WriteLine($"Archivo CSV modificado exitosamente en {RutaCSV}");
}
catch (Exception ex)
{
    Console.WriteLine($"Fallo al guardar el archivo en {RutaCSV}: {ex.Message}");    
}


