using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 playerPos;
    public float moveSpeed = 5f;
    public Rigidbody2D playerRb;
    Vector2 movement;
    public Camera playerCam;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = playerCam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) *Mathf.Rad2Deg;
        playerRb.rotation = angle;
    }
    public void SavePlayer()
    {
        SaveSYST.savePlayer(this);
    }
    public void LoadPlayer()
    {
        GameData data = SaveSYST.LoadPlayer();
         playerPos.x= data.playerPos[0];
        playerPos.y = data.playerPos[1];
        playerRb.transform.position = playerPos;

    }
}
