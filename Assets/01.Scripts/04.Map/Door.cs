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
        //StartCoroutine(CloseDoor());
    }

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(3f);
        anim.Play("close");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("close");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("open");
        }
    }
}
