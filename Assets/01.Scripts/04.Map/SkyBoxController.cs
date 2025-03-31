using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    [Range(0.0f, 1.0f)]private float time;
    public float timeRate;
    private float skyRotation;

    private void Start()
    {
        timeRate = 1.0f / timeRate;
    }
    private void Update()
    {
        time = (time + timeRate * Time.deltaTime) % 1.0f;

        skyRotation = time * 360.0f;
        RenderSettings.skybox.SetFloat("_Rotation", skyRotation);
    }
}
