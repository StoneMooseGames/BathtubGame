using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Set the interaction layer of an interactor
/// </summary>
public class SetInteractionLayer : MonoBehaviour
{
    [Tooltip("The layer that's switched to")]
    public LayerMask targetLayer = 0;

    private XRBaseInteractor interactor = null;
    private LayerMask originalLayer = 0;

    private void Awake()
    {
        interactor = GetComponent<XRBaseInteractor>();
        originalLayer = interactor.interactionLayers.value;
    }

    public void SetTargetLayer()
    {
        interactor.interactionLayers = targetLayer.value;
    }

    public void SetOriginalLayer()
    {
        interactor.interactionLayers = originalLayer.value;
    }

    public void ToggleTargetLayer(bool value)
    {
        if (value)
        {
            SetTargetLayer();
        }
        else
        {
            SetOriginalLayer();
        }
    }

}
