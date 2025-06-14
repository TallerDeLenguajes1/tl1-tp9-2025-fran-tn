namespace SpaceStream;


public class Datos
{
    private string nombre;

    private string artista;

    private string album;

    private string year;

    private string comentario;

    private string genero;

    public void cargar(string cNombre, string cArtista, string cAlbum, string cYear, string cComentario, string cGenero)
    {
        nombre = cNombre;
        artista = cArtista;
        album = cAlbum;
        year = cYear;
        comentario = cComentario;
        genero = cGenero;
    }

    public string Nombre
    {
        get => nombre;
    }

    public string Artista
    {
        get => artista;
    }
    public string Album
    {
        get => album;
    }
    public string Year
    {
        get => year;
    }
    public string Comentario
    {
        get => comentario;
    }
    public string Genero
    {
        get => genero;
    }
}