namespace BeastRaiderAlbionBot.AlbionApiClient.Domain;

public sealed record PlayerSearchResult(
    string Id,
    string Name,
    string GuildId,
    string AllianceId,
    string Avatar,
    string AvatarRing,
    long KillFame,
    long DeathFame,
    decimal FameRatio,
    long TotalKills,
    long GuildVsGuildKills,
    long GuildVsGuildWon);