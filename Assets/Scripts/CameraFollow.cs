using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private PlayerScript playerScript;

    private void Awake()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    void Start()
    {
        transform.position = new Vector3(playerScript.currentPlayer.transform.position.x, playerScript.currentPlayer.transform.position.y, -10);
    }

    void Update()
    {
        transform.position = new Vector3(playerScript.currentPlayer.transform.position.x, playerScript.currentPlayer.transform.position.y, -10);
    }
}
