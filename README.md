# audiodesignfinal

Game Title:
Echoes of the Deep

Game Theme & Concept:

The game is a 2D top-down action-mining game set in an underground cave environment.
The player explores a dark dungeon like cave, defeats hostile ghosts using a sword, collects coins to upgrade their equipment by obtaining a hammer, and mines rocks to progress to the next level.


Core Gameplay Mechanics

Movement:
The player moves freely in four directions using keyboard input.

Combat:
The player attacks enemies (ghosts) using a sword.

Resource Collection:
Coins are collected by colliding with them. Coins are used to unlock a hammer upgrade.

Mining Mechanic:
Once the hammer is obtained, the player can mine rocks. Rocks require multiple hits and use sound to communicate material weight and impact.

Progression:
After completing objectives, the player moves through doors to the next scene.

Failure State:
When the player’s health reaches zero, a Game Over screen is displayed.

Audio Design Goals:

The primary goal of the project is to create an immersive and readable audio experience that supports gameplay feedback and environmental storytelling.

Audio is organized using Unity’s Audio Mixer, separating sounds into:

Music

SFX

Ambience

UI


Game Feel & Juiciness

Game feel was enhanced using exaggerated and layered audio feedback:

Sword attacks use sharp, short swish sounds which was a recording of my lightsaber.

Mining sounds are heavier, lower-frequency to emphasize material weight which i created by shoveling my cat's litterbox.

Coin pickup sounds are bright and rewarding to reinforce positive feedback which are the only assets i used.

Footstep audio increases immersion and spatial awareness while maintaining clarity during combat and exploration.

Ambience sounds were designed to give the player a sense of damp dark cave that matches the dungeon aesthetic which i created by recording waterdrops in a bathtub and adding echo to them.

Pitch randomization is applied to repetitive sounds (such as mining and footsteps) to prevent robotic repetition.

PlayOneShot() is used for most SFX to avoid audio clipping and preserve sound quality.

These choices increase responsiveness, clarity, and player satisfaction.

Audio Implementation Details
Audio System Setup

All sounds are routed through a Unity Audio Mixer.

Mixer Groups:

Music

SFX

Ambience

UI

Volume balancing is handled in the Mixer, not per-clip.



Ambience (Environment)
Cave Ambience

Continuous looping cave atmosphere

Non-reactive to player input

Technical Details

2D sound (Spatial Blend = 0)

Seamlessly looped

Routed through Ambience Mixer Group

Low volume to avoid masking SFX

Purpose

Defines the underground space, reinforces isolation, and provides environmental context without distracting from gameplay.

SFX & Foley (Reactive Sounds)
Player Actions

Sword attack

Hammer mining

Footsteps 

Coin pickup

Rock destruction

Technical Details

Played using AudioSource.PlayOneShot()

Routed through SFX Mixer Group

Slight pitch randomization applied to repetitive sounds

Volume balanced to prioritize clarity

Physics Communication

Sword sounds emphasize speed and precision

Mining sounds emphasize weight and resistance

Rock destruction confirms successful interaction

Technical Details

2D sound

Loop enabled

Routed through Music Mixer Group

Lower volume than SFX to preserve gameplay clarity

Ambience

Source: Custom edited cave ambience

Processing: Loop editing, reverb, EQ for low-frequency emphasis

SFX
Sword Attack

Source: Foley / edited sound

Processing: Trim, EQ, pitch variation

Mining / Rock Hit

Source: Foley / edited impact sound

Processing: Layered impacts, pitch variation, EQ

Coin Pickup

Source: Edited sound effect

Processing: High-frequency emphasis for reward feedback

All clips sounds were edited using Audacity and DaVinci Resolve
