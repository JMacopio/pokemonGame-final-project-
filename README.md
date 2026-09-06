# Pokémon Game – Final Project

A Pokémon-inspired role-playing game built as the final project for an Object-Oriented Programming (OOP) subject. The game features a top-down overworld with player movement, wild Pokémon encounters, turn-based battles, an inventory system, and save/restore functionality.

## Features

- **Overworld Exploration** – Move the player character around a map with collision detection against walls.
- **Wild Pokémon Encounters** – Trigger battles when the player walks into designated wild Pokémon areas.
- **Turn-Based Battle System** – Engage in battles with attack, skill, and dodge mechanics.
- **Inventory System** – Use power-ups to increase damage, recover health, and equip items.
- **Save & Restore** – Save your game state and restore it if you are defeated in battle.
- **Audio** – Background music and battle sound effects for an immersive experience.

## Technologies Used

- **C#** – Core programming language
- **Windows Forms** – GUI framework
- **.NET Framework** – Application runtime
- **Windows Media Player** – Audio playback

## Project Structure

The project follows the **Model-View-Presenter (MVP)** architectural pattern:

```
pokemonGame/
├── Factory/          # Factory pattern for creating battle entities
│   ├── BattleForm.cs
│   └── SecondBattleForm.cs
├── Model/            # Data and game logic models
│   ├── PlayerMovement.cs
│   └── PlayerState.cs
├── Presenter/        # Business logic and state management
│   ├── BattlePresenter.cs
│   ├── InventoryPresenter.cs
│   ├── Movements.cs
│   └── SecondBattlePresenter.cs
├── Views/            # User interface forms
│   ├── LandingPage.cs
│   ├── Battle.cs
│   ├── Battle2.cs
│   ├── Inventory.cs
│   └── StartUp.cs
├── Resources/        # Images, audio, and other assets
├── Properties/       # Assembly and resource settings
├── Program.cs        # Application entry point
└── pokemonGame.csproj
```

### Key Classes

| Class | Description |
|-------|-------------|
| `PlayerMovement` | Handles player keyboard input, movement, and wall collision detection |
| `PlayerState` | Stores player health and position for save/restore functionality |
| `BattleForm` | Factory-created battle entity with attack and skill methods |
| `BattlePresenter` | Manages battle logic, turn order, and computer AI |
| `InventoryPresenter` | Handles power-up application, health recovery, and item equipping |

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/JMacopio/pokemonGame-final-project-.git
   ```
2. Open `pokemonGame.sln` in **Visual Studio**.
3. Build the solution (Ctrl+Shift+B).
4. Run the application (F5).

> **Note:** The audio files reference absolute paths (`C:\Users\User\source\repos\...`). You may need to update these paths in `LandingPage.cs` and `Battle.cs` if the audio does not play.

## Controls

| Key | Action |
|-----|--------|
| `W` / `↑` | Move up |
| `S` / `↓` | Move down |
| `A` / `←` | Move left |
| `D` / `→` | Move right |
| `Enter` | Interact / advance dialogue |

## Gameplay Overview

1. **Start Screen** – Launch the game from the startup form.
2. **Overworld** – Navigate the player character around the map. Walking into wild Pokémon or NPCs triggers events.
3. **Battles** – Turn-based combat where you and the opponent take turns attacking. Use skills for extra damage or try to catch the Pokémon when its health is low.
4. **Inventory** – Access items to boost damage, recover health, or equip special balls.
5. **Save System** – Save your progress during battle. If defeated, you can restore to your last saved state.

## Credits

- **Developer:** JMacopio
- **Purpose:** Final project for Object-Oriented Programming subject
- **Assets:** Pokémon-inspired sprites and audio used for educational purposes

---

*This project was created for educational purposes and is not affiliated with Nintendo or The Pokémon Company.*
