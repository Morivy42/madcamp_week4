# 몰입캠프 4주차 - Unity로 만드는 2인 퍼즐 플랫포머게임


A brief description of what this project does and who it's for
<p>
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Title.png" width = 50%">
</p>

## Authors

- KAIST 전산학부 [김혜연](https://github.com/fairykhy)
- KAIST 전산학부 [모지훈](https://github.com/Morivy42)

## 다운로드

Clone the project

Unity 2022.3.4f1으로 빌드

### 조작법
#### Player 1. 파랑 넙죽이
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Nupzuk_blue.png" width="20%">
- 방향키로 조정
- , . / 키로 감정 표현 (GO!, STOP!, JUMP!)

#### Player 2. 분홍 넙죽이
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Nupzuk_pink.png" width="20%">
- W, A, S, D키로 조정
- Q, E, F 키로 감정 표현 (GO!, STOP!, JUMP!)

#### 메뉴
- 게임 플레이 중 ESC키 누르면 메뉴 창
- 메뉴 창에서 Restart, Leave Game 가능

### 게임 내 장치 설명
#### 1. 초록 블록
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Glass_block.png" width="20%">
- 볼록에 써져있는 만큼의 플레이어가 밀어야 합니다.

#### 2. 분홍 블록 / 파랑 블록
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Blue_block.png" width="20%">
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Pink_block.png" width="20%">
- 파랑 블록은 파랑 넙죽이만, 분홍 블록은 분홍 넙죽이만 밀 수 있습니다.

#### 3. 유리 블록
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Glass_block.png" width="20%">
- 밟으면 사라졌다가 다시 나타납니다.

#### 4. 레이저
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Razor.png" width="20%">
- 레이저에 닿으면 게임오버!

#### 5. 버튼
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Button.png" width="20%">
- 버튼을 누르면 이벤트가 일어납니다.
- Don't Push가 쓰여 있다면 누르지 마세요.

#### 6. 열쇠
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Key.png" width="20%">
- 열쇠를 들고 문을 열어야 문을 열 수 있습니다.
- 두 플레이어가 모두 들어가거나 열쇠를 든 플레이어가 문에 들어간 후 5초 뒤에 클리어됩니다.

#### 7. 엘리베이터
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Button.png" width="20%">
- 자동으로 움직이는 엘리베이터라면 타이밍에 맞춰서 타면 됩니다.
- 숫자가 쓰여져 있다면 쓰여진 숫자만큼의 플레이어가 탑승해야 합니다.

#### 8. 거위
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Goose.png" width="20%">
- 시끄럽게 하면 거위가 따라옵니다.
- 거위와 닿으면 게임오버되니 천천히 조절하며 가야합니다.

#### 9. 신호등
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/TrafficLight.png" width="20%">
- 신호등에 맞춰 걸어야합니다.
- 빨간불에 행동을 하면 게임 오버

## Level 0: Tutorial
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Tutorial.png" width="33%">

#### 레벨 설명
- 조작법을 익히고 게임과 친해지는 레벨입니다.

#### 게임 오브젝트
- 초록 블록(1, 2), 분홍 블록, 파랑 블록, 레이저, 열쇠


## Level 1: Block Map 1
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Level1.png" width="33%">

#### 레벨 설명
- 다양한 블록들을 밀고 협동을 하며 맵을 클리어 할 수 있습니다.

#### 게임 오브젝트
- 초록 블록(1), 분홍 블록, 파랑 블록, 유리 블록, 레이저, 열쇠


## Level 2: Block Map 2

<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Level2-1.png" width="33%">

#### 레벨 설명
- 다양한 블록들을 밀고 협동을 하며 맵을 클리어 할 수 있습니다.

#### 게임 오브젝트
- 초록 블록(1, 2), 분홍 블록, 버튼, 유리 블록, 레이저, 엘리베이터(2), 열쇠


## Level 3: Goose Map
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Goose.png" width="33%">

#### 레벨 설명
- 잠자는 거위를 깨우지 않고 열쇠를 가지고 문에 무사히 도착해야 합니다.

#### 게임 오브젝트
- 거위, 열쇠

## Level 4: Traffic Light Map
<img src="https://github.com/Morivy42/madcamp_week4/blob/main/week4_unity_project/Screenshots/Level2.png" width="33%">

#### 레벨 설명
- 신호를 위반하지 않고 열쇠를 가지고 문에 도착해야 합니다.

#### 게임 오브젝트
- 초록 블록(2), 신호등, 열쇠
