using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class TeleportController : MonoBehaviour
{
    public GameObject baseControllerGameoObject;
    public GameObject teleportationGameObject;

    public InputActionReference teleportationActivationReference;

    [Space]
    public UnityEvent onTeleportationActive;
    public UnityEvent onTeleportationCancel;

    private void OnEnable()
    {
        teleportationActivationReference.action.performed += TeleportationActive;
        teleportationActivationReference.action.canceled += TeleportationCancel;
    }

    private void OnDisable()
    {
        teleportationActivationReference.action.performed -= TeleportationActive;
        teleportationActivationReference.action.canceled -= TeleportationCancel;
    }

    private void TeleportationCancel(InputAction.CallbackContext obj) => Invoke("DeactivateTeleporter", .1f);

    private void DeactivateTeleporter() => onTeleportationCancel.Invoke();

    private void TeleportationActive(InputAction.CallbackContext obj) => onTeleportationActive.Invoke();
}
