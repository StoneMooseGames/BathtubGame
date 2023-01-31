using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class NewLever : XRBaseInteractable
{
    
    public Transform handle = null;

    public int defaultValue = 1;
    public int Value { get; private set; } = 1;


    public Transform[] snapPositions;


    public UnityEvent OnLeverReverse = new UnityEvent();
    public UnityEvent OnLeverStop = new UnityEvent();
    public UnityEvent OnLeverSpeed1 = new UnityEvent();


    private XRBaseInteractor selectInteractor = null;


    private void Start()
    {
        FindSnapPosition(defaultValue);
        SetValue(defaultValue);
    }

    #region OTHER
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


    private void ApplyValue(SelectExitEventArgs eventArgs)
    {
        XRBaseInteractor interactor = eventArgs.interactor;
        bool isOn = InOnPosition(interactor.transform.position);

        FindSnapPosition(isOn);
        SetValue(isOn);
    }


    private bool InOnPosition(Vector3 interactorPosition)
    {
        interactorPosition = transform.InverseTransformPoint(interactorPosition);
        return (interactorPosition.z > 0);
    }

    #endregion

    private void FindSnapPosition(int isOn)
    {
        var shortestDistance = Vector3.Distance(snapPositions[0].position, handle.transform.position);
        var bestSnap = snapPositions[0];


        foreach(var snapPosition in snapPositions)
        {

            // Distance between lever and snap position
            var distance = Vector3.Distance(snapPosition.position, handle.transform.position);


            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                bestSnap = snapPosition;
            }

        }

        handle.transform.rotation = bestSnap.rotation;
        
    }

    private void SetValue(int isOn)
    {
        Value = isOn;



        if (Value == 0)
        {
            OnLeverReverse.Invoke();
        }


        else if (Value == 1)
        {
            OnLeverStop.Invoke();
        }


        else
        {
            OnLeverSpeed1.Invoke();
        }
    }
    
}

