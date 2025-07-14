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

## 🧱 Game Code Structure

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
```

## 🧪 Test Structure

```
/Test
  /DominionProtocol.Tests
	/Architecture  # High-level architecture enforcement (e.g., layer boundaries rules via NetArchTest)
	/Unit          # NUnit + Moq unit tests
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

See [CONTRIBUTING.md](CONTRIBUTING.md) for architecture guidelines and contribution scope.

---

## 🛠 Requirements

- Godot 4.x with C# support
- .NET SDK 7+
- (Optional, future) WebSocket server for multiplayer
- (Optional, future) Web app for user-generated content

---

## 📄 License

MIT – free for all uses, including commercial.
