
using System.Linq.Expressions;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }  
    public PlayerController Input { get; private set; }

    public PlayerLBStateMachine LBStateMachine;
    public PlayerUBStateMachine UBStateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        
        LBStateMachine = new PlayerLBStateMachine(this);
        UBStateMachine = new PlayerUBStateMachine(this);
        LBStateMachine.Initialize(UBStateMachine);
        UBStateMachine.Initialize(LBStateMachine);

        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerController>();   
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LBStateMachine.ChangeState(LBStateMachine.idleState);
    }
}