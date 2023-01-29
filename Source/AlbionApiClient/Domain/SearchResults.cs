namespace BeastRaiderAlbionBot.AlbionApiClient.Domain;

public sealed record SearchResults(
    IReadOnlyCollection<PlayerSearchResult> Players,
    IReadOnlyCollection<GuildSearchResult> Guilds);
