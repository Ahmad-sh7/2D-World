using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> players;
    private List<GameObject> playerObjects;
    [HideInInspector] public GameObject currentPlayer;

    private int currentSpeed = 5;
    private int[] speeds = { 5, 10, 20 };
    private int speedIndex = 0;

    private void Awake()
    {
        playerObjects = new List<GameObject>();

        foreach (GameObject player in players)
        {
            currentPlayer = player;
            GetChildrenObjects();
            ChangeColor();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = players[0];
        GetChildrenObjects();

        // reset the position to (0,0)
        currentPlayer.transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            ChangeColor();

        ChangePlayer();
        MovePlayer();
    }

    void ChangePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            SetCurrentPlayer(0);

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            SetCurrentPlayer(1);

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            SetCurrentPlayer(2);

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            SetCurrentPlayer(3);
    }

    void SetCurrentPlayer(int index)
    {
        foreach (GameObject playerObject in playerObjects)
            playerObject.GetComponent<Renderer>().sortingOrder = 0;

        currentPlayer = players[index];
        currentSpeed = 5;
        GetChildrenObjects();
        foreach (GameObject playerObject in playerObjects)
            playerObject.GetComponent<Renderer>().sortingOrder = 5;
    }

    void ChangeColor()
    {
        foreach (GameObject playerObject in playerObjects)
            playerObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
            currentPlayer.transform.position += new Vector3(0, currentSpeed) * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            currentPlayer.transform.position += new Vector3(0, -currentSpeed) * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            currentPlayer.transform.position += new Vector3(currentSpeed, 0) * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            currentPlayer.transform.position += new Vector3(-currentSpeed, 0) * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedIndex = (speedIndex + 1) % 3;
            currentSpeed = speeds[speedIndex];
        }
    }

    void GetChildrenObjects()
    {
        playerObjects.Clear();

        int childCount = currentPlayer.transform.childCount;
        GameObject child;

        for (int i = 0; i < childCount; i++)
        {
            child = currentPlayer.transform.GetChild(i).gameObject;
            playerObjects.Add(child);

            // Check if the childObject has children also
            if (child.transform.childCount > 0)
                for (int j = 0; j < child.transform.childCount; j++)
                    playerObjects.Add(child.transform.GetChild(j).gameObject);
        }
    }
}
