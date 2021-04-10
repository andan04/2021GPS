using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private Player player;
    private EnemySpawner spawner;
    private UI_Time uiTime;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<EnemySpawner>();
        uiTime = FindObjectOfType<UI_Time>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetHP() <= 0)
        {
            gameOverUI.SetActive(true);
            spawner.OffSpawner();
            uiTime.OffTimer();
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitBotton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; } 
#else
        Application.Quit();
    }}
#endif
    
}
