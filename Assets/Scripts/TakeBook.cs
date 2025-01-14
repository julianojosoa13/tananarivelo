using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeBook : MonoBehaviour, IInteractable
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject book;
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
        book.SetActive(false);
        gameManager.FinishQuest();
    }
}
