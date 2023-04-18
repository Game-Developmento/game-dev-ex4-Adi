# Spaceship Shooter Game

## Overview

This is a simple spaceship shooter game built with Unity, where the player's objective is to shoot down enemy spaceships without colliding with them.

### New Features

1. A feature was added to keep the player and enemies from going out of bounds on the game screen.
2. A feature was added to regulate the number of enemies that can appear on the screen, gradually increasing their number as the player eliminates them and creating a greater challenge.

## Requirements

The game was built using Unity version `2021.3.18f1`.

## Rules & How to Play

1. [Visit the Spaceship Shooter game page in your web browser.](https://adiy55.itch.io/spaceship-shooter-game)
2. Use the **arrow keys** (left, right, up, and down) to move the player's spaceship.
3. Press the **spacebar** to shoot.
4. Shoot down the enemy spaceships to earn 2 points for each successful hit.
5. Avoid colliding with the enemy spaceships, as this will end the game.
6. Enjoy the game!

## Modified Contents and Folders

### Scenes

The game has two scenes located in the `Scenes/5-assignment` folder. These scenes are:

1. `a-level-1`: This scene contains the main gameplay.
2. `a-level-2`: This scene is displayed when the player passes through the arrow and wins.

### Scripts

The `Scripts/5-assignment` folder contains the following scripts:

* `BorderCollision2D`: This script is added to the `StarBackground` game object and detects when the player or an enemy has gone out of bounds. When this happens, the script changes the position of the object to the opposite side of the screen.

* `LimitedEnemySpawner`: The `LimitedEnemySpawner` script keeps count of the number of enemies on the screen and a limit. If the number of enemies is less than the limit, the script generates a new enemy. The script also contains a method that allows you to subtract an enemy, increasing the limit by 1. Every time the player eliminates an enemy, more enemies can spawn on the screen.
The `EnemySaucerWithLimitedSpawning` prefab uses the `LimitedEnemySpawner` script to control the spawning of enemies.

* `OnEnemyDestroyed`: This script is added to the `EnemySaucerWithLimitedSpawning` prefab and is triggered when an enemy is hit by the player's laser shot. The script calls the `SubtractEnemy()` method of the spawner to reduce the number of enemies on the screen. A reference to spawner is set when the enemy game object is instantiated.

* `Replay`: Resets the player's score and allows them to replay the game.

### Prefabs

* `EnemySaucerWithLimitedSpawning`: This prefab is used to spawn enemies in the game. It uses the `LimitedEnemySpawner` script to control the number of enemies on the screen.

## Credits

This game was built as part of a Unity programming course. The original game was modified with new scripts added to it.
