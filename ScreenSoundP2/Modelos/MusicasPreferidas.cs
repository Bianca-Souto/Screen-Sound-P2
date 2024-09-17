using System.Text.Json;
namespace ScreenSoundP2.Modelos;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }
    public List<Musica> ListaDeMusicasFavoritas { get; }

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        ListaDeMusicasFavoritas = new List<Musica>();
    }

    public void AdicionarMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Essas são as suas músicas favoritas: '{Nome}'");
        foreach (var musica in ListaDeMusicasFavoritas)
        {
            Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
        }
        Console.WriteLine();
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new     //Vamos serializar, vamos fazer o oposto, ou seja, convertelos em arquivos Json
        {
            nome = Nome,
            musicas = ListaDeMusicasFavoritas
        });
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"O arquivo Json foi criado com sucesso.{Path.GetFullPath(nomeDoArquivo)}");
    }
}
