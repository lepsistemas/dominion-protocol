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