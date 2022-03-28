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
    [SerializeField] private GameObject gridHolder, dice, player1, player2, canvasRotator;
    [SerializeField] private Camera cameraMain;
    [HideInInspector] public Vector3 camPosMain;
    [HideInInspector] public Color movementColor = new Color(1f, 1f, 1f, 0.5f);

    public List<GameObject> rangeHexes = new List<GameObject>();
    public GameObject currentPlayer;

    //Start the game with player 1 rolling to move
    void Start()
    {
        camPosMain = cameraMain.transform.position;
        currentPlayer = player1;
        StartCoroutine(PlaceDigsites());
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
                    //Revert(1) will revert the last child which is reserved for the movement and are lighting up
                    rangeHexes[i].GetComponent<HexScript>().Revert(1);
                }
                if(currentPlayer == player1) { currentPlayer = player2; StartCoroutine(TurnStart(2)); }
                else { currentPlayer = player1; StartCoroutine(TurnStart(1)); }
            }
        }
    }

    //This is where caling the DiceRoll function returns. Currently it only has functionality for moving
    public void RollResult(int result, string type)
    {
        StartCoroutine(ZoomOut());
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
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / 15f;

            if (t > 1)
            {
                t = 1;
            }

            cameraMain.transform.position = Vector3.Lerp(cameraMain.transform.position, new Vector3(currentPlayer.transform.position.x, currentPlayer.transform.position.y, -5), t);
            if(cameraMain.transform.position.z > -5.01f)
            {
                break;
            }
            yield return null;
        }

        cameraMain.transform.position = new Vector3(currentPlayer.transform.position.x, currentPlayer.transform.position.y, -5);

        if (playerNum == 1)
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

    //Coroutine that places all the gravesites one by one at the beginning of the game
    IEnumerator PlaceDigsites()
    {
        int i = 0;
        float interval = 0.05f;
        while(i <= 16)
        {
            int site = Random.Range(0, gridHolder.transform.childCount);
            if (gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes.Count < 5)
            {
                continue;
            }
            bool alreadyAssigned = false;
            for(int j = 0; j < gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes.Count; j++)
            {
                List<ArrayList> hexList = gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes;
                GameObject hex = (GameObject)hexList[j][0];
                if (hex.GetComponent<HexScript>().type != "")
                {
                    alreadyAssigned = true;
                }
            }
            if(alreadyAssigned == true)
            {
                continue;
            }
            gridHolder.transform.GetChild(site).GetComponent<HexScript>().MoundHex();
            i++;
            yield return new WaitForSeconds(interval);
        }
        i = 0;
        while (i <= 12)
        {
            int site = Random.Range(0, gridHolder.transform.childCount);
            if (gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes.Count < 6)
            {
                continue;
            }
            bool alreadyAssigned = false;
            for (int j = 0; j < gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes.Count; j++)
            {
                List<ArrayList> hexList = gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes;
                GameObject hex = (GameObject)hexList[j][0];
                if (hex.GetComponent<HexScript>().type != "")
                {
                    alreadyAssigned = true;
                }
            }
            if (alreadyAssigned == true)
            {
                continue;
            }
            gridHolder.transform.GetChild(site).GetComponent<HexScript>().GraveHex();
            i++;
            yield return new WaitForSeconds(interval);
        }
        i = 0;
        while (i <= 8)
        {
            int site = Random.Range(0, gridHolder.transform.childCount);
            if (gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes.Count < 6)
            {
                continue;
            }
            bool alreadyAssigned = false;
            for (int j = 0; j < gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes.Count; j++)
            {
                List<ArrayList> hexList = gridHolder.transform.GetChild(site).GetComponent<HexScript>().nearHexes;
                GameObject hex = (GameObject)hexList[j][0];
                if (hex.GetComponent<HexScript>().type != "")
                {
                    alreadyAssigned = true;
                }
            }
            if (alreadyAssigned == true)
            {
                continue;
            }
            gridHolder.transform.GetChild(site).GetComponent<HexScript>().MausoleumHex();
            i++;
            yield return new WaitForSeconds(interval);
        }
        StartCoroutine(TurnStart(1));
    }

    //This is a corourtine that controls the camera zooming out after the dice is rolled for movement
    IEnumerator ZoomOut()
    {
        float t = 0f;
        Vector3 currentCameraPos = cameraMain.transform.position;
        while (t < 1)
        {
            t += Time.deltaTime / 0.25f;

            if (t > 1)
            {
                t = 1;
            }

            cameraMain.transform.position = Vector3.Lerp(currentCameraPos, new Vector3(camPosMain[0], camPosMain[1], camPosMain[2]), t);
            if (cameraMain.transform.position.z < camPosMain[2] + 0.01f)
            {
                break;
            }
            yield return null;
        }

        cameraMain.transform.position = new Vector3(camPosMain[0], camPosMain[1], camPosMain[2]);
    }
}
