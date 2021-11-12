# DotTwitchLib
 A C# Twitch library that is lightweight and powerful.

![alt text](https://i.postimg.cc/Vvm0WJPt/Dot-Twitch-Lib.png)
 
 ## Download Latest Version

Code located in the `master` branch is under development (for now).

- [Download [zip]](https://github.com/RickyDivjakovski/DotTwitchLib/archive/main.zip)
- [Download [dll]](https://github.com/RickyDivjakovski/DotTwitchLib/blob/main/DotTwitchLib/bin/Debug/DotTwitchLib.dll?raw=true)

 ## Implementation

Add a reference to the library in your project:

    using DotTwitchLib;

Add the TwitchClient through the IDE or programatically:

    TwitchClient twitchClient1 = new TwitchClient();

Set the Credentials or OAuthToken, Username(bot channel name) and Channel(To monitor) in the propertiess secion or programatically:

    twicthClient1.OAuthToken = "oauth:w1mtu6ein3rryr2dk34ie66oigvwkz";
    twicthClient1.TwitchChannel = "ttvbottestaccount";
    twicthClient1.OAuthToken = "TTVBotTestAccount";
	
Additional properties are able to be set such as UseSSL, DebugMode and ReferenceColors.
Usage of the client is simple.

 ## Sending messages

Sending a message to the twitch chat with the client.

    twitchClient1.SendChatMessage("This is a message from the bot.");

Sending a message to the IRC chat with the client.

    twitchClient1.SendIRCMessage("This is a message to the IRC from the bot.");

 ## Receiving data

The client is efficient at returning data so operations are all through events.

    private void twitchClient1_OnChannelMessage(object sender, DotTwitchLib.ChannelMessageEventArgs e)
        {
            ChatBox.AppendText(e.Time, e.From, e.Message, Color.Gray, e.ReferenceColor, Color.White);
        }

 ## Events

There are multiple events fired during receiving/filtering data such as:

- OnChannelMessage
- OnIRCMessage
- OnBotCommandExecuted
- OnTwitchCommandExecuted
- OnConnect
- OnPing
- OnReturnDebugData
- OnSentMessage
- OnSentIRCMessage
- OnViewersUpdate(Experimental and only returns logged in viewers)
- OnViewerJoin(Experimental and only returns logged in viewers)
- OnViewerLeave(Experimental and only returns logged in viewers)

 ## Disposal
 
    twitchClient1.Dispose();

 ## License

License under the [MIT License](https://github.com/RickyDivjakovski/DotTwitchLib/blob/master/LICENSE). 

More information about the MIT license can be found [here](https://opensource.org/licenses/MIT).