# CanetisRadar2

This is a second attempt of solving my problem, you can see my first attempt from a modified fork
[Alaanor/CanetisRadar](https://github.com/Alaanor/CanetisRadar).

## The problem

As a 100% deaf from birth person, I can now hear artificially from one ear thanks to the technology. And as gamer, I
can **hear** a sound, I can **recognize** it but I **cannot locate** it.

At first as a causal gamer I was not really bothered by this fact, but over time I realized while watching some strong
apex player on youtube that they could notice enemies way before I even could. The difference is that they have the
audio cue while I'm only relying on the visual one.

Hence I wish to find a way to **quickly** notice from what direction the sound is.

## How to use it

It has not been intended to be used by someone else as the requirement were pretty specifics. However, I do wish to make
the repo public to show my attempt and provide the source code.

## Screenshot

<a href="https://cdn.discordapp.com/attachments/733779754121166978/822505618149605477/unknown.png">
 <img src="https://cdn.discordapp.com/attachments/733779754121166978/822505788626173952/unknown.png" alt="screenshot 1"/>
</a>

<br>

<a href="https://cdn.discordapp.com/attachments/733779754121166978/822505597663707168/unknown.png">
  <img src="https://cdn.discordapp.com/attachments/733779754121166978/822505734880100412/unknown.png" alt="">
</a>

What you see there is a 3 screen setup, the bar are on the 2 other screen while the game in on the middle.
This so I can keep fullscreen and my 165hz for apex.

## Features

- 2 white bar (Left/Right) composed of 3 section each (Front/Side/Behind)
- A section become:
    - White if no sound
    - Yellow if a small sound is there
    - Red if a loud sound is there
- Retention of the highest level met for a delay (See Audio/Speaker.cs)

## Conclusion

There were some progress compared the first version, however, I now notice that the use of the **volume metric**
is **not a good solution**. I was able to find the direction of a far fight in apex after a solid 3-4 seconds.
This is a first step and I'm happy with this one. But this require to first notice the cue, stop my character
(so it doesn't make any noise anymore) and clearly see on the bar where the direction is.

In close range it is very hard/almost impossible to notice where the shoot is from and not in a fast manner.

## Licence

License under MIT
