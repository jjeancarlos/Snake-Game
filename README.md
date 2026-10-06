# Snake Game (Unity 2D)

Um clone simples do clássico jogo da cobrinha (Snake), inspirado nos jogos que vinham
pré-instalados em celulares Nokia. Movimento em grade, sem física, visual minimalista.

> **Status do projeto:** versão inicial funcional. A cobra se move, cresce ao comer,
> e o jogo termina ao colidir com a parede ou com o próprio corpo. Ainda não há
> assets visuais (sprites), UI de placar, tela de Game Over ou sons — apenas a
> lógica base do jogo.

## Como o jogo funciona

- A cobra se move em um grid fixo (padrão 20x20), avançando um quadrado por vez
  em intervalos regulares (não é movimento livre/contínuo).
- Use as **setas do teclado** para mudar de direção.
- Ao encontrar a comida, a cobra cresce um segmento e uma nova comida aparece
  em uma posição aleatória do grid.
- O jogo termina se a cobra colidir com a borda do grid ou com o próprio corpo.

## Requisitos

- **Unity Hub** instalado.
- **Unity Editor** (recomendado: mesma versão usada na criação do projeto —
  confira em `ProjectSettings/ProjectVersion.txt` após clonar).
- Template usado: **2D (Core)**.

## Como instalar e rodar o projeto

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/jjeancarlos/Snake-Game.git
   ```

2. **Abra o Unity Hub** e clique em **Add** > **Add project from disk**, selecionando
   a pasta clonada.

3. Se o Unity Hub pedir para instalar a versão do Editor correspondente, aceite a
   instalação (ou instale manualmente pela aba **Installs** do Hub).

4. Abra o projeto pelo Hub. Ele pode levar alguns minutos na primeira vez, pois o
   Unity precisa reconstruir a pasta `Library/` (cache local, não versionado no Git).

5. Na aba **Project**, abra a cena principal em `Assets/Scenes` e dê o **Play**.

## Configuração importante: Input System

Este projeto usa a classe `Input` clássica do Unity (`UnityEngine.Input`). Se o
Editor mostrar o erro abaixo ao rodar:

```
InvalidOperationException: You are trying to read Input using the UnityEngine.Input
class, but you have switched active Input handling to Input System package in
Player Settings.
```

Verifique em **Edit > Project Settings > Player > Other Settings > Active Input
Handling** se está configurado como **Input Manager (Old)** ou **Both**. Essa
configuração já vai commitada no repositório (dentro de `ProjectSettings/`), então
isso normalmente não deve ocorrer — mas fica registrado aqui como referência caso
o Editor peça para reconfigurar.

## Estrutura do projeto

```
Assets/
  Scripts/
    GameManager.cs       # Controla spawn de comida e estado de game over
    SnakeController.cs   # Lógica de movimento, colisão e crescimento da cobra
  Scenes/                # Cena principal do jogo
ProjectSettings/          # Configurações do projeto (inclui Input System)
Packages/                 # Dependências do Unity Package Manager
```

## Próximos passos planejados

- [ ] Adicionar sprites para cobra, comida e fundo (estilo retrô/pixel art).
- [ ] UI de placar (score).
- [ ] Tela de Game Over com opção de reiniciar.
- [ ] Efeitos sonoros (comer, colisão).
- [ ] Movimento suavizado (interpolação visual entre os passos do grid).

## Licença

Projeto pessoal / de estudo. Sem licença formal definida ainda.
