using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class NewLever : XRBaseInteractable
{
    [Tooltip("The object that's grabbed and manipulated")]
    public Transform handle = null;

    [Tooltip("The initial value of the lever")]
    public int defaultValue = 1;



    // When the lever is activated
    public UnityEvent OnLeverActivate = new UnityEvent();

    // When the lever is deactivated
    public UnityEvent OnLeverDeactivate = new UnityEvent();



    //public bool Value { get; private set; } = false;
    public int Value { get; private set; } = 1;

    private XRBaseInteractor selectInteractor = null;

    private void Start()
    {
        FindSnapDirection(defaultValue);
        SetValue(defaultValue);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(StartGrab);
        selectExited.AddListener(EndGrab);
        selectExited.AddListener(ApplyValue);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(StartGrab);
        selectExited.RemoveListener(EndGrab);
        selectExited.RemoveListener(ApplyValue);
    }

    private void StartGrab(SelectEnterEventArgs eventArgs)
    {
        selectInteractor = eventArgs.interactor;
    }

    private void EndGrab(SelectExitEventArgs eventArgs)
    {
        selectInteractor = null;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected)
            {
                Vector3 lookDirection = GetLookDirection();
                handle.forward = transform.TransformDirection(lookDirection);
            }
        }
    }

    private Vector3 GetLookDirection()
    {
        Vector3 direction = selectInteractor.transform.position - handle.position;
        direction = transform.InverseTransformDirection(direction);

        direction.x = 0;
        direction.y = Mathf.Clamp(direction.y, 0, 1);

        return direction;
    }

    private void ApplyValue(SelectExitEventArgs eventArgs)
    {
        XRBaseInteractor interactor = eventArgs.interactor;
        bool isOn = InOnPosition(interactor.transform.position);

        FindSnapDirection(defaultValue);
        SetValue(defaultValue);
    }

    private bool InOnPosition(Vector3 interactorPosition)
    {
        interactorPosition = transform.InverseTransformPoint(interactorPosition);
        return (interactorPosition.z > 0);
    }

    private void FindSnapDirection(int isOn)
    {
        //handle.forward = isOn ? transform.forward : -transform.forward;
        handle.forward = true ? transform.forward : -transform.forward;
        
    }

    private void SetValue(int isOn)
    {
        Value = isOn;

        /*
        if (Value)
        {
            OnLeverActivate.Invoke();
        }
        else
        {
            OnLeverDeactivate.Invoke();
        }*/

        if (Value == 4)
        {
            OnLeverActivate.Invoke();
        }
        else if (Value == 3)
        {
            OnLeverActivate.Invoke();
        }
        else if (Value == 2)
        {
            OnLeverActivate.Invoke();
        }
        else if (Value == 1)
        {
            OnLeverActivate.Invoke();
        }
        else
        {
            OnLeverDeactivate.Invoke();
        }
    }
}

