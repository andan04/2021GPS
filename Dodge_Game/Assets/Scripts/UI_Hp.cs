using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hp : MonoBehaviour
{
    private Text hpText;
    private int playerHp = 3;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        hpText = GetComponent<Text>();
        playerHp = player.GetHP();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP : " + player.GetHP();
    }
}
