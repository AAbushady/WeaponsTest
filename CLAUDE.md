# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Unity 6000.0.58f2 project developing a vehicle transformation and weapons system prototype. The project focuses on a car-to-robot transformation mechanic with an aiming system that enables different behaviors depending on the current vehicle form. This is intended as a modular component for integration into a larger game project.

## Key Packages

- **Unity Input System (1.14.2)**: Input management with configured action maps for Player and UI controls
- **Universal Render Pipeline (17.0.4)**: Modern rendering pipeline for visual effects
- **AI Navigation (2.0.9)**: Navigation mesh system (potential use for AI behaviors)
- **Timeline (1.8.9)**: Animation sequencing (potential use for transformation sequences)
- **Visual Scripting (1.9.7)**: Node-based scripting system

## Project Structure

```
Assets/
├── InputSystem_Actions.inputactions  # Configured with Move, Look, Attack, Interact, Jump, Transform actions
├── Scenes/
│   └── SampleScene.unity            # Main development scene
├── Scripts/
│   ├── TransformationController.cs  # Handles car ↔ robot transformation via prefab swapping
│   └── AimingController.cs          # Mouse-based aiming in robot mode
├── Prefabs/
│   ├── PlayerCar.prefab             # Car form prefab
│   ├── PlayerRobot.prefab           # Robot form prefab
│   ├── Wheel.prefab                 # Wheel component
│   └── NPC.prefab                   # NPC entity
├── Materials/                       # Material assets
└── Settings/                        # Project configuration
```

## Core Systems

### Transformation System (TransformationController.cs)
- **Pattern**: Prefab-swapping architecture - destroys current GameObject and instantiates the target form
- **Key Mechanism**: Preserves position between transformations; when transforming to car, aligns rotation with camera forward direction
- **State**: Uses `VehicleMode` enum (Car/Robot) to track current form
- **Trigger**: Press T key (configurable via `transformKey`)
- **Important**: Both prefabs must have TransformationController component attached with proper prefab references

### Aiming System (AimingController.cs)
- **Activation**: Only functional in Robot mode (mode-dependent behavior)
- **Mechanism**: Uses camera raycasting to determine aim direction, rotates entire robot GameObject to face mouse cursor
- **Raycast Logic**: Filters out self and child colliders, defaults to far point if no valid hit
- **Future Integration**: `GetAimDirection()` provides aim vector for weapon systems

## Development Notes

### Working with Transformation
- The transformation preserves world position but not velocity or other physics state
- Car transformation aligns with camera forward direction (flattened to horizontal plane)
- Both prefabs need TransformationController with `carPrefab` and `robotPrefab` assigned in Inspector

### Input System Configuration
- Action map: **Player** with actions for Move (WASD/arrows/gamepad), Look (mouse/right stick), Attack (LMB/button), Jump (Space/button), Interact (E/button hold), Transform (bound to T - see TransformationController)
- Supports multiple control schemes: Keyboard&Mouse, Gamepad, Touch, Joystick, XR

### Testing in Unity
1. Open project in Unity Editor (Unity 6000.0.58f2)
2. Open `Assets/Scenes/SampleScene.unity`
3. Press Play to test transformation and aiming systems
4. Use T to transform between car and robot modes
5. In robot mode, mouse movement controls aiming direction

### Common Tasks

**Run Tests**:
```bash
# Via Unity Test Runner in Editor, or command line:
"C:\Program Files\Unity\Hub\Editor\6000.0.58f2\Editor\Unity.exe" -runTests -batchmode -projectPath . -testResults TestResults.xml
```

**Build Project**:
```bash
# Build via Unity Editor (File > Build Settings) or command line:
"C:\Program Files\Unity\Hub\Editor\6000.0.58f2\Editor\Unity.exe" -quit -batchmode -projectPath . -buildTarget StandaloneWindows64 -buildPath ./Builds/
```

## Architecture Patterns

### Prefab Swapping Pattern
The transformation system uses prefab swapping rather than animation/timeline sequences. This allows completely different GameObject hierarchies for each form but requires careful state management when adding new systems.

**Implications for new features**:
- State that needs to persist across transformations must be stored externally or passed during SwapToPrefab
- Components that depend on specific GameObjects must handle prefab swapping gracefully
- Consider adding a state manager if more persistent data is needed

### Mode-Dependent Behaviors
The aiming system demonstrates the mode-dependent pattern where behaviors are enabled/disabled based on `VehicleMode`. Use this pattern for future weapon systems or movement controllers.

## Future Development Considerations

### Weapons Systems
- Use `AimingController.GetAimDirection()` to determine projectile direction
- Implement weapon components that check `TransformationController.currentMode` for mode-specific weapon availability
- Consider creating a weapon manager that handles transformation state changes

### State Persistence
- Current implementation doesn't preserve velocity, rotation speed, or other physics state across transformations
- If more complex state is needed, implement a state manager component that survives transformations

### Camera System
- Both systems reference `Camera.main` - consider creating a dedicated camera controller for more complex camera behaviors
- Camera direction influences car transformation alignment (see TransformationController.cs:78-90)
