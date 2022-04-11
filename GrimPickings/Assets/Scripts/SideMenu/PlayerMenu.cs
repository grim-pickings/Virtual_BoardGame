using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    // reference to the player's actual menu
    [SerializeField] private GameObject menu;
    // determines position of menu
    [SerializeField] private bool isPlayerOne;
    // hald of the menu's width
    [SerializeField] private float menuPositionCalibration = 150f;

    private void Start()
    {
        if (!menu)
        {
            Debug.Log("Menu is not connected");
        }
        else if (!menu.activeSelf)
        {
            toggleMenu();
        }
    }

    private void Update()
    {
        UpdateMenuPosition();
    }

    // Move & orientate menu for correct player
    private void UpdateMenuPosition()
    {
        if (!menu) return;
        float startingSideX = isPlayerOne ? menuPositionCalibration : 1920f - menuPositionCalibration;
        Vector3 pos = menu.transform.position;
        pos.x = startingSideX;
        menu.transform.position = pos;
    }

    // private void Update()
    // {
    //     if (!menu) return;
    // }



    // toggle menu open/close
    public void toggleMenu()
    {
        // changes whether it's active based on it's current state
        if (menu)
        {
            menu.SetActive(!menu.activeSelf);
        }
    }

}
