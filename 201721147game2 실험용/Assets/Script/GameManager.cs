using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public GameObject[] Stages;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStage()
    {
        if(stageIndex < Stages.Length -1){
        Stages[stageIndex].SetActive(false);
        stageIndex ++;
        Stages[stageIndex].SetActive(true);
        Playerposition();
        }
    }

    void Playerposition()
    {
        player.transform.position = new Vector3(0, 0, 0);
        player.VelocityZero();
    }

    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
