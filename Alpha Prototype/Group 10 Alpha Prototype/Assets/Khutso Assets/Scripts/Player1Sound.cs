using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player1SoundHolder;
    public GameObject Player1SoundHolder2;
    public GameObject Player1;
    public GameObject Player2;
    public bool Inside = false;
    public bool Outside = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player2.GetComponent<Alex.Carvalho.Beta_Script_P2_Movment>().NowInside==true)
        {
            Inside = true;
            Outside = false;
        }
        if (Player1.GetComponent<Alex.Carvalho.Beta_Script_P1_Collision>().NowOutside==true)
        {
            Inside = false;
            Outside = true;
        }
        if (Inside == true)
        {
            if ((Input.GetButtonDown("Player 1 Horizontal")))
            {
                Player1SoundHolder.SetActive(true);
            }
            if ((Input.GetButtonUp("Player 1 Horizontal")))
            {
                Player1SoundHolder.SetActive(false);
            }
            if ((Input.GetButtonDown("Player 1 Vertical")))
            {
                Player1SoundHolder2.SetActive(true);
            }
            if ((Input.GetButtonUp("Player 1 Vertical")))
            {
                Player1SoundHolder2.SetActive(false);
            }
        }
        else
        {
            Player1SoundHolder.SetActive(false);
            Player1SoundHolder2.SetActive(false);
        }
    }
    public void Player1Inside()
    {
        Inside = true;
        Outside = false;
    }

    public void Player1Outside()
    {
        Inside = false;
        Outside = true;
    }
}
