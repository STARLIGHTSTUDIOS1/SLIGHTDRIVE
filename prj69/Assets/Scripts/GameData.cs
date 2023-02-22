using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData 
{
    public float[] playerPos;

    public GameData(PlayerMovement playermovement)
    {
        playerPos = new float[2];
        playerPos[0] = playermovement.transform.position.x;
        playerPos[1] = playermovement.transform.position.y;
    }
}
