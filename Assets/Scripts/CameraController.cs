using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;
    public float rotationalSpeed = 10f;
    public float bottomClamp = -40f;
    public float topClamp = 70f;

    private float cinemachineTargetPitch;
    private float cinemachineTargetYaw;

    private void LateUpdate()
    {
        CameraLogic();
    }

    private void CameraLogic()
    {
        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");

        cinemachineTargetPitch = UpdateRotation(cinemachineTargetPitch, inputY, bottomClamp, topClamp, true);
        cinemachineTargetPitch = UpdateRotation(cinemachineTargetPitch, inputX, float.MinValue, float.MaxValue, false);
        
        ApplyRotations(cinemachineTargetPitch, cinemachineTargetYaw);
    }

    private void ApplyRotations(float pitch, float yaw)
    {
        followTarget.localRotation = Quaternion.Euler(pitch, yaw, followTarget.eulerAngles.z);
    }

    private float UpdateRotation(float currentRotation, float input, float min, float max, bool isXAxis)
    {
        currentRotation += isXAxis ? -input : input;
        return Mathf.Clamp(currentRotation, min, max);
    }
    
    private float GetMouseInput(string axis)
    {
        return Input.GetAxis(axis) * rotationalSpeed * Time.deltaTime;
    }
}