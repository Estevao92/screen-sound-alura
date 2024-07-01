using ScreenSound_04.Modelos;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        LinqFilter.FiltrarMusicasEmCSharp(musicas);

        musicas[2].ExibirDetalhesDaMusica();
        LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        LinqFilter.FIltrarMusicasDeUmArtista(musicas, "Michael Jackson");

        var musicasPreferidasDoEstevao = new MusicasPreferidas("Estevão");
        musicasPreferidasDoEstevao.AdicionarMusicasFavoritas(musicas[5]);
        musicasPreferidasDoEstevao.AdicionarMusicasFavoritas(musicas[8]);
        musicasPreferidasDoEstevao.AdicionarMusicasFavoritas(musicas[1992]);
        musicasPreferidasDoEstevao.AdicionarMusicasFavoritas(musicas[1962]);
        musicasPreferidasDoEstevao.AdicionarMusicasFavoritas(musicas[1935]);

        musicasPreferidasDoEstevao.ExibirMusicasFavoritas();

        musicasPreferidasDoEstevao.GerarArquivoJson();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}