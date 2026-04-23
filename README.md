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
O jogo desenvolvido enquadra-se no tema "Endless Runner". O jogador controla uma personagem que se desloca continuamente para a frente num cenário gerado de forma infinita através de um sistema procedural.

**Funcionalidades Implementadas:**
* **Movimento Baseado em Física:** Utilização de `Rigidbody` e forças para o controlo de saltos e aplicação de gravidade extra para evitar o efeito de flutuação.
* **Geração Procedural:** O chão (tiles), os obstáculos e as moedas são instanciados e destruídos dinamicamente para otimização de memória e performance.
* **Sistema de Power-ups (Estrela):** Implementação de um bónus de velocidade temporário utilizando `Coroutines` (`IEnumerator`). Este sistema permite alterar a velocidade de forma assíncrona, restaurando o estado original após o tempo definido.
* **Dificuldade Incremental:** A velocidade base do jogo aumenta progressivamente através de uma variável de aceleração por segundo.
* **Algoritmo de Rota Segura:** O sistema de spawn garante que, em cada bloco, pelo menos uma das três faixas está livre de obstáculos intransponíveis (*Safe Lane*).
* **Otimização de Hierarquia:** Todos os itens são instanciados como "filhos" do tile de chão respetivo, garantindo que a limpeza da cena é feita de forma eficiente pelo Unity.
* **Interface e Persistência (UI):** Menus de navegação, contagem de moedas em tempo real, distância percorrida e gravação de "High Score" local através de `PlayerPrefs`.
* **Gestão de Cenas:** Transições fluidas entre o Menu Principal e a Cena de Jogo via `SceneManager`.

---

## Jogabilidade e Controlos
**Objetivo:** Sobreviver o máximo de tempo possível, evitando colisões com obstáculos, enquanto se recolhe moedas para maximizar a pontuação e bater o recorde de distância.

**Controlos:**
* `A` ou `Seta Esquerda` - Mover para a faixa da esquerda.
* `D` ou `Seta Direita` - Mover para a faixa da direita.
* `Espaço`, `W` ou `Seta Cima` - Saltar.

**Regras:**
* Colisão com obstáculos resulta em fim de jogo (*Game Over*) imediato.
* Apanhar a **Estrela** multiplica a velocidade atual por 2 durante 5 segundos.
* O recorde de distância é guardado automaticamente ao atingir uma nova marca.

---

## Como abrir e correr o projeto
1. Faz o **Clone** ou descarrega este repositório.
2. Abre o **Unity Hub**.
3. Clica em `Add` e seleciona a pasta raiz deste projeto.
4. Abre o projeto com a versão **6000.3.11f1**.
5. No painel *Project*, navega até `Assets/Scenes`.
6. Abre a cena **`MainMenu`**.
7. Clica no botão **Play** (▶) para iniciar.

---

## Assets Multimédia

**Modelos 3D e Texturas:**
* **Origem:** Utilizamos o pacote [Stylized Character Pack](https://assetstore.unity.com/packages/3d/characters/stylized-character-pack-360808).
* **Otimização Técnica:** Modelos de baixa contagem poligonal (*Low Poly*) para maximizar o desempenho.
* **Formatos:** Texturas em **.png** e **.jpg** (512px/1024px) para reduzir o consumo de memória de vídeo (VRAM).

**Áudio (SFX e Música):**
* **Formatos:** Efeitos sonoros rápidos em **.wav** (sem compressão para resposta imediata) e música ambiente em **.mp3** (alta compressão para reduzir o tamanho do ficheiro final).

---

## Observações e Lacunas Identificadas
* **Deteção de Colisões:** Foi utilizada a configuração `Continuous Collision Detection` no Rigidbody do jogador para mitigar o risco de atravessar objetos a velocidades extremas.
* **Spawn de Itens:** Identificou-se que, raramente, um power-up pode sobrepor-se visualmente a uma moeda. Esta lacuna foi minimizada ajustando o desfasamento no eixo Z entre os spawns de diferentes tipos de objetos.
