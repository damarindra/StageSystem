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

; tldr version;

If you want to Unlock next level just call StageManager.UnlockNextLevel();

**Methods**

1. void UnlockLevel(StageButton sButton)
2. void UnlockLevel(string id)
3. void LockLevel(StageButton sButton)
4. void LockLevel(string id)
5. bool isLevelUnlocked(StageButton sButton)
6. bool isLevelUnlocked(string id)
7. void UnlockNextLevel()

### StageButtons

**Variable**

Buttons : a list of StageButton

### StageButton

**Variables**

a. Buttons : button function to change to the stage scene
b. Id (right after button) : your target scene, act as load scene.
c. Set to unlock : Set this stage / button to unlock
d. Next Level ID : your next level, act to unlock next level
e. Apply : click if done

### StageButtonImplementation

**Variables**

a. id = target level id
b. nextLevelId = target Next Level Id

