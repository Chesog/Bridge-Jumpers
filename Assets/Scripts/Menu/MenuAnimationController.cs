using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private Animator gateAnimator;
    [SerializeField] private string startGameAnimationParam;
    [SerializeField] private string startGateAnimationParam;
    [SerializeField] private float waitTime;
    private IEnumerator openGate;

    private void OnEnable()
    {
        if (cameraAnimator == null)
            cameraAnimator = GetComponent<Animator>();

        openGate = OpenGate();
    }

    private IEnumerator OpenGate()
    {
        yield return new WaitForSeconds(waitTime);
        gateAnimator.SetBool(startGateAnimationParam,true);
    }
    
    private IEnumerator LoadNewLevel()
    {
        yield return new WaitForSeconds(waitTime);
        gateAnimator.SetBool(startGateAnimationParam,true);
    }

    public void StartGameAnimation()
    {
        menuCanvas.SetActive(false);
        StopCoroutine(openGate);
        cameraAnimator.SetBool(startGameAnimationParam,true);
        StartCoroutine(openGate);
    }

    public void ResetCameraAnimation()
    {
        cameraAnimator.SetBool(startGameAnimationParam,true);
    }
}
