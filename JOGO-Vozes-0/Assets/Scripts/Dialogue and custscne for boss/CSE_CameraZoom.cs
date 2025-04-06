using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CSE_CameraZoom : CutsceneElementBase
{
    [SerializeField] private float targetFov;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private CinemachineVirtualCamera vCam;

    public override void Execute()
    {
        vCam = cutsceneHandler.vCam;
        vCam.Follow = null;
        StartCoroutine(ZoomCamera());
    }

    private IEnumerator ZoomCamera()
    {
       Vector3 originalPosition = vCam.transform.position;
       Vector3 targetPosition = target.position + offset;

        float originalSize = vCam.m_Lens.FieldOfView;
        float startTime= Time.time;
        float elapseTime = 0;

        while (elapseTime < duration)
        {
            float t = elapseTime / duration;
            vCam.m_Lens.FieldOfView = Mathf.Lerp(originalSize, targetFov, t);
            vCam.transform.position = Vector3.Lerp(originalPosition, targetPosition, t);

            elapseTime = Time.time - startTime;
            yield return null;
        }
        vCam.m_Lens.FieldOfView = targetFov;
        vCam.transform.position = targetPosition;

        cutsceneHandler.PlayNextElement();
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
