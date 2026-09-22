# Super Mario Suika 🍄

**Author:** Mario Deusto Ríos

## 📖 About the Project
A 2D arcade game developed natively in C# with **Windows Forms**. It is inspired by the mechanics of the popular *Suika Game*, but adapted with aesthetics and elements from the Super Mario universe.

The player's goal is to drop mushrooms into a pipe, merging those of the same size and level to create larger mushrooms and score points. The player must use strategy and physics to their advantage, preventing the mushrooms from stacking up and crossing the top boundary line at all times.

## 🏗️ Software Architecture
Engineered with a strict Separation of Concerns (SoC) pattern, effectively isolating the physics engine (`GameService.cs`), state management (`GameData.cs`), and GDI+ rendering (`GameWindow.cs`) to ensure scalable and maintainable code.

## ✨ Main Features
* 🧲 **Custom Physics Engine:** Gravity, friction, exact circular collision calculation, and bounces programmed from scratch using pure mathematics (Pythagorean theorem and vector algebra) for precise overlap resolution, without relying on external engines like Box2D.
* 💾 **Data Persistence:** Automatic saving and loading system for the "Top 5 Records" through reading and writing local files (`System.IO`).
* 🎵 **Audio Management:** Implementation of ambient background music and reactive sound effects (when merging objects or losing the game) using `SoundPlayer`.
* 🖥️ **UI and Game States:** Interactive welcome menu, real-time score updates (running at 60 FPS thanks to *DoubleBuffered* rendering), and dynamic Game Over messages.
* 🛠️ **Testing Tools:** Integrated developer shortcuts to quickly force game states during development (e.g., `Ctrl + G` to force a game over).

## ⚙️ Installation & Usage

### Prerequisites
- Visual Studio 2022 (or newer).
- .NET Framework [versión que hayas usado, ej. 4.7.2].

### Running the Game
1. Clone the repository:
   `git clone https://github.com/tu-usuario/tu-repo-csharp.git`
2. Open the `SuperMarioSuika.sln` solution file in Visual Studio.
3. Press `F5` or click "Start" to compile and play the game.
