# BlazorDiscordOAuth2
 Example implementation of OAuth2 for Discord using Blazor

## Setup
1. Edit `appsettings.json.template` to include your app id and secret found at [https://discordapp.com/developers/applications/](https://discordapp.com/developers/applications/) then rename the file to `appsettings.json`
2. (optional) Edit `launchsettings.json` and set `sslPort` to your desired port, this will be used in step 3
3. Go to your application at [https://discordapp.com/developers/applications/[APP_ID]/oauth](https://discordapp.com/developers/applications/) and add a redirect to `https://localhost:PORT/signin-discord`, replacing `PORT` with the one you chose in step 2 (or 44393 if you skipped step 2)
4. Add any necessary scopes in `startup.cs` NOTE: Currently email, identify and guilds are supported. Others may not work without editing `DiscordHandler.cs` and adding requesting/parsing data yourself.

## Authorizing users
- use AuthorizeView for content that can be seen but changes based on whether a user is authorized or not 
Example: `MainLayour.razor`
```
        <AuthorizeView>
            <Authorized>
                <a href="Account/Manage">Hello, @context.User.Identity.Name!</a>
                <a href="Account/LogOut">LogOut</a>
            </Authorized>
            <NotAuthorized>
                <a href="Account/Login">Log in</a>
            </NotAuthorized>
        </AuthorizeView>
```
- use `@attribute [Authorize]` as a page header to ensure a user is authorized before accessing the page. (demonstrated in `AccountManage.razor`)
NOTE:  `App.razor` has been configured via `AuthorizeRouteView` to automatically redirect a user to the discord auth page if they access an authorized page and have not authorized themselves