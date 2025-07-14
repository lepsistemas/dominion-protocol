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
- **Language**: C# 11
- **Architecture**: MVP (Model-View-Presenter) + Clean Use Cases
- **Tests**: NUnit + Moq
- **Multiplayer (planned)**: WebSocket-based server
- **Web Integration (planned)**: User accounts, deck creation, game sharing

---

## 🧱 Project Structure

```
/Game
/Domain
/Model # Core entities (Nation, Card, Player, etc.)
/UseCases # Game logic (e.g., AttackCountry, DrawCard)
/Presentation
/View # Godot scenes and UI
/Presenter # Connects View <-> UseCases
/Infra
/Persistence # Save/load systems, future multiplayer support
/CardImport # Custom card loaders (planned)
/Tests # NUnit tests
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

---

## 🛠 Requirements

- Godot 4.x with C# support
- .NET SDK 7+
- (Optional, future) WebSocket server for multiplayer
- (Optional, future) Web app for user-generated content

---

## 📄 License

MIT – free for all uses, including commercial.