using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
public class InteractionController : MonoBehaviour
{
    public ActionBasedSnapTurnProvider locomotionSnapProvider;

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

    private void InteractionActive(InputAction.CallbackContext obj) => onGrabActive.Invoke();


    public void DisableSnapTurningRight() => locomotionSnapProvider.rightHandSnapTurnAction.action.Disable();

    public void EnableSnapTurningRight() => locomotionSnapProvider.rightHandSnapTurnAction.action.Enable();

    public void DisableSnapTurningLeft() => locomotionSnapProvider.leftHandSnapTurnAction.action.Disable();

    public void EnableSnapTurningLeft() => locomotionSnapProvider.leftHandSnapTurnAction.action.Enable();

}
