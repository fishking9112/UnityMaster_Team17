using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindPlayer : MonoBehaviour
{
    public GameObject RaycastPosition;
    public float checkRate;
    public float maxCheckDistance;
    public LayerMask layerMask;
    private float lastCheckTime = 0;

    //임시용
    public GameObject Player;


    public bool IsPlayerInFieldOfView(float fieldOfView)
    {
        //Vector3 directionToPlayer = CharacterManager.Instance.Player.transform.position - transform.position;
        //float angle = Vector3.Angle(transform.forward, directionToPlayer);

        //return angle < fieldOfView * 0.5f;

        return false;
    }

    public bool IsPlayerInSight()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = new Ray(RaycastPosition.transform.position, Player.transform.position - RaycastPosition.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance))
            {
                if (hit.collider.gameObject == Player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
