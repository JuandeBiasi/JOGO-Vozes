using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private Transform cam;
    public float parallaxEffectX;
    public float parallaxEffectY;

    void Start()
    {
        cam = Camera.main.transform;
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update()
    {
        float distX = (cam.position.x * parallaxEffectX);
        float distY = (cam.position.y * parallaxEffectY);

        transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);
    }
}
