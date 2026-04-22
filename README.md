# Projeto Endless Runner - Tecnologias Multimédia

Trabalho Prático 1 desenvolvido no âmbito da disciplina de Tecnologias Multimédia (2025/2026).

## Equipa de Desenvolvimento
* **André Bacelo** - Número: 33200
* **Simão Figueiredo** - Número: 33401

---

## Detalhes Técnicos
* **Motor de Jogo:** Unity
* **Versão do Unity:** 6000.3.11f1
* **Linguagem:** C#

---

## Descrição do Jogo e Funcionalidades
O jogo desenvolvido enquadra-se no tema "Endless Runner". O jogador controla uma personagem que se desloca continuamente para a frente num cenário gerado de forma infinita. 

**Funcionalidades Implementadas:**
* **Movimento Baseado em Física:** Utilização de `Rigidbody` e forças para o controlo de saltos e gravidade melhorada.
* **Geração Procedural:** O chão (tiles), os obstáculos e as moedas são instanciados e destruídos dinamicamente para otimizar a memória.
* **Dificuldade Incremental:** A velocidade do jogo aumenta progressivamente ao longo do tempo.
* **Algoritmo de Rota Segura:** O sistema garante que existe sempre um caminho possível (Safe Lane) para o jogador não ficar encurralado.
* **Interface e Persistência (UI):** Menus dinâmicos, contagem de moedas, distância percorrida e gravação permanente do "High Score" usando `PlayerPrefs`.
* **Múltiplas Cenas:** Gestão de transições entre o Menu Principal e a Cena de Jogo via `SceneManager`.

---

## Jogabilidade e Controlos
**Objetivo:** Sobreviver o máximo de tempo possível, evitando bater nos obstáculos vermelhos, e apanhar o maior número de moedas para bater o recorde pessoal de distância!

**Controlos:**
* `A` ou `Seta Esquerda` - Mudar para a faixa da esquerda.
* `D` ou `Seta Direita` - Mudar para a faixa da direita.
* `Espaço` ou `W` ou `Seta Cima` - Saltar por cima das barreiras baixas.

**Regras:**
* Tocar num obstáculo (caixotes ou barreiras) resulta em Game Over imediato.
* Bater o recorde atual guarda automaticamente a nova pontuação no sistema.

---

## Como abrir e correr o projeto
1. Faz o **Clone** ou descarrega este repositório para o teu computador.
2. Abre o **Unity Hub**.
3. Clica em `Add` e seleciona a pasta raiz deste repositório.
4. Abre o projeto (garante que tens a versão 6000.3.11f1 instalada).
5. Na aba *Project* em baixo, navega até `Assets/Scenes`.
6. Clica duas vezes na cena **`MainMenu`**.
7. Clica no botão **Play** (▶) no topo do ecrã para iniciar o jogo.

---

## Assets Multimédia

**Modelos 3D e Texturas:**

**Áudio (SFX e Música):**

---