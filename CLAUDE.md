# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a Unity 6000.0.55f1 project named "WeaponsTest" that serves as a dedicated development environment for creating vehicle weapons and transformation systems. This project is intended to be a modular component that will be integrated into a larger main game project. The focus is specifically on developing and testing vehicle-based weaponry and transformation mechanics, not player character systems.

## Key Dependencies & Packages

The project uses several Unity packages relevant to vehicle weapons and transformation systems:
- **Unity Input System (1.14.1)**: Modern input handling (likely default Unity template, may need reconfiguration for vehicle controls)
- **Universal Render Pipeline (17.0.4)**: Modern rendering pipeline for optimized graphics and visual effects
- **AI Navigation (2.0.8)**: Potential use for autonomous weapon targeting or vehicle AI behaviors
- **Timeline (1.8.7)**: Useful for complex transformation sequences and weapon deployment animations
- **Test Framework (1.5.1)**: Unit testing capabilities for weapons systems
- **Visual Scripting (1.9.7)**: Node-based scripting for rapid prototyping of weapon behaviors

## Project Structure

```
Assets/
├── InputSystem_Actions.inputactions  # Input action definitions for player controls
├── Materials/                        # Material assets
├── Prefabs/                         # Reusable game objects
├── Scenes/
│   └── SampleScene.unity            # Main scene
├── Scripts/                         # C# scripts (currently empty)
├── Settings/                        # Project-specific settings
└── TutorialInfo/                    # Tutorial/readme components
```

## Development Commands

### Building the Project
```bash
# Open Unity Hub and build through the editor, or use Unity command line:
Unity -batchmode -quit -projectPath . -buildTarget StandaloneWindows64 -buildPath ./Builds/
```

### Testing
```bash
# Run tests through Unity Test Runner in the editor, or via command line:
Unity -batchmode -runTests -projectPath . -testResults ./TestResults.xml
```

### Opening the Project
```bash
# Open in Unity Editor
Unity -projectPath .
```

## Architecture Notes

- **Input System**: Contains default input actions that will likely need reconfiguration for vehicle weapon controls and transformation triggers
- **Empty Scripts Folder**: Ready for development of weapon systems, transformation mechanics, and vehicle component scripts
- **URP Configuration**: Uses Universal Render Pipeline which is ideal for weapon visual effects, muzzle flashes, and transformation particle systems
- **Modular Design**: Project structure supports development of reusable weapon and transformation components for integration into the main game
- **Modern Unity Patterns**: Built on Unity 6000.x with modern package management, suitable for complex mechanical systems

## Important Files

- `Assets/InputSystem_Actions.inputactions`: Default input actions (will need customization for vehicle weapon controls)
- `Packages/manifest.json`: Defines package dependencies and versions
- `ProjectSettings/ProjectVersion.txt`: Unity version information
- `Assets/Scenes/SampleScene.unity`: Main development and testing scene for weapons systems

## Development Considerations

- **Weapons Systems**: Place weapon scripts in `Assets/Scripts/Weapons/` with clear naming conventions (e.g., `LaserCannon.cs`, `MissileSystem.cs`)
- **Transformation Systems**: Create transformation scripts in `Assets/Scripts/Transformations/` for vehicle morphing mechanics
- **Modular Architecture**: Design components for easy integration into the main game project
- **URP Visual Effects**: Leverage URP for weapon particle effects, energy beams, and transformation animations
- **Timeline Integration**: Use Timeline for complex transformation sequences and synchronized weapon deployments
- **Testing Framework**: Implement unit tests for weapon damage calculations, transformation states, and system interactions

## Weapon System Development Focus Areas

- **Projectile Systems**: Bullets, missiles, energy weapons with ballistics and targeting
- **Transformation Mechanics**: Vehicle shape-changing, weapon deployment/retraction systems
- **Targeting Systems**: Auto-aim, manual targeting, trajectory calculation
- **Damage Systems**: Modular damage calculation and effect application
- **Visual Effects**: Muzzle flashes, impact effects, transformation particle systems
- **Audio Integration**: Weapon firing sounds, transformation mechanical sounds

## Notes for Future Development

- Empty Scripts folder ready for weapons and transformation system development
- Default input actions will need reconfiguration for vehicle-specific controls
- Project structure supports modular component development for main game integration
- Timeline system ready for complex mechanical transformation sequences