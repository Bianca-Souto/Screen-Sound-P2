﻿using ScreenSoundP2.Modelos;
namespace ScreenSoundP2.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodasAsMusicais(List<Musica> musicas)
    {
        var todasAsMusicais = musicas.Select(musicas => musicas.Nome).OrderBy(musicas => musicas).Distinct().ToList();
        foreach (var musica in todasAsMusicais)
        {
            Console.WriteLine($"- {musica}");
        }
    }
    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistasPorGeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).OrderBy(genero => genero).Distinct().ToList();

        Console.WriteLine($"Exibindo os artistas por genero musical {genero}");
        foreach (var artista in artistasPorGeneroMusical)
        {
            Console.WriteLine($"- {artista}");
        }
    }
    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtista)
    {
        var musicasDoArtista = musicas.Where(musica => musica.Artista!.Equals(nomeDoArtista)).ToList();
        Console.WriteLine(nomeDoArtista);
        foreach (var musica in musicasDoArtista)
        {
            Console.WriteLine($"-{musica.Nome}");
        }
    }
    public static void FiltrarMusicarPeloAno(List<Musica> musicas, int ano)
    {
        var musicasDoAno = musicas.Where(musica => musica.Ano == ano).OrderBy(musicas => musicas.Nome).Select(musicas => musicas.Nome).Distinct().ToList();
        Console.WriteLine($"Musicas do ano {ano}");
        foreach (var musica in musicasDoAno)
        {
            Console.WriteLine($"- {musica}");
        }

    }
    public static void FiltrarMusicasPelaTonalidade(List<Musica> musicas, string tonalidade)
    {
        var musicasPorTonalidade = musicas.Where(musica => musica.Tonalidade!.Contains(tonalidade)).Select(musica => musica.Nome).OrderBy(tonalidade => tonalidade).Distinct().ToList();

        Console.WriteLine($"Exibindo as músicas por tonalidade: '{tonalidade}'");
        foreach (var musica in musicasPorTonalidade)
        {
            Console.WriteLine($"- {musica}");
        }
    }
}
