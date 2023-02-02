using BeastRaiderAlbionBot.Service.Commands;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

internal sealed class Program
{
    public static readonly DiscordSocketClient _discordClient = new();

    public static Task Main(string[] args) => new Program().MainAsync();

    private async Task MainAsync()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<BeastRaider>();
        
        var configurationRoot = builder.Build();
        var options = configurationRoot.GetSection("BeastRaider").Get<BeastRaider>();
        var token = options!.Token;
        
        await _discordClient.LoginAsync(TokenType.Bot, token);
        await _discordClient.StartAsync();
        
        _discordClient.Ready += RegisterCommands.SetupSlashCommands;
        _discordClient.SlashCommandExecuted += RootCommandHandler.HandleSlashCommand;
        
        await Task.Delay(-1);
    }
}