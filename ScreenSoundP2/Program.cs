using System.Text.Json;
using ScreenSoundP2.Modelos;
using ScreenSoundP2.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        //Console.WriteLine(resposta);
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;  //Json convertido para um objeto manipulável no C#
        musicas[563].ExibirDetahesDaMusica();

        //LinqFilter.FiltrarTodasAsMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "pop");
        LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Post Malone");
        LinqFilter.FiltrarMusicarPeloAno(musicas, 2015);
        //LinqFilter.FiltrarMusicasPelaTonalidade(musicas, "C#");


        var musicasPreferidas1 = new MusicasPreferidas("Musicas 1");
        musicasPreferidas1.AdicionarMusicasFavoritas(musicas[567]);
        musicasPreferidas1.AdicionarMusicasFavoritas(musicas[777]);
        musicasPreferidas1.AdicionarMusicasFavoritas(musicas[48]);
        musicasPreferidas1.AdicionarMusicasFavoritas(musicas[695]);
        musicasPreferidas1.AdicionarMusicasFavoritas(musicas[147]);
        musicasPreferidas1.ExibirMusicasFavoritas();

        var musicasPreferidas2 = new MusicasPreferidas("Musicas 2");
        musicasPreferidas2.AdicionarMusicasFavoritas(musicas[13]);
        musicasPreferidas2.AdicionarMusicasFavoritas(musicas[445]);
        musicasPreferidas2.AdicionarMusicasFavoritas(musicas[25]);
        musicasPreferidas2.ExibirMusicasFavoritas();

        musicasPreferidas1.GerarArquivoJson();
    }
    catch (Exception ex) 
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
