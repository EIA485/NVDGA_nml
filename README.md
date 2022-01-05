# NVDGA
Neos VR Dynamic Graphics Adjuster.

----------------------------------------------------------------------------------------------------------------

What does it do? Literally just adjusts your Graphics settings in NEOS VR dynamically based on your framerate.
It takes a couple of samples of your framerate every few seconds and adjusts automatically based on that.

Everything is clientside. Nothing is sent to server.

----------------------------------------------------------------------------------------------------------------

Building on your own: 
If you want to make any changes to plugin, please follow the default configuration settings on: https://melonwiki.xyz/

Do that, dump the script into your project folder, and you'll be good to go.

----------------------------------------------------------------------------------------------------------------

DLLs are not provided. Find them on your own.

----------------------------------------------------------------------------------------------------------------

By using this plugin, you realize that your warranty is now null and void, and i will point and lau... wait a minute, wrong website. That is not a phone.

Basically. You accept the fact that everything that's gonna happen to your computer is your own fault, and is no fault of mine.

----------------------------------------------------------------------------------------------------------------

Commonly asked questions:

----------------------------------------------------------------------------------------------------------------

Q: Why MelonLoader?

A: It just works. That, and official plugin system restricts you to playing with people who use the same plugins. Since this is fully clientside and only changes visuals, it shouldn't be a problem.

----------------------------------------------------------------------------------------------------------------

Q: How do I know it works?

A: Probably noticing visual changes whenever your framerate goes down the poopoo.

----------------------------------------------------------------------------------------------------------------

Q: Does it work on desktop mode?

A: Yes. Though you are less prone to motion sickness outside of VR, you can still use it.

----------------------------------------------------------------------------------------------------------------

Q: Can't the developers just do it themselves?

A: Yes they can. But they haven't. Probably because they plan to dump Unity rendering eventually and move to their custom engine or whatever.

----------------------------------------------------------------------------------------------------------------

Q: Can't the world creators just optimize their worlds better?

A: Probably can. Who knows.

----------------------------------------------------------------------------------------------------------------

Q: Can it change texture res too tho?

A: No. This is literally only affecting: 

1) Shadows. 
2) Cubemaps. 
3) LOD Bias. 
4) Possibly reflections/refractions and other effects in some of the shaders. 
5) Max amount of possible point lights. 

Why not textures? Neos loads them differently. I've tried to get all of the materials using the classy GetTypeOf, but unfortunately this didn't work. Or well. It did. But only for some of the UI elements, and that's unfortunately not gonna optimize anything.

----------------------------------------------------------------------------------------------------------------

Q: Will this get me banned?

A: Likely not. No malicious code. But you will be likely breaking TOS, which may be punishable. Still, because they approved a third party solution for SSAO disabler, I've decided to make this plugin also.

----------------------------------------------------------------------------------------------------------------

Q: wtf i no like this how can i return back to origano?

A: Just delete the plugin. Neos resets its visual/graphics settings on start.

----------------------------------------------------------------------------------------------------------------

Q: Is your computer a potato? Why did you write this plugin?

A: No. But my GPU is garbage and can't run the game well. Also, reprojection stability can be wacky at times.

----------------------------------------------------------------------------------------------------------------

kthxbye

