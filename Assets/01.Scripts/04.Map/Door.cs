using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animation anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animation>();
    }
    public void OpenDoor()
    {
        anim.Play("open");
    }
}
