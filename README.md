# StageSystem

StageSystem is simple unlock / lock stage in Unity.

## How To Use

1. Create / open your stage selection scene.
2. Add / Create a new gameobject with StageButtons Component (not StageButton, but StageButtons)
3. Configure Buttons value at the inspector
	a. Buttons : button function to change to the stage scene
    b. Id (right after button) : your target scene, act as load scene.
    c. Set to unlock : Set this stage / button to unlock
    d. Next Level ID : your next level, act to unlock next level
    e. Apply : click if done

## Code Guide

### StageManager

; tldr ;
If you want to Unlock next level just call StageManager.UnlockNextLevel();
