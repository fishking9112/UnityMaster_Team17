using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public Transform interactionPos;
    public Vector3 boxSize;
    public float boxDistance;
    public LayerMask interactableObjectLayerMask;

    private GameObject _curInteractGameObject;
    private InteractableObject _curInteractableObject;

    private void Start()
    {
        ClearInteraction();
    }

    private void Update()
    {
        BoxInteraction();
    }

    /// <summary>
    /// 박스캐스트를 통해 상호작용 가능한 오브젝트와 상호작용할 준비를 하는 함수
    /// 상호작용 가능한 오브젝트가 박스캐스트에 닿으면 이름과 설명이 UI에 출력된다.
    /// </summary>
    private void BoxInteraction()
    {
        RaycastHit[] hits = Physics.BoxCastAll(interactionPos.position, boxSize / 2, interactionPos.forward, Quaternion.identity, boxDistance, interactableObjectLayerMask);
        if (hits.Length > 0)
        {
            RaycastHit hit = hits[0];

            if (hit.collider.gameObject != _curInteractGameObject)
            {
                _curInteractGameObject = hit.collider.gameObject;
            }

            if (_curInteractableObject != null)
            {
                _curInteractableObject.OffOutline();
            }

            _curInteractableObject = hit.collider.GetComponent<InteractableObject>();
            _curInteractableObject.OnOutline();

            SetNameText();
            SetDescriptionText();
        }
        else
        {
            ClearInteraction();
        }
    }

    /// <summary>
    /// 상호작용 정보 초기화
    /// </summary>
    private void ClearInteraction()
    {
        if (_curInteractableObject != null)
        {
            _curInteractableObject.OffOutline();
        }

        _curInteractGameObject = null;
        _curInteractableObject = null;
    }

    /// <summary>
    /// 오브젝트의 이름을 UI에 출력하는 함수
    /// </summary>
    private void SetNameText()
    {
        Debug.Log(_curInteractableObject.GetNameText());
    }

    /// <summary>
    /// 오브젝트의 설명을 UI에 출력하는 함수
    /// </summary>
    private void SetDescriptionText()
    {
        Debug.Log(_curInteractableObject.GetDescriptionText());
    }

    /// <summary>
    /// Input System의 값을 받아 상호작용 가능한 오브젝트와 상호작용하는 함수
    /// </summary>
    /// <param name="context"> 상호작용 할 키 </param>
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && _curInteractableObject != null)
        {
            _curInteractableObject.OnInteract();
            _curInteractGameObject = null;
            _curInteractableObject = null;
        }
    }

    /// <summary>
    /// 박스 캐스트 그리기
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(interactionPos.position + interactionPos.forward * boxDistance, boxSize);
    }
}
