using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject cardTemplate;
    private List<Deck.Card> cardsInStock = new List<Deck.Card>();
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private int cardSpacing = 50;

    private List<GameObject> cardObjects = new List<GameObject>();

    // Adds card to inventory to be rendered
    public void AddToInventory(Deck.Card newCard)
    {
        cardsInStock.Add(newCard);
        UpdateInventory();
    }

    public void Start()
    {
        // AddTestCard();
        // AddTestCard();
        // AddTestCard();
    }

    public void AddTestCard()
    {
        AddToInventory(
            new Deck.Card(
                "Test",
                "Head",
                "Rare",
                0,
                0,
                0,
                "So, what kind of dragon are you? Gathering Phase: Light three hexagans on fire around the map. Combat Phase: Gain a fire breath that shoots 3 hexagons forward for 15 attack. Accuracy: 13 ",
                "None",
                "Mythical",
                defaultSprite,
                "None"
            )
        );
    }

    private void UpdateInventory()
    {
        // Clean up old card objects
        cardObjects.ForEach(delegate (GameObject cardObj)
        {
            Destroy(cardObj.gameObject);
        });
        cardObjects.Clear();
        // Add new card object based on the current inventory
        for (int i = 0; i < cardsInStock.Count; i++)
        {
            Deck.Card currentCard = cardsInStock[i];
            cardObjects.Add(Instantiate(
                cardTemplate,
                new Vector3(960, 540 - (cardSpacing * i), 0),
                Quaternion.identity,
                this.gameObject.transform
            ));
            cardObjects[i].GetComponent<InventoryCard>().SetCardRef(currentCard);
        }
    }

    private void Update()
    {
        // Debug.Log(cardsInStock.Count);
    }
}