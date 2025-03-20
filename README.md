# Seed Room
__Seed Room__ is a prototype of procedural room generation made in Godot 4. Written in C#.

Although this is the full version, this prototype is __defective__, as it has _issues/problems_ that hinders the good functioning of the program.

In newer prototypes, these issues may get solved, and the generation system improved, along as with graphics/sprites, scripts, etc.

## Issues/Problems of this Prototype

### Detected issues

* The rooms are too complex, large, and there are a lot of curves. As a result, one room can be wrongly placed right above another, glitching the collisions, and room limits.
    * Hence, I deactivated the collision systems. Simpler, smaller and curve restricted room may be the key to solve this problem in the future.
* Glitched seeds. Seeds like `702` and `197821706` are glitched for some reason and makes the game stuck in the loading screen.
    * The generation system is probably the cause of this error. More researching and improving the generation system may be the key to solving this.
* The game resolution emulates 1280×720, however its real resolution is 320×180. That's very small for a game. As a result, it glitches fonts and text sizes.
    * A simple camera zoom may be able to solve this in some cases.

## Requirements
I highly think this can run in almost anywhere. However, I would say the minimum requirements are:
```
An Intel Core 3rd Generation Processor.
512 MB RAM.
```

## How to build
Below are the steps for building the prototype:
1. Go to [Godot Archive Page](https://godotengine.org/download/archive/) and download the `Godot-4.3-stable`(from August 15, 2024) .NET C# version and its dependencies. Note: Newer versions were not tested and can present instability. It's highly recommended to download the aforementioned version.
2. Open the project on Godot on Compatibility Mode and export the project normally just like any other Godot project.
3. (Optional) [Visual Studio Code](https://code.visualstudio.com/) or [VSCodium](https://vscodium.com/) are recommended IDEs to use with Godot C#.


## Copyright
Please don't repost or sell it. This is not a game, it's just a prototype of a system that may be used by me on my new projects/games.

Lite1427 © 2025. All rights reserved.