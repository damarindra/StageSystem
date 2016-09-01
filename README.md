# StageSystem

StageSystem is simple unlock / lock stage in Unity.

## How To Use

1. Create / open your stage selection scene.
2. Add / Create a new gameobject with StageButtons Component (not StageButton, but StageButtons)
3. Configure Buttons value at the inspector

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

1. Buttons : button function to change to the stage scene
2. Id (right after button) : your target scene, act as load scene.
3. Set to unlock : Set this stage / button to unlock
4. Next Level ID : your next level, act to unlock next level
5. Apply : click if done

### StageButtonImplementation

**Variables**

1. id = target level id
2. nextLevelId = target Next Level Id

