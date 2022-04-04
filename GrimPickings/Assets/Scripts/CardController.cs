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

    public IEnumerator digging(string graveType)
    {
        cardUI.transform.localPosition = new Vector3(-800, 0, 0);
        Animator anim = cardUI.GetComponent<Animator>();
        List<Deck.Card> cardDeck = GameController.GetComponent<Deck>().partsCardDeck;
        if (graveType == "Mound")
        {
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
            while (Input.GetMouseButtonDown(0) == false)
            {
                yield return null;
            }
            anim.SetBool("drawing", false);
            while(collect == false)
            {
                yield return null;
            }
        }
        else if (graveType == "Grave")
        {
            int count = 0;
            while (count < 2)
            {
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
                while (collect == false)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (graveType == "Mausoleum")
        {
            int count = 0;
            while (count < 3)
            {
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
                while (collect == false)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        yield return new WaitForSeconds(0.5f);

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
