using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMixManager : MonoBehaviour
{
    public CinemachineMixingCamera mixCamera;

    public float transitionSpeed;
    public float freeLookTargetWeight;
    public float spectateTargetWeight;

    private void Start()
    {
        freeLookTargetWeight = 1;
        spectateTargetWeight = 0;
    }

    public void SwitchCameraState(bool spectate)
    {
        if (spectate == false)
        {
            freeLookTargetWeight = 1;
            spectateTargetWeight = 0;
            return;
        }

        else
        {
            freeLookTargetWeight = 0;
            spectateTargetWeight = 1;
        }
    }

    private void LateUpdate()
    {
        mixCamera.m_Weight0 = Mathf.Lerp(mixCamera.m_Weight0, freeLookTargetWeight, Time.deltaTime * transitionSpeed);
        mixCamera.m_Weight1 = Mathf.Lerp(mixCamera.m_Weight1, spectateTargetWeight, Time.deltaTime * transitionSpeed);

    }
}
