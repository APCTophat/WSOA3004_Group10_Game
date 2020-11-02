using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player1SoundHolder;
    public GameObject Player1SoundHolder2;
    bool Inside = false;
    bool Outside = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Inside = true;
            Outside = false;
        }
        if (Input.GetKeyDown(KeyCode.B))
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
}
