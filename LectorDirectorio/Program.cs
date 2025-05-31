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


foreach(string mostrar in archivos)
{
    FileInfo informacion = new FileInfo(mostrar);
    string size = informacion.Length.ToString();
    string date = informacion.LastWriteTime.ToString();
    string[] escribirDatos = {informacion.FullName, size, date}; 
    
    using (StreamWriter writer = new StreamWriter(RutaCSV))
    {
        foreach(string datos in escribirDatos)
        {
            writer.WriteLine(string.Join(",", datos) );
        }
    }

}

