using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterChurch : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Transform exitPos;
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

        gameManager.EnterBuilding("ChurchInterior", exitPos);
    }
}
