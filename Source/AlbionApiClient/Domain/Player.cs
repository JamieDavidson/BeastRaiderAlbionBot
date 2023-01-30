namespace BeastRaiderAlbionBot.AlbionApiClient.Domain;

public sealed record Player(
    string Id,
    string Name,
    string GuildName,
    string AllianceName,
    string AllianceId,
    string AllianceTag,
    long KillFame,
    long DeathFame,
    decimal FameRatio,
    long PvEFame,
    long GatheringFame,
    long CraftingFame);