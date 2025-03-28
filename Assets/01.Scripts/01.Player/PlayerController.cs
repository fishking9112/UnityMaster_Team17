using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Generate C# class로 생성된 클래스. InputActionAsset/InputActionMap/InputAction를 래핑하고 있음.
    public PlayerInputs playerInput { get; private set; }
    public PlayerInputs.PlayerActions playerActions { get; private set; }

    private void Awake()
    {
        playerInput = new PlayerInputs(); // 플레이어 인풋 인스턴스를 생성. 각각의 플레이어가 개별적인 입력 처리를 할 수 있게 됨.(로컬 멀티플레이 상황에서 특히 유용)
        playerActions = playerInput.Player; // "Player" 액션맵에 접근
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
