using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image backgroundShader;
    [SerializeField] private TMP_Text TurnText;
    [SerializeField] private GameObject dice, player1, player2, canvasRotator;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Color movementColor = new Color(0f, 0f, 1f, 0.25f);

    public List<GameObject> rangeHexes = new List<GameObject>();
    public GameObject currentPlayer;

    //Start the game with player 1 rolling to move
    void Start()
    {
        currentPlayer = player1;
        StartCoroutine(TurnStart(1));
    }

    //This uses a raycast from the camera to the mouse pointers position to determine where it is clicking. If it is clicking a tile that is
    //lit up with the movement color then the playe rmoves to that tile and it starts the other players turn
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<SpriteRenderer>().color == movementColor)
            {
                currentPlayer.transform.position = hit.collider.transform.position;
                currentPlayer.GetComponent<PlayerMovement>().FindTile();
                for(int i = 0; i < rangeHexes.Count; i++)
                {
                    rangeHexes[i].GetComponent<HexScript>().Revert();
                }
                if(currentPlayer == player1) { currentPlayer = player2; StartCoroutine(TurnStart(2)); }
                else { currentPlayer = player1; StartCoroutine(TurnStart(1)); }
            }
        }
    }

    //This is where caling the DiceRoll function returns. Currently it only has functionality for moving
    public void RollResult(int result, string type)
    {
        switch (type)
        {
            case "move":
                currentPlayer.GetComponent<PlayerMovement>().MoveArea(result);
                break;
            case "attack":
                break;
        }
    }

    //Coroutine that controls everything that happnes at the begining of the turn with rolling for movement and displaying whose turn it is
    IEnumerator TurnStart(int playerNum)
    {
        if(playerNum == 1)
        {
            canvasRotator.transform.localRotation = Quaternion.Euler(0, 0, -90);
            TurnText.text = "Player 1's Turn";
        }
        else if (playerNum == 2)
        {
            canvasRotator.transform.localRotation = Quaternion.Euler(0, 0, 90);
            TurnText.text = "Player 2's Turn";
        }
        dice.GetComponent<DiceScript>().DiceRoll(8, "move");
        float a = 0f;
        while (a < 0.785)
        {
            a += 0.004f;
            backgroundShader.color = new Color(0f, 0f, 0f, a);
            TurnText.color = new Color(1f, 1f, 1f, a + 0.215f);
            yield return new WaitForSeconds(0.0025f);
        }
        yield return new WaitForSeconds(6f);
        while (a > 0)
        {
            a -= 0.004f;
            backgroundShader.color = new Color(0f, 0f, 0f, a);
            TurnText.color = new Color(1f, 1f, 1f, a);
            yield return new WaitForSeconds(0.0025f);
        }
        TurnText.color = new Color(1f, 1f, 1f, 0f);
    }
}
