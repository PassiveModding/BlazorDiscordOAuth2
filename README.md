# BlazorDiscordOAuth2
 Example implementation of OAuth2 for Discord using Blazor

## Setup
1. Edit `appsettings.json.template` to include your app id and secret found at [https://discordapp.com/developers/applications/](https://discordapp.com/developers/applications/) then rename the file to `appsettings.json`
2. (optional) Edit `launchsettings.json` and set `sslPort` to your desired port, this will be used in step 3
3. Go to your application at [https://discordapp.com/developers/applications/[APP_ID]/oauth](https://discordapp.com/developers/applications/) and add a redirect to `https://localhost:PORT/signin-discord`, replacing port with the one you chose in step 2 (or 44393 if you skipped step 2)
4. Add any necessary scopes in `startup.cs` NOTE: Currently email, identify and guilds are supported. Others may not work without editing `DiscordHandler.cs` and adding requesting/parsing data yourself.