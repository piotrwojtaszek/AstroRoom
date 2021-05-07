using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
public class InteractionController : MonoBehaviour
{
    public ActionBasedSnapTurnProvider locomotionSnapProvider;
    public GameObject teleportationController;

    public InputActionReference interactionActivationReference;

    [Space]
    public UnityEvent onGrabActive;
    public UnityEvent onGrabCancel;

    private void Start()
    {
        interactionActivationReference.action.performed += InteractionActive;
        interactionActivationReference.action.canceled += InteractionCancel;
    }

    private void InteractionCancel(InputAction.CallbackContext obj) => onGrabCancel.Invoke();

    private void DeactivateTeleporter() => onGrabCancel.Invoke();

    private void InteractionActive(InputAction.CallbackContext obj) => onGrabActive.Invoke();


    public void DisableSnapTurning()
    {
        locomotionSnapProvider.rightHandSnapTurnAction.action.Disable();
    }

    public void EnableSnapTurning()
    {
        locomotionSnapProvider.rightHandSnapTurnAction.action.Enable();
    }
}
