using UnityEngine;

public class PlayerTargetingHandler : MonoBehaviour
{
    Camera cam;
    [SerializeField] LayerMask targetMask;
    Vector3 bulletTargetPos; // 2.총알은 여기로 가면 됨.
    [SerializeField] GameObject targetObj;
    public Transform bulletStartPos; // 1.총알은 여기서 발사됨.

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if(Physics.Raycast(cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out RaycastHit hitInfo, 100f, targetMask))
        {
            bulletTargetPos = hitInfo.point;
        }
        else
        {
            bulletTargetPos = cam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));
            bulletTargetPos.z = 100f;
        }

        targetObj.transform.position = bulletTargetPos;
    }
}