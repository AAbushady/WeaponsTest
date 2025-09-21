# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a Unity 6000.0.55f1 project named "WeaponsTest" that appears to be a game development project focused on weapons systems or combat mechanics. The project uses Unity's Universal Render Pipeline (URP) and includes the Input System for modern input handling.

## Key Dependencies & Packages

The project uses several Unity packages that define its capabilities:
- **Unity Input System (1.14.1)**: Modern input handling with pre-configured action maps for Player movement, looking, and attack actions
- **Universal Render Pipeline (17.0.4)**: Modern rendering pipeline for optimized graphics
- **AI Navigation (2.0.8)**: NavMesh and pathfinding systems
- **Timeline (1.8.7)**: Cinematic sequencing and animation
- **Test Framework (1.5.1)**: Unit testing capabilities
- **Visual Scripting (1.9.7)**: Node-based scripting system

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

- **Input System**: The project is configured with a comprehensive input action asset that defines player controls including movement (Vector2), look (Vector2), and attack (Button) actions
- **Empty Scripts Folder**: The main Scripts folder is currently empty, indicating this is either a new project or the scripts are organized differently
- **URP Configuration**: Uses Universal Render Pipeline which affects shader compatibility and rendering approaches
- **Modern Unity Patterns**: Built on Unity 6000.x with modern package management and systems

## Important Files

- `Assets/InputSystem_Actions.inputactions`: Contains all input bindings and action maps
- `Packages/manifest.json`: Defines package dependencies and versions
- `ProjectSettings/ProjectVersion.txt`: Unity version information
- `Assets/Scenes/SampleScene.unity`: Main development scene

## Development Considerations

- When adding scripts, place them in `Assets/Scripts/` following Unity naming conventions
- Use the existing Input System actions rather than legacy input methods
- Consider URP shader compatibility when working with materials
- The project includes AI Navigation, so navigation meshes can be used for AI movement
- Timeline system is available for cutscenes and complex animations

## Notes for Future Development

- Scripts folder is empty, suggesting this may be early in development
- Input actions are already configured for a player character with movement and combat
- Project is set up for modern Unity development with current packages and pipeline