**Journal Entry 1**
My original idea for the two enhancements were:
1. Interacting with certain areas of the environment unlocks new/secret locations.
2. Collecting objects and dropping them in the pit affects the environment. Maybe there is some sort of implied creature down there (moaning/growling sounds) which can be quietened this way.

I implemented the core mechanics of these two ideas, and now the gameplay is much more exciting. Even if there is no real plot and this is still essentially just a walking simulator, the atmosphere feel more alive. Like this could truly be some other world where things happen and decisions matter instead of a lifeless environment.

What I'm trying to balance now is giving the player free range to explore while also subconsciously guiding them towards certain areas (like the arches and the tower, which the player must explore before interacting with the pit). The blue gems are there to alert the player to exactly that, acting as a sort of linear guide. The fact that the environment is so monochrome also works very well for this since it makes the blue stand out even more.

I now need to figure out *how* to better make the player understand the significance of the pit, and the orbs in accordance with the pit. I'll try to add text, maybe in the for of UI instructions or maybe something more plot/environment-related, that could lead the player to doing what the game expects of them. Do I add some sort of story elements? Mention the creature in the pit? Or allow the player to infer from the sound and level design? I also need the orb dropping mechanic to actually mean/do something.

**Journal Entry 2**
My last few commits have been primarily about sound design, especially to do with the pit. For now, I have multiple 'creature' sounds serving different purposes. One only plays when the orbs are dropped into the pit, one plays every 20 seconds and can be heard around the map, another is quieter and continuously plays from the pit. 

This serves its purpose in guiding and showing the player the significance of the pit, since all sounds originate or tie back to it (as another example, the orbs now omit the same shimmering-type sound as the pit which hopefully shows that there is a connection there). It also ties back to one of my main goals with this game, which was to keep the feel mysterious, eerie and alien. I think I've achieved this particularly by combining the alive/animal/monstrous sounds with the more beautiful glittering/shimmery sounds.

However, these aspects all still feel a bit disconnected to me, and I'd like the 'feeding' gameplay to have more significance on the sounds like it did in my original idea (keeping the creature quiet). I want the sounds from the pit to get increasingly loud and distracting until the player is forced to interact with it. Instead of having a lose condition if the player ignores the pit/orbs, I can more forcefully push them in the right direction with this. This could make the experience last a bit longer, maybe more interesting too, since the player is forced to go back again and again to do this one task. If I had more time with this project, this could be much more impactful to the gameplay after I added more areas to explore.
Still need to add UI instructions too!