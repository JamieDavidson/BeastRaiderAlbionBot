namespace BeastRaiderAlbionBot.AlbionApiClient.Domain;

public sealed record GuildSearchResult(
    string Id,
    string Name,
    string AllianceId,
    string AllianceName,
    long KillFame,
    long DeathFame);