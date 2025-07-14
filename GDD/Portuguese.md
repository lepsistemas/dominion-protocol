# 🎮 Dominion Protocol – Game Design Document (v0.2)

## 1. Visão Geral

- **Gênero:** Estratégia por turnos com cartas
- **Tema:** Conflitos entre nações históricas **dentro do mesmo período**
- **Plataformas alvo:** ⚠️ *a definir com base em custo/viabilidade*
  - PC (via Steam) → exige taxa de publicação
  - Android → fácil distribuição, difícil depuração/teste
  - iOS → requer conta de desenvolvedor paga
  - Web? → possível como PWA ou Godot exportado (sem login fácil)

## 2. Objetivo do Jogo

O jogador deve usar cartas e decisões estratégicas para aumentar sua **Influência Global**.  
Ao final de **10 rodadas** (configuráveis), vence quem tiver a maior pontuação.

### 🧭 Componentes da Influência Global:
- 🛡 **Poder Militar**
- 🧠 **Avanço Tecnológico**
- 🕊 **Diplomacia Internacional**

> Este modelo favorece jogos **rápidos (quick game)** para mobile, mas também permite **partidas customizadas** no futuro.

## 3. Setup Inicial da Partida

### 🔥 Combate entre Nações:
- **Sempre entre nações do mesmo período** (ex: Japão vs. China em época Medieval)
- Cada nação tem uma **identidade estratégica** (ex: Alemanha Moderna = Tech++, Japão Feudal = Military++, Índia Moderna = Diplomacy++)

### 🔄 Deck Inicial:
- Cada jogador recebe **5 cartas**
  - A composição **pode variar por nação**
  - Exemplo:  
    - Nação militar: 3 Action, 1 Boost, 1 Event  
    - Nação diplomática: 2 Diplomacy Boosts, 2 Events, 1 Action

## 4. Sistema de Cartas

### Tipos:
| Tipo    | Função                                                                 |
|---------|------------------------------------------------------------------------|
| **Boost**  | Aumenta stats ou previne efeitos negativos (ex: reforçar diplomacia) |
| **Action** | Ataques diretos, sabotagens, operações militares                     |
| **Event**  | Fenômenos imprevisíveis (naturais, políticos, culturais)             |

> As cartas têm efeitos **influenciados pelo valor do dado** (1d6) lançado no turno.

### 💳 Raridade:
- Comum, Rara, Épica, Lendária

### 🃏 Evolução do Deck:
- A cada 2 rodadas: compra 1 carta (comum/aleatória)
- A cada vitória significativa: pode ganhar uma carta
- Cartas novas também podem ser obtidas via:
  - **Progressão no jogo (XP, conquistas)**
  - **Microtransações** (packs pagos)

## 5. Turno de Jogo

### 🎲 Ordem:
1. Jogador rola 1d6
2. Escolhe uma carta da mão
3. Carta é executada com efeito modulado pelo dado
4. Eventos globais são processados (se aplicável)
5. Jogador pode descartar 1 carta e comprar outra

## 6. Sistema de Atributos (Stats)

Cada nação começa com valores diferentes em:

| Atributo     | Efeitos principais |
|--------------|--------------------|
| **Military** | Ataque/defesa diretos, dano |
| **Tech**     | Efeitos secundários, multiplicadores, proteção |
| **Diplomacy**| Redução de dano, negação de ataques, conversão |

Exemplo:

| Nação            | Military | Tech | Diplomacy |
|------------------|----------|------|-----------|
| Japão (Feudal)   | 3        | 1    | 1         |
| Alemanha Moderna | 2        | 3    | 2         |
| Índia Moderna    | 1        | 2    | 3         |

## 7. Condições de Vitória

### 🏆 Quick Game (Padrão):
- **10 rodadas fixas**
- **Influência Global** define o vencedor:

```
Influência = (Military * 1.2) + (Tech * 1.3) + (Diplomacy * 1.5) + Pontos de Evento
```

### 🛠 Custom Game (PvP com login):
- Jogadores podem definir:
  - Número de turnos
  - Nação e baralho personalizado
  - Modo competitivo (com ranking)
  - Modo de “eliminação direta” (vence quem zerar o adversário)

## 8. Microtransações (opcional)

- Compras de **pacotes de cartas**
- Personalização estética (avatar, fundo do campo, moldura das cartas)
- Nada de “pay-to-win” direto — efeitos fortes serão balanceados por **custo de uso** ou **risco no dado**

## 9. Login e Plataforma

### 🔐 Login:
- Será necessário para:
  - Ranking
  - Decks personalizados
  - Partidas PvP entre amigos

### 🎯 Estratégia inicial:
- Rodar o jogo **sem login**, com deck padrão
- Adicionar login **depois**, integrando com:
  - Google Account (via Android ou Web)
  - Steam Login (caso vá para PC)
  - Backend próprio com OAuth2 (se for via website/app)

## ✅ Próximos Passos

1. Finalizar a **lista de nações iniciais** e seus stats
2. Definir quantidade inicial de cartas por tipo e raridade
3. Criar estrutura de dados para:
   - `Nation`
   - `Card`
   - `Deck`
   - `Player`
4. Prototipar a HUD de partida (campo de cartas, stats, botão de dado, etc)
5. Escrever lógica base do turno