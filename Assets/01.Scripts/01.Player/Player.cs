
using Cinemachine;
using System.Collections;
using System.Linq.Expressions;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }
    public PlayerController Input { get; private set; }
    public CharacterController Controller { get; private set; }
    [field: SerializeField] public PlayerSO playerSO { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public PlayerBoundHandler BoundHandler { get; private set; }
    public Image crosshair;

    public Coroutine controllerSizingCoroutine { get; private set; }
    [field: SerializeField] public CinemachineVirtualCamera AimVCam { get; private set; } 

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
        ForceReceiver = GetComponent<ForceReceiver>();
        Rigidbody = GetComponent<Rigidbody>();
        BoundHandler = GetComponent<PlayerBoundHandler>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LBStateMachine.ChangeState(LBStateMachine.lb_IdleState);
        UBStateMachine.ChangeState(UBStateMachine.ub_UnArmedState);
        crosshair.enabled = false;
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

    public void StartControllerSizing(float time = 0, float centerY = 1, float height = 2)
    {
        if (controllerSizingCoroutine != null)
        {
            StopCoroutine(controllerSizingCoroutine);
        }
        controllerSizingCoroutine = StartCoroutine(SetController(time, centerY, height));
    }

    private IEnumerator SetController(float time, float targetCenterY, float targetHeight)
    {
        if (time <= 0)
        {
            Controller.center = new Vector3(0, targetCenterY, 0);
            Controller.height = targetHeight;
            yield break;
        }

        float elapsedTime = 0f;
        float currentCenterY = Controller.center.y;
        float currentHeight = Controller.height;

        while (elapsedTime < time)
        {
            //float t = elapsedTime / time; // 선형 보간
            //float t = 1f - Mathf.Pow(1f - (elapsedTime / time), 2); // ease_out // 처음엔 빠르게 나중에 느리게
            //float t = Mathf.Pow(elapsedTime / time, 2); //ease-in // 처음에 느리게 나중엔 빠르게

            float t = (elapsedTime / time);
            t = t * t * (3f - 2f * t);
            //Ease - In - Out

            Controller.center = new Vector3(0, Mathf.Lerp(currentCenterY, targetCenterY, t), 0);
            Controller.height = Mathf.Lerp(currentHeight, targetHeight, t); ;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Controller.center = new Vector3(0, targetCenterY, 0);
        Controller.height = targetHeight;
    }
}