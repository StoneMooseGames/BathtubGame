using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Toggle between the direct and ray interactor if the direct interactor isn't touching any objects
/// Should be placed on a ray interactor
/// </summary>
[RequireComponent(typeof(XRRayInteractor))]
public class ToggleRay : MonoBehaviour
{
    [Tooltip("Switch even if an object is selected")]
    public bool forceToggle = false;

    [Tooltip("The direct interactor that's switched to")]
    public XRDirectInteractor directInteractor = null;

    private XRRayInteractor rayInteractor = null;
    private bool isSwitched = false;
    [SerializeField] private TeleportationProvider provider;        //new

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        SwitchInteractors(false);
    }


    public void ActivateRay()
    {
        if (!TouchingObject() || forceToggle)
            SwitchInteractors(true);
    }

    public void DeactivateRay()
    {
        if (isSwitched)
            SwitchInteractors(false);
    }

    
    #region TeleportToRay()  ---> [Added by Nora]

    /*
    public void TeleportToRay()
    {

        // if Ray is not on:
        if (!isSwitched)
        { return; }



        // if ray is on BUT is not collided with a 3D object
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        { return; }



        // If ray is on, and is colliding with an object WITHOUT a "Teleport" tag:
        if (!hit.collider.CompareTag("Teleport"))
        { return; }



        else
        {
            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = hit.point,
                //destinationRotation = ,

            };

            provider.QueueTeleportRequest(request);
        }

    }

    */
    #endregion


    private bool TouchingObject()
    {
        List<XRBaseInteractable> targets = new List<XRBaseInteractable>();
        directInteractor.GetValidTargets(targets);
        return (targets.Count > 0);
    }

    private void SwitchInteractors(bool value)
    {
        isSwitched = value;
        rayInteractor.enabled = value;
        directInteractor.enabled = !value;
    }
}
