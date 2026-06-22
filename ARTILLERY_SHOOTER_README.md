# 🚀 Artillery Shooter — Aeroplane Game

> A fast-paced 2D space shooter built with **C# Windows Forms (.NET Framework 4.7.2)**. Pilot your fighter jet through waves of enemies, dodge their fire, and battle your way to Level 10!

---

## 🎮 Gameplay Preview

![Artillery Shooter Gameplay](artillery_preview.png)

---

## ✨ Features

- **10 Progressive Levels** — difficulty scales with every 30 kills: enemies speed up, fire faster
- **10 Unique Enemy Types** — 3 standard fighters + 2 Boss variants per wave
- **Dual Munition Systems** — player fires upward; enemies shoot back with yellow laser rounds
- **Parallax Star Field** — two-layer scrolling background for a deep-space feel
- **Full Audio** — looping background music, shooting SFX, and explosion sounds via Windows Media Player COM interop
- **Pause / Resume** — press `Space` to pause and unpause mid-game
- **Win & Game Over States** — reach Level 10 to win; collision with enemy or enemy bullet ends the game
- **Restart without relaunch** — full game reset from the in-game menu

---

## 🕹️ Controls

| Key | Action |
|-----|--------|
| `←` | Move Left |
| `→` | Move Right |
| `↑` | Move Up |
| `↓` | Move Down |
| `Space` | Pause / Unpause |

> Munitions fire **automatically** — focus on dodging!

---

## 🏗️ Tech Stack

| Layer | Detail |
|-------|--------|
| Language | C# |
| Framework | .NET Framework 4.7.2 |
| UI | Windows Forms (WinForms) |
| Audio | WMPLib (Windows Media Player COM Interop) |
| IDE | Visual Studio 2022 |

---

## 📁 Project Structure

```
AEROPLANE GAME/
├── AEROPLANE GAME.slnx          # Solution file
└── AEROPLANE GAME/
    ├── Form1.cs                 # Core game logic
    ├── Form1.Designer.cs        # UI layout
    ├── WindowsMediaPlayer.cs    # Audio wrapper
    ├── Program.cs               # Entry point
    ├── bin/Debug/
    │   ├── characters/          # Sprites (player, enemies, bosses, bullets)
    │   └── sound/               # Audio files (GameSong, shoot, boom)
    └── Properties/
```

---

## ⚙️ Getting Started

### Prerequisites
- Windows OS
- Visual Studio 2022 (or later)
- .NET Framework 4.7.2
- Windows Media Player installed (for audio)

### Run the Game
1. Clone or download the repository
2. Open `AEROPLANE GAME.slnx` in Visual Studio
3. Update the hardcoded asset paths in `Form1.cs` to match your local directory:
   ```csharp
   gameMedia.URL = @"YOUR_PATH\sound\GameSong.mp3";
   Image player = Image.FromFile(@"YOUR_PATH\characters\player.png");
   ```
4. Build and run (`F5`)

> **Note:** Asset paths are currently hardcoded to `D:\C#\AEROPLANE GAME\...`. Relative path support is planned for a future update.

---

## 🎯 Game Logic Highlights

- **Collision Detection** — `Bounds.IntersectsWith()` checks between player bullets ↔ enemies, and enemy bullets ↔ player
- **Dynamic Difficulty** — `enemiespeed`, `enemiesMunitionspeed`, and `difficulty` variables update each level-up
- **Enemy Respawn** — enemies loop back to the top after passing the bottom edge, maintaining continuous pressure
- **Double-Buffered Rendering** — `this.DoubleBuffered = true` prevents screen flicker

---

## 🔮 Planned Improvements

- [ ] Relative asset paths (remove hardcoded `D:\` references)
- [ ] Lives / health system
- [ ] High score persistence
- [ ] Multiple weapon types
- [ ] Animated sprite sheets

---

## 👨‍💻 Author

Built as a C# Windows Forms learning project — practicing game loops, collision detection, timer-driven animation, and COM audio interop.

---

## 📜 License

This project is open source and available under the [MIT License](LICENSE).
