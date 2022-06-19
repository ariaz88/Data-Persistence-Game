using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    public Text playerName;
    public Text bestScore;
    string player;
    // Start is called before the first frame update
    void Start()
    {
        if(DataPersist.instance != null)
        {
             player = DataPersist.instance.playerName;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (DataPersist.instance != null)
        {
            int best = DataPersist.instance.bestScore;
            playerName.text = player + " : " + best;
        }
        
        //bestScore.text = ""+ best ;

       
    }

   public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
