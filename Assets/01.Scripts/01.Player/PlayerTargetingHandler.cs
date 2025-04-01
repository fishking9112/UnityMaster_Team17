using UnityEngine;

public class PlayerTargetingHandler : MonoBehaviour
{
    Camera cam;
    [SerializeField] LayerMask targetMask;
    Vector3 targetPos;
    [SerializeField] GameObject targetObj;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if(Physics.Raycast(cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out RaycastHit hitInfo, 100f, targetMask))
        {
            targetPos = hitInfo.point;
        }
        else
        {
            targetPos = cam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));
            targetPos.z = 100f;
        }

        targetObj.transform.position = targetPos;
    }
}