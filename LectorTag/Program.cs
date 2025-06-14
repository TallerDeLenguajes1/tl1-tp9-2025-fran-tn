using SpaceStream;
using System;
using System.IO;
using System.Text;

string nombreArchivo = "../Free Gucci.mp3";
string HeaderEnString = "N/A", GeneroEnString = "N/A", ComentarioEnString = "N/A";
string YearEnString = "N/A", AlbumEnString = "N/A", ArtistaEnString  = "N/A", NombreEnString = "N/A";


try
{
    using (FileStream Stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read))
    //Using asegura que luego se cierre el archivo
    {
        using (BinaryReader reader = new BinaryReader(Stream, Encoding.GetEncoding("latin1")))
        //Bynaryreader lee los bytes de forma mas conveniente
        //Se indica la codificacion para saber como manejar la cadena
        {
            long longitudArchivo = Stream.Length;
            //Obtengo la longitud del archivo en bytes

            Console.WriteLine($"Longitud archivo: {longitudArchivo}");

            if (longitudArchivo < 128)
            //La etiqueta ID3v1 Siempre tiene 128 bytes y esta ubicada al final del archivo
            {
                Console.WriteLine("El archivo es demasiado pequeño");
            }
            else
            {
                long PosicionInicio = longitudArchivo - 128;
                //Me posiciono al inicio de la etiqueta

                Stream.Seek(PosicionInicio, SeekOrigin.Begin);
                byte[] bytesDelHeader = reader.ReadBytes(3);
                HeaderEnString = Encoding.GetEncoding("latin1").GetString(bytesDelHeader);

                if (HeaderEnString == "TAG")
                //Verifico que si sea el comienzo de la etiqueta
                {
                    byte[] BytesNombre = reader.ReadBytes(30);
                    //Leo el titulo que son los siguientes 30bytes

                    NombreEnString = Encoding.GetEncoding("latin1").GetString(BytesNombre);

                    byte[] BytesArtista = reader.ReadBytes(30);
                    ArtistaEnString = Encoding.GetEncoding("latin1").GetString(BytesArtista);

                    byte[] BytesAlbum = reader.ReadBytes(30);
                    AlbumEnString = Encoding.GetEncoding("latin1").GetString(BytesAlbum);

                    byte[] BytesYear = reader.ReadBytes(4);
                    YearEnString = Encoding.GetEncoding("latin1").GetString(BytesYear);

                    byte[] BytesGenero = reader.ReadBytes(1);
                    GeneroEnString = Encoding.GetEncoding("latin1").GetString(BytesGenero);
                }
            }

        }
    }   //Usign cierra el filestream y el binaryreader
}
catch (FileNotFoundException)
{
    Console.WriteLine($"El archivo {nombreArchivo} no se ha encontrado");
}

catch (Exception ex)
{
    Console.WriteLine($"Ocurrio un error: {ex.Message}");
}


Datos mostrar = new Datos();
mostrar.cargar(NombreEnString, ArtistaEnString, AlbumEnString, YearEnString, ComentarioEnString, GeneroEnString);
Console.WriteLine("----------------------------TAG ID3v1----------------------------");
Console.WriteLine($"Nombre: {mostrar.Nombre}");
Console.WriteLine($"Artista: {mostrar.Artista}");
Console.WriteLine($"Album: {mostrar.Album}");
Console.WriteLine($"Año: {mostrar.Year}");
Console.WriteLine($"Comentario: {mostrar.Comentario}");
Console.WriteLine($"Genero: {mostrar.Genero}");
