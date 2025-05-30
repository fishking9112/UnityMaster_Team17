
<div align="center">

# UnityMaster_Team17
  
![image](https://github.com/user-attachments/assets/1164d6c4-dbd9-4c86-8df0-396a8d611047)

**`스파르타 내일배움캠프에서 Unity 심화주차 과제로 진행한 자율주제 팀 프로젝트입니다.`**

</div>

---

## 📝 개요

* **제목** : Spartan XXVII : Fires of Rtan
* **장르** : 3D TPS 슈팅게임
* **개발 환경** : Unity 2022.3.17f1
* **인원** : 김용정(팀장), 강영준, 정창범, 한만진, 윤지열 - 총 5명
* **개발 기간** : 2025.03.27 ~ 2025.04.02 (7일)

---

## 🎮 게임 기능

| 기능 | 설명 |
|---|---|
|**플레이어 이동**|WASD 키로 이동하고, Space Bar 키를 눌러 점프할 수 있습니다. 그리고 Left Shift 키를 눌러 대쉬할 수 있습니다.|
|**아이템 획득**|E키를 눌러 아이템을 획득할 수 있습니다. 아이템은 총 3가지로 탄창 박스, 수리 키트, 유탄이 존재합니다.|
|**플레이어 공격**|마우스 오른쪽 버튼을 눌러 조준한 상태에서 왼쪽 버튼을 누르면 공격할 수 있으며, G키를 눌러 유탄을 발사할 수 있습니다.|
|**퀘스트 시스템**|일정구간에 진입하면 퀘스트가 시작되며 조건에 따라 퀘스트가 클리어됩니다. 퀘스트를 클리어해야 다음 지역으로 이동할 수 있습니다.|
|**다양한 몬스터**|로봇, 군인, 터렛, 보스 등 다양한 몬스터가 존재합니다. 해당 몬스터들과 전투를 하는 것이 이 게임의 핵심입니다.|

---

## 📸 플레이 화면

![화면구성](https://github.com/user-attachments/assets/5de8f87c-c752-4bc7-b382-a7a76671f772)

---

## 👥 팀원 및 역할


|팀원|역할|GitHub 링크|
|---|---|---|
|**김용정**|팀장, UI|https://github.com/fishking9112|
|**강영준**|Player|https://github.com/YJ402|
|**정창범**|Data, Quest, Item|https://github.com/JeongChangBeom|
|**한만진**|Map|https://github.com/ManJin12|
|**윤지열**|Enemy|https://github.com/Yun-Jiyeol|

--- 

## 🤝 협업 툴

**GitHub:** 코드 버전 관리 및 협업

**Notion:** 프로젝트 문서 정리 및 일정 관리

**Figma:** 구조 설계 및 프로토타이핑

**Google Sheets:** 데이터 테이

---

## 🔧 사용 기술 스택  


### 🚶 플레이어 상하체 분리 FSM
  
|다이어 그램|
|---|
|<img src="https://github.com/user-attachments/assets/08de4312-917d-4658-9c73-04199cf3eaa8" width="700"/>|
|장점: 움직임(하체)과 행동(상체)에서 각각 상태를 가질 수 있음.|
|단점: 관리의 복잡함. (StateMachine 간 통신) ex_조준 모드시 게걸음|

|레이어|
|---|
|<img src="https://github.com/user-attachments/assets/ed92cfe4-cb15-41a6-8013-ae80cd48a4ec" width="700"/>|
|상체 하체 레이어를 분리|

|마스킹|
|---|
|<img src="https://github.com/user-attachments/assets/6f0a3f3b-0289-490d-8aee-eac0f95a0575" width="700"/>|
|마스킹을 통해 원하는 부위의 애니메이션만 출력|

|FSM를 활용한 애니메이션 마스킹 적용|
|---|
|![11-_online-video-cutter com_-_1_](https://github.com/user-attachments/assets/1e9d79d4-45a5-4279-b017-7a3a5c51df5a)|

---

### 📊 데이터 연동 – Google Sheet To Unity

해당 프로젝트에서는 Google Sheet To Unity를 활용하여 퀘스트와 대화 데이터를 관리합니다.

**Google Sheet 데이터 테이블**
- 대화 데이터 [(보기)](https://docs.google.com/spreadsheets/d/1v_nkmbO8MzXts1qLHKEclOda4oLwR9PBHfJRSuYwYRE/edit?gid=0#gid=0)

**Scriptable Object 활용**
Google Sheet의 데이터를 Scriptable Object로 만들어서 관리합니다. 커스텀 에디터로 만든 버튼을 눌러 데이터를 불러올 수 있습니다.

|Scriptable Object|
|---|
|<img src="https://github.com/user-attachments/assets/726c19d0-802a-429c-8558-02d0eb853d1b" width="500"/>|

---

### 💥 OBB 충돌처리

**OBB 충돌처리를 통해 보스 몬스터의 부위 파괴를 구현했습니다.**

|OBB Collider|부위 파괴|
|---|---|
|![unnamed](https://github.com/user-attachments/assets/b7818240-4d3a-4b13-a5bf-615324632da8)|![unnamed](https://github.com/user-attachments/assets/e89491f5-f542-440f-af35-07a5139602c8)|

---

### 🗺 AI Navigation 몬스터

**AI Navigation을 활용하여 적 몬스터가 자동으로 플레이어를 감지하고 공격하는 패턴을 구현했습니다.**

객체가 플레이어를 인식하는 로직은 크게 3가지가 있습니다.

${\textsf{\color{red}1. 플레이어와의 거리를 확인하는 로직}}$ </br>
${\textsf{\color{blue}2. 플레이어가 시야각 내에 존재하며 거리를 확인하는 로직}}$ </br>
${\textsf{\color{yellow}3. 플레이어에게 Ray를 쏴 객체의 시야에 플레이어가 존재하는가를 확인하는 로직}}$ </br>

|AI 몬스터 감지 로직 이미지|플레이어 감지|
|---|---|
|<img src="https://github.com/user-attachments/assets/c42043c9-bf0b-41b5-9c26-dacf40d0e4ee" width="400"/>|<img src="https://github.com/user-attachments/assets/65fa59a5-7e78-4bcf-ac73-ba5300903c8a" width="500"/>|

---

## 📹 플레이 영상

[유튜브 링크](https://youtu.be/uby08K4Ww8U)

---


![Image](https://github.com/user-attachments/assets/3bc771db-eb3b-4f06-9c31-491d14bbf143)




---
