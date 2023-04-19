using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject face;
    [SerializeField] GameObject rightEye;
    [SerializeField] GameObject leftEye;
    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject body;
    [SerializeField] GameObject rightLeg;
    [SerializeField] GameObject leftleg;
    [SerializeField] GameObject player1;
    List<GameObject> player1Objects;

    private int currentSpeed = 5;
    private int[] speeds = { 5, 10, 20 };
    private int speedIndex = 0;

    private void Awake()
    {
        player1Objects = new List<GameObject>();
        player1Objects.Add(face);
        player1Objects.Add(rightEye);
        player1Objects.Add(leftEye);
        player1Objects.Add(rightHand);
        player1Objects.Add(leftHand);
        player1Objects.Add(body);
        player1Objects.Add(rightLeg);
        player1Objects.Add(leftleg);
    }

    // Start is called before the first frame update
    void Start()
    {
        // reset the position to (0,0)
        transform.position = new Vector2(0, 0);

        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            ChangeColor();

        MovePlayer();
    }

    void ChangeColor()
    {
        foreach (GameObject gameObject in player1Objects)
            gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, currentSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -currentSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(currentSpeed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-currentSpeed, 0) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedIndex = (speedIndex + 1) % 3;
            currentSpeed = speeds[speedIndex];
        }
    }
}
