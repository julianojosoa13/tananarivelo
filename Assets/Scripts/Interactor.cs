using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private Transform InteractorSource;

    [SerializeField]
    private float InteractRange;

    [SerializeField]
    private Player player;

    private IInteractable currentInteractable; // To track the currently detected IInteractable

    // Update is called once per frame
    void Update()
    {
        HandleInteractionInput();
        DetectInteractable();
    }

    private void HandleInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }

    private void DetectInteractable()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                if (currentInteractable != interactObj)
                {
                    currentInteractable = interactObj;
                    player.ShowInteractBillboard();
                }
                return; // Exit if an interactable is found
            }
        }

        // If no interactable is detected or it is out of range
        if (currentInteractable != null)
        {
            currentInteractable = null;
            player.HideInteractBillboard();
        }
    }

    // Draws a gizmo to represent the ray detection in the Scene view
    private void OnDrawGizmos()
    {
        if (InteractorSource == null)
            return;

        // Ray color
        Gizmos.color = Color.green;

        // Draw the ray from InteractorSource in the forward direction
        Gizmos.DrawRay(InteractorSource.position, InteractorSource.forward * InteractRange);

        // Draw a sphere at the end of the ray
        Gizmos.DrawWireSphere(InteractorSource.position + InteractorSource.forward * InteractRange, 0.1f);
    }
}
