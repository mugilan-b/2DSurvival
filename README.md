We use Unity v2020.3.24f1
GitHub link: https://github.com/DareDevil-GGWP/2DSurvival
Trello link: https://trello.com/b/ThElTOmG/2dsurvival


Changelog:

v0.0.3:

Main Menu.

********

v0.0.2:

Playerlook script:
- Gets mouse input, processes it 
- Rotates an object (and all its children. Here the object attached should be the player's weapon) wherever the mouse is pointing to. ONLY WORKS PROPERLY WHEN BUILT AND RUN, doesn't work in unity editor.
- Deadzone value of 100. If cursor is <100 pix away from center, it doesn't rotate. ~100 seems fine for a 1080p screen

Tweaks in CamController script:
- Added a control "X"
- When cam movement is disabled (Toggle with E), press X to recenter it.

WeaponChoose script:
- Takes inputs 0-9
- If same number is pressed twice, it sets to 0. For ex, you press 0, it stays 0, you press 1, it stays 1, if you press 1 again it goes to 0. 
- Made it like this so 0 can be the equivalent of UNEQUIPPED, 1-9 are the items that are available in hotbar.
- The hotbar is an array(ordered) containing IDs of objects that are equipped. 

Removed data in Fire.cs and WeapHandler.cs

********