using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using TMPro;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Transform player;

    private void Update()
    {
        gameOver();
    }
    void gameOver()
    {
        if(player.transform.position.y < -2.0)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
}
