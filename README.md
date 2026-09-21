# Super Mario Suika 🍄

**Author:** Mario Deusto Ríos

**Course:** 1 DAM A - Programming

## 📖 About the Project

A 2D arcade game developed natively in C# with **Windows Forms**. It is inspired by the mechanics of the popular *Suika Game*, but adapted with aesthetics and elements from the Super Mario universe.

The player's goal is to drop mushrooms into a pipe, merging those of the same size and level to create larger mushrooms and score points. The player must use strategy and physics to their advantage, preventing the mushrooms from stacking up and crossing the top boundary line at all times.

## ✨ Main Features

* 🧲 **Custom Physics Engine:** Gravity, friction, exact circular collision calculation, and bounces programmed from scratch using pure mathematics, without relying on external engines.

* 💾 **Data Persistence:** Automatic saving and loading system for the "Top 5 Records" through reading and writing local files (`System.IO`).

* 🎵 **Audio Management:** Implementation of ambient background music and reactive sound effects (when merging objects or losing the game) using `SoundPlayer`.

* 🖥️ **UI and Game States:** Interactive welcome menu, real-time score updates (running at 60 FPS thanks to *DoubleBuffered* rendering), and dynamic Game Over messages.

* 🛠️ **Testing Tools:** Integrated developer shortcuts to quickly force game states during development (e.g., `Ctrl + G` to force a game over).

## ⚙️ Development Methodology

An **iterative and incremental** development methodology was adopted for this project. Being an individual project, this approach allowed dividing the technical complexity of the video game into short, manageable work cycles:

1. **Analysis and Visual Prototyping:** Initial setup, canvas definition, and asset loading.

2. **Basic Physics Engine:** Game Loop implementation using `Timer` and fundamental physics (vectors and bounces).

3. **Logic and Collisions:** Mathematical algorithm for circular collisions and merge resolution.

4. **Rule Integration (Gameplay):** Player controls, score accumulation, and defeat condition.

5. **Persistence and Audiovisual Polish:** Save files, audio feedback, and object-oriented refactoring.
