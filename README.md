# Dominion Protocol

**Dominion Protocol** is a strategic, modular card-based war game built in [Godot Engine](https://godotengine.org/) using C#.  
It blends classic territorial conquest gameplay with deep customization and community-driven expansion.

> The world is unstable. Treaties have failed. New threats emerge.  
> The protocol has been activated.

---

## 🕹 Game Concept

- Turn-based warfare inspired by *Risk/WAR*
- Each player controls a nation and seeks to dominate neighbors
- Game actions are driven by a deck of strategic cards
- Players will eventually be able to create their own cards, rules, and visual styles
- Fully moddable game engine prepared for online custom matches
- Future goal: multiplayer support via socket server with game IDs

> The long-term vision is to build not just a game, but a **platform** for custom card-based world domination.

---

## 🎯 Tech Stack

- **Engine**: [Godot 4.x](https://godotengine.org/)
- **Language**: C#
- **Architecture**: MVP (Model-View-Presenter) + Clean Use Cases
- **Tests**: NUnit + Moq
- **Multiplayer (planned)**: WebSocket-based server
- **Web Integration (planned)**: User accounts, deck creation, game sharing

---

## 🧱 Project Structure

```
/Game
  /Domain
    /Model         # Core game entities (e.g., Nation, Card, Player)
    /UseCases      # Application logic triggered by user intent (e.g., ChooseNation, PlayTurn)
    /Service       # Helpers used by use cases (e.g., DiceRollService, TurnExecutorService)
    /Repository    # Repository interfaces (e.g., IGameSettingsRepository)
    /Gateway       # Interfaces for external systems (e.g., ICardImageStorageGateway)
  /Presentation
    /View          # Godot scenes and UI components (e.g., MainMenu.tscn)
    /Presenter     # Orchestrators that connect View ↔ UseCases (1:1 with UI screens)
  /Infrastructure
    /Repository    # Repositories (e.g., InMemoryGameSessionRepository)
    /Gateway       # External system implementations (e.g., file upload, API clients)
  /Tests
    /Unit          # NUnit + Moq unit tests
    /Integration   # Future: multiplayer, card loading, etc.
```

---

## ✅ Roadmap

### Core Game
- [x] Project initialization in Godot with C#
- [x] MVP architecture + Clean Use Case separation
- [x] Nation and Card base models
- [x] Basic turn system
- [ ] Simple AI opponent (rule-based)
- [ ] Win conditions and scoring

### Customization System
- [ ] UI for selecting/modifying rules and cards
- [ ] Load user-created cards (including images)
- [ ] In-game card editor (basic prototype)

### Multiplayer Platform
- [ ] Design online game room and ID system
- [ ] User account system (Web)
- [ ] Socket-based match coordination (lobby, sync, turns)

---

## 🤝 Contributions Welcome

This is a community-friendly project.  
Our goals are **clarity**, **clean code**, and **fun through modular design**.

Feel free to open issues, suggest ideas, or send pull requests!

### 🧭 Architectural Guidelines

> This project follows **Clean Architecture** + MVP (Model-View-Presenter).

- **UseCases** = triggered by user intent (e.g., button clicks, menu selections)
- **Presenter** = connects the View (UI) with UseCases, one per screen
- **Model** = domain entities (e.g., Player, Card, Nation)
- **Service** = helper logic used inside UseCases (e.g., DiceRollService)
- **Repository / Gateway** = ports (interfaces) for persistence or external systems

### 📦 Contribution Scope

✅ Feel free to:
- Add new UseCases for game actions
- Add Presenters and Views for new UI screens
- Create new Models (cards, nations, etc.)
- Expand services (turn logic, scoring, AI, etc.)

🚫 Avoid (for now):
- Using Service logic directly inside Presenters (prefer UseCases)
- Mutating Models directly from Views
- Calling external APIs without a Gateway interface

For larger proposals, please open an issue first.

---

## 🛠 Requirements

- Godot 4.x with C# support
- .NET SDK 7+
- (Optional, future) WebSocket server for multiplayer
- (Optional, future) Web app for user-generated content

---

## 📄 License

MIT – free for all uses, including commercial.