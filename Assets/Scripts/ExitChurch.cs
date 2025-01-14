using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitChurch : MonoBehaviour, IInteractable
{
    [SerializeField] private GameManager gameManager;


    [SerializeField] private Player playerInside;

    [SerializeField] private Transform initialPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        gameManager.ExitBuilding();

        playerInside.transform.position = initialPos.position;
        playerInside.transform.rotation = initialPos.rotation;
    }
}
