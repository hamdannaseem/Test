# Test - Minimalist Endless Runner Game

## Overview

Test is a simple, minimalist endless runner game developed in Unity. The player controls a capsule-shaped character that runs across a flat plane, collecting cylindrical coins while avoiding obstacles. The game emphasizes endless progression, featuring core mechanics like dodging, scoring, and survival. It includes advanced integrations such as a leaderboard system for tracking high scores, ads for monetization, analytics for player behavior tracking, and achievements to reward milestones.

The game is built as a test project, showcasing basic Unity features with extensions for leaderboards and monetization. The repository contains the full Unity project structure, including assets, scripts, and settings files.

## Features

- **Core Gameplay**: Endless running on a simple plane with procedural or infinite generation. The player character is a capsule that can move and collect coins (modeled as short cylinders).
- **Scoring System**: Real-time score accumulation based on coins collected. Includes high score tracking.
- **Leaderboard**: Integrated system for storing and displaying top scores, supporting player names and rankings.
- **Ads Integration**: Monetization via Unity Ads, Implemented as banners in menus.
- **Analytics**: Tracks player metrics like session length, coins collected, and engagement using Unity Analytics.
- **Achievements**: Unlockable achievements for milestones such as reaching specific scores, collecting a number of coins.
- **Visuals and Assets**: Minimalist design with basic shapes (capsule player, cylinder coins, plane ground).

To run or build the game:

1. **Prerequisites**:
   - Unity Editor (version 2022 recommended)
   - Git for cloning the repository.

2. **Clone the Repository**:
   ```
   git clone https://github.com/hamdannaseem/Test.git
   ```

3. **Open in Unity**:
   - Launch Unity Hub.
   - Add the cloned project folder.
   - Open the project. Unity will handle importing packages and assets.

4. **Build and Run**:
   - In Unity Editor, go to File > Build Settings.
   - Select your target platform (e.g., Windows, WebGL).
   - Build and run.

## How to Play

- **Controls**:
  - Use WASD Controls.
  - Collect coins to increase score.
  - Avoid hitting obstacles.

- **Objective**:
  - Run as far as possible to achieve high scores.
  - Unlock achievements by completing challenges.
  - Check the leaderboard to compare with other players.

- **Game Over**: Occurs when the player collides.
## Technologies Used

- **Unity Engine**: Core framework for game development, including physics, UI, and scripting.
- **C# Scripts**: Handles player control, scoring, leaderboard updates, and ad callbacks.
- **Unity Services**:
  - Leaderboards for score ranking.
  - Ads for monetization.
  - Analytics for metrics reporting.
  - Achievements for player progression.
- **Shaders**: Custom ShaderLab and HLSL for visual effects on minimalist assets.

## License

This project is unlicensed (default GitHub terms apply).
