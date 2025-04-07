using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CSE_CameraZoom : CutsceneElementBase
{
    [SerializeField] private float targetFov;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float returnDelay = 1f; // tempo antes de voltar pro player
    private CinemachineVirtualCamera vCam;

    private Transform originalFollow;
    private float originalFov;
    private Vector3 originalPosition;

    public override void Execute()
    {
        vCam = cutsceneHandler.vCam;

        // Salva configs antigas
        originalFollow = vCam.Follow;
        originalFov = vCam.m_Lens.FieldOfView;
        originalPosition = vCam.transform.position;

        // Para cutscene focar no target
        vCam.Follow = null;

        StartCoroutine(ZoomCamera());
    }


    private IEnumerator ZoomCamera()
    {
        Vector3 targetPosition = target.position + offset;
        float startTime = Time.time;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            vCam.m_Lens.FieldOfView = Mathf.Lerp(originalFov, targetFov, t);
            vCam.transform.position = Vector3.Lerp(originalPosition, targetPosition, t);

            elapsedTime = Time.time - startTime;
            yield return null;
        }

        vCam.m_Lens.FieldOfView = targetFov;
        vCam.transform.position = targetPosition;

        yield return new WaitForSeconds(returnDelay);

        StartCoroutine(ReturnCamera());
    }

    private IEnumerator ReturnCamera()
    {
        float startTime = Time.time;
        float elapsedTime = 0;

        Vector3 currentPos = vCam.transform.position;
        float currentFov = vCam.m_Lens.FieldOfView;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            vCam.m_Lens.FieldOfView = Mathf.Lerp(currentFov, originalFov, t);
            vCam.transform.position = Vector3.Lerp(currentPos, originalPosition, t);

            elapsedTime = Time.time - startTime;
            yield return null;
        }

        vCam.m_Lens.FieldOfView = originalFov;
        vCam.transform.position = originalPosition;
        vCam.Follow = originalFollow;
        cutsceneHandler.PlayNextElement();


    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
