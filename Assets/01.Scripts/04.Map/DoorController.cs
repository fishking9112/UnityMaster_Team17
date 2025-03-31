using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorController : MonoBehaviour
{
    public Door[] doors;

    // 실행예제
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OpenDoorIndex(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OpenDoorIndex(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OpenDoorIndex(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OpenDoorIndex(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            OpenDoorIndex(4);
        }
    }
    private void OpenDoorIndex(int index)
    {
        doors[index].OpenDoor();
    }
}
