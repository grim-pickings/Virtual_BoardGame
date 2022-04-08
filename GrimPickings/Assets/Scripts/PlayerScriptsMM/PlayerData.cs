using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    private float health = 0;
    private float attack = 0;
    private float speed = 0;

    private Sprite partImage;

    private GameObject statTextObject;
    private TextMeshProUGUI statText;

    // get reference to creature image parts.
    public GameObject Head;
    public GameObject Body;
    public GameObject LeftArm;
    public GameObject RightArm;
    public GameObject LeftLeg;
    public GameObject RightLeg;

    // Start is called before the first frame update
    void Start()
    {
        // change this to public and remove object reference.
        statTextObject = this.transform.Find("StatsLabel").gameObject;
        statText = statTextObject.GetComponent<TextMeshProUGUI>();

    }

    // function to update stat label information with passed in data. 
    // logic is not complete, getting a new part will directly add to stats.
    // needs to remove values from the removed part first. 
    public void StatUpdate(string bodyPart, int healthPart, int attackPart, int speedPart, Sprite imagePart)
    {
        //string itemName = dugItem.GetComponent<ItemData>().itemName;
        //float stat1Val = dugItem.GetComponent<ItemData>().Stat1;
        //float stat2Val = dugItem.GetComponent<ItemData>().Stat2;
        //float stat3Val = dugItem.GetComponent<ItemData>().Stat3;

        health += healthPart;
        attack += attackPart;
        speed += speedPart;

        //partImage = dugItem.GetComponent<ItemData>().image;

        statText.text = "Health: " + health + "\nAttack: " + attack + "\nSpeed : " + speed;
        Debug.Log(bodyPart);

        // for now make it a random choice to apply to left or right side. change it later so the player selects a button to set the side.
        if(bodyPart == "Leg" || bodyPart == "Arm")
        {
            // pick a random number, if 1 Left, if 2 Right.
            int i = Random.Range(1, 3);
            Debug.Log(i);
            if (i == 1)
            {
                bodyPart = bodyPart.Insert(0, "Left ");
            } else
            {
                bodyPart = bodyPart.Insert(0, "Right ");
            }
        }

        // switch statement dependent on body part type. 
        switch (bodyPart)
        {
            case "Left Leg":
                LeftLeg.GetComponent<Image>().sprite = imagePart;
                break;
            case "Right Leg":
                RightLeg.GetComponent<Image>().sprite = imagePart;
                break;
            case "Left Arm":
                LeftArm.GetComponent<Image>().sprite = imagePart;
                break;
            case "Right Arm":
                RightArm.GetComponent<Image>().sprite = imagePart;
                break;
            case "Torso":
                Body.GetComponent<Image>().sprite = imagePart;
                break;
            case "Head":
                Head.GetComponent<Image>().sprite = imagePart;
                break;
            case "empty":
                // do nothing.
                break;
            default:
                Debug.Log("No match found for StatUpdate switch statement.");
                break;
        }
    }
}
