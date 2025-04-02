using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player.gameObject;
    }

    // Update is called once per frame
    
    private void LateUpdate()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.y = 10.0f;    // MiniMap Cam의 높이는 Player보다 높아야 한다.

        this.transform.position = playerPos;
    }
}
