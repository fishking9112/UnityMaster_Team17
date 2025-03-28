
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public PlayerController Input { get; private set; }
    public CharacterController Controller { get; private set; }
    [field: SerializeField] public PlayerSO playerSO { get; private set; }

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
        Controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LBStateMachine.ChangeState(LBStateMachine.lb_IdleState);
        UBStateMachine.ChangeState(UBStateMachine.ub_UnArmedState);

    }

    private void Update()
    {
        LBStateMachine.HanldeInput();
        UBStateMachine.HanldeInput();
        LBStateMachine.Update();
        UBStateMachine.Update();
    }

    private void FixedUpdate()
    {
        LBStateMachine.PhysicsUpdate();
        UBStateMachine.PhysicsUpdate();
    }
}