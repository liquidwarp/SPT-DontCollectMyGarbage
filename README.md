⚠️ **Don't use this if you do not have _ample_ memory headroom and/or are comfortable risking crashes for slightly less stutters in raid** ⚠️

Please read the rest of the description before installing.

## What

Client mod that disables garbage collection happening every time you open the inventory screen in raid.

## Why

While EFT does not garbage collect in raid, likely to reduce stutters, SPT has a patch to enable and perform a short GC every time you open your inventory screen.

**It's a good thing. You _most likely_ want that to happen.**

_But_, if you have sufficient RAM headroom, you may be able to run your whole raid without this additional garbage collection, and enjoy a few less stutters.

**This is working well on my setup, which is FIKA headless + graphical client on the same host with 64GB RAM; this mod on the graphical client (only, it's useless on the headless).**

## Why NOT

Guess what happens if you run out of memory and the game can't GC? Yeah, bye raid.
It's not a good trade-off for a few less 50ms frames.

Risks may depend on what client mods you have installed and how much sustained allocation they perform.

## Installation

You probably shouldn't be using this if you don't know how to install it.

FIKA: only install on graphical clients, it is useless on the headless, where I'm sure FIKA has its own GC shenanigans, in addition to its automatic restart after every raid.