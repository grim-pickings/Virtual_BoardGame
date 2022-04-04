using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject GameController, cardUI, heldInventory, storedInventory, equipbutton;
    public Text cardName, cardPart, cardRarity, cardHealth, cardAttack, cardSpeed, cardAbility, cardCurse;
    public Image image;
    private bool equip = false;
    public bool collect = false;
    private int currentPart = 0;

    //Coroutine that is called from the game controller if the tile moved too is a dig site
    public IEnumerator digging(string graveType)
    {
        //Starts card off screen, this can be changed to a deck off to the side if we want to visualize it as such
        cardUI.transform.localPosition = new Vector3(-800, 0, 0);
        Animator anim = cardUI.GetComponent<Animator>();

        //List of cards from the card deck in the Deck script
        List<Deck.Card> cardDeck = GameController.GetComponent<Deck>().partsCardDeck;

        //checked what type of dig site it is and add to the loop counter for each type
        int loop = 0;
        if (graveType == "Mound")
        {
            loop = 1;
        }
        else if (graveType == "Grave")
        {
            loop = 2;
        }
        else if (graveType == "Mausoleum")
        {
            loop = 3;
        }

        int count = 0;
        while (count < loop)
        {
            //this simply adjusts the card info and runs the card drawing until it meets the loop amount
            cardUI.transform.localPosition = new Vector3(-800, 0, 0);
            collect = false;
            anim.SetBool("drawing", true);
            int i = Random.Range(0, cardDeck.Count);
            cardName.text = cardDeck[i].name;
            cardPart.text = "Part: " + cardDeck[i].bodyPart;
            cardRarity.text = cardDeck[i].rarity;
            cardHealth.text = cardDeck[i].health.ToString(); ;
            cardAttack.text = cardDeck[i].attack.ToString(); ;
            cardSpeed.text = cardDeck[i].speed.ToString(); ;
            cardAbility.text = "Ability: " + cardDeck[i].ability;
            cardCurse.text = "Curse: " + cardDeck[i].curse;
            cardDeck.Remove(cardDeck[i]);
            count++;
            while (Input.GetMouseButtonDown(0) == false)
            {
                yield return null;
            }
            anim.SetBool("drawing", false);
            //collect is called when the card animation for stashing in the inventory is done
            while (collect == false)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);

        //long and conveluted variables being called from other places that starts the next players turn. This will be gone soon
        GameController.GetComponent<GameController>().currentPlayer.GetComponent<PlayerMovement>().FindTile();
        if (GameController.GetComponent<GameController>().currentPlayer == GameController.GetComponent<GameController>().player1) 
        { 
            GameController.GetComponent<GameController>().currentPlayer = GameController.GetComponent<GameController>().player2; 
            StartCoroutine(GameController.GetComponent<GameController>().TurnStart(2)); 
        }
        else 
        { 
            GameController.GetComponent<GameController>().currentPlayer = GameController.GetComponent<GameController>().player1; 
            StartCoroutine(GameController.GetComponent<GameController>().TurnStart(1)); 
        }
    }
}
