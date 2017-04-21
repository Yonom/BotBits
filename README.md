# BotBits  [![Version](https://img.shields.io/nuget/v/BotBits.svg?style=flat-square&label=version)](https://www.nuget.org/packages/BotBits/) [![Build Status](https://img.shields.io/travis/Yonom/BotBits.svg?style=flat-square)](https://travis-ci.org/Yonom/BotBits)  [![Issues](https://img.shields.io/github/issues/Yonom/BotBits.svg?style=flat-square)](https://github.com/Yonom/BotBits/issues)

Focus on your ideas, forget PlayerIOClient.

BotBits is the most popular bot library made specifically for Everybody Edits. Maintained by Yonom (Processor).

## Installation
Download from NuGet (https://www.nuget.org/packages/BotBits)

## Usage
Just create a new BotBitsClient instance, and you are good to go!
```csharp
BotBitsClient bot = new BotBitsClient();
```

## Connecting to EE
Using the Login class, you can login. Email, Guest, Facebook, Kongregate and Armorgames are supported login methods.
```csharp
Login.Of(bot)
    .WithEmail("email", "pass")
    .CreateJoinRoom("roomId");
```
Please note that BotBits automatically sends "init" and "init2" messages and waits for their responses to be received before CreateJoinRoom finishes running.

## Receiving Messages
You can load event listeners (which will be called automatically when a message is received) using the EventLoader class.
```csharp
EventLoader.Of(bot)
    .LoadStatic<Program>();

// Or for non-static handlers

EventLoader.Of(bot)
    .Load(this);
```

You can define an event listener in the following way:
```csharp
[EventListener]
static void On(JoinCompleteEvent e) 
{
    // Code to be executed when the bot joins the room
}
```
There are many other events in the `BotBits.Events` namespace: `InitEvent`, `JoinEvent`, `LeaveEvent`, `CoinEvent`, `ForegroundPlaceEvent`, `BackgroundPlaceEvent`, and so on...

## Interacting with the game
Lots of things your player can do are in the `Actions` class:
```csharp
Actions.Of(bot).GodMode(true);
Actions.Of(bot).Move(10 * 16, 10 * 16); // Move to 10x10
Actions.Of(bot).ChangeSmiley(Smiley.Sad);
```

You can chat and use chat commands with the `Chat` class:
```csharp
Chat.Of(bot).Say("Hi");
Chat.Of(bot).LoadLevel();
```

Room settings can be viewed or changed in the `Room` class:
```csharp
string roomOwner = Room.Of(bot).Owner;
Room.Of(bot).Save();
```

## Managing players
BotBits automatically maintains a list of active players in the room.

You can loop through this list and access the stored variables of players:
```csharp
[EventListener]
static void On(JoinCompleteEvent e) 
{
    foreach (Player p in Players.Of(bot)) 
    {
        Console.WriteLine(p.Username + " has smiley " + p.Smiley);
    }
}
```

You can also store your own variables:
```csharp
var player = Players.Of(bot).FromUsername("processor").FirstOrDefault();
if (player != null) 
{
    player.Set("IsBanned", true); // variables can have any type (int, bool, string, custom type, ...)
}
```
And retrieve them later:
```csharp
if (player.Get<bool>("IsBanned"))
{
    player.Kick("Sorry but you are too not allowed to play this level!");
}
```

## Working with blocks
First, let's take a look at the way BotBits handles block ids:

Every block is given a name in BotBits, so you don't have to remember confusing ids in your code.  
For example, to access the "air" block (ID: 0), you just have to type `Foreground.Empty`!  
To get a blue coin, you type `Foreground.Coin.Blue`.  
An invisible portal? `Foreground.Portal.Invisible`! 
 
The same applies to backgrounds: `Background.Empty`, `Background.Basic.Blue`, etc.  

---

Just like players, BotBits takes care of maintaining a live preview of the world.

Here's how you can get info about a block in a certain location:
```csharp
Foreground.Id id = Blocks.Of(bot).Foreground[0, 0].Block.Id;
Player placer = Blocks.Of(bot).Foreground[0, 0].Placer;
```

You can also loop through every block (although it is not recommended to do this very frequently!)
```csharp
foreach (var location in Blocks.Of(bot))
{
    if (location.Foreground.Block.Type == ForegroundType.Portal)
    {
        Console.WriteLine("Found portal with id: {0}, target: {1}",
            location.Foreground.Block.PortalId,
            location.Foreground.Block.PortalTarget);
    }
}
```

### Placing blocks
As you would expect, BotBits automatically slows down the sending speed of block packets so that they are not dropped by the server.  
EE servers only accept one message every ~10 milliseconds, and BotBits is able to send around 96 blocks per second without dropping any packets (on a very good connection).  
Blocks that get dropped are automatically resent, so you don't have to worry about that either!

Let's place a block:
```csharp
Blocks.Of(bot).Place(1, 1, Foreground.Basic.Gray);
```

Let's fill the whole world with that block:
```csharp
Blocks.Of(bot).Set(Foreground.Basic.Gray);
```

Or maybe just a section of it?
```csharp
Blocks.Of(bot).In(new Rectangle(10, 10, 10, 10)).Set(Foreground.Basic.Gray);
```

Checker the world!
```csharp
Blocks.Of(bot).Where((x, i) => i % 2 == 0).Set(Foreground.Basic.Gray);
```

Or only a part of it
```csharp
Blocks.Of(bot).In(10, 10, 10, 10).Where((x, i) => i % 2 == 0).Set(Foreground.Basic.Gray);
```

The possibilities are endless!

Oh and special blocks are supported too:
```csharp
Blocks.Of(bot).Place(x, y, Foregrounds.Portal.Normal, 0, 1, Morph.Portal.Left);
Blocks.Of(bot).Place(x, y, Foregrounds.Portal.World, "PW01");
Blocks.Of(bot).Place(x, y, Foregrounds.Coin.GoldDoor, 10);
Blocks.Of(bot).Place(x, y, Foregrounds.OneWay.Pink, Morph.OneWay.Down);
Blocks.Of(bot).Place(x, y, Foregrounds.SciFi.BlueSlope, Morph.SciFiSlope.InSouthEastPart);
```

## Examples
Take a look at this [custom ban list](http://botbits.yonom.org/examples/bans), [snake bot](http://botbits.yonom.org/examples/snakebot) or a [speed run bot](https://gist.github.com/Yonom/75e5c83937ea8a167d9d).

## Extensions
Anyone can code extensions to make BotBits more awesome!

Here are some existing extensions:

- [BotBits.Commands](https://github.com/Yonom/BotBits.Commands): Parses commands and lets you handle them similar to events.
- [BotBits.ChatExtras](https://github.com/Yonom/BotBits.ChatExtras): Add "\[Bot\]" or "\<Bot\>" prefix to every message!
- [BotBits.Permissions](https://github.com/Yonom/BotBits.Permissions): Give players permissions and restrict commands to certain permissions.
- [BotBits.DefaultCommands](https://github.com/Yonom/BotBits.DefaultCommands): A set of often needed commands (like !kick, !giveedit, ...)
- [BotCake](https://github.com/Yonom/BotCake): Removes the need of writing ".Of(bot)"! (Only supports console apps right now)
- [BotBits.Old](https://github.com/Yonom/BotBits.Old): Write bots for http://old.everybodyedits.com/!
- [BotBitsExt.Physics](https://github.com/Tunous/BotBitsExt.Physics): Physics simulation for bots.
- [BotBitsExt.Afk](https://github.com/Tunous/BotBitsExt.Afk): An afk extension for BotBits.
- [BotBitsExt.Rounds](https://github.com/Tunous/BotBitsExt.Rounds): A BotBits extension that allows you to integrate automatic rounds management with your bots.
