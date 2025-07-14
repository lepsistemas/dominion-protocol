# Dominion Protocol

**Dominion Protocol** is a strategic card-based war game built in [Godot Engine](https://godotengine.org/) using C#.
It blends classic territorial conquest gameplay with dynamic, AI-driven global events.

> The world is unstable. Treaties have failed. New threats emerge.  
> The protocol has been activated.

---

## 🕹 Game Concept

- Turn-based warfare inspired by *Risk/WAR*
- Each player controls a nation and seeks to dominate neighbors
- Game actions are driven by a deck of strategic cards
- Unexpected global events (e.g. disasters, revolts, economic crashes) generated via AI
- Scalable system for DLCs (e.g. alien invasions, AI singularity)

---

## 🎯 Tech Stack

- **Engine**: [Godot 4.x](https://godotengine.org/)
- **Language**: C# 11
- **Architecture**: MVP (Model-View-Presenter) + Clean Use Cases
- **Tests**: NUnit + Moq
- **AI Integration**: OpenAI (GPT-4 or compatible) via API

---

## 🧱 Project Structure

```
/Game
  /Domain
	/Model          # Core entities (Country, Card, Player, etc.)
	/UseCases       # Game logic (e.g., AttackCountry, DrawCard)
  /Presentation
	/View           # Godot scenes and UI
	/Presenter      # Connects View <-> UseCases
  /Infra
	/AiGateway      # External communication with ChatGPT
	/MockAiGateway  # For testing without real API calls
/Tests              # NUnit tests
```

---

## ✅ Roadmap

- [x] Project initialization in Godot with C#
- [x] Basic MVP architecture scaffolding

---

## 🤝 Contributions Welcome

This is a community-friendly project.  
Our goals are **clarity**, **clean code**, and **fun through modular design**.

Feel free to open issues, suggest ideas, or send pull requests!

---

## 🛠 Requirements

- Godot 4.x with C# support
- .NET SDK 7+
- (Optional) OpenAI API Key for AI features

---

## 📄 License

MIT – free for all uses, including commercial.

---
