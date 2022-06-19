using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressName : MonoBehaviour
{
    public System.Action<string> onNameChanged; 
    public Text userName;
    //public Text initialText;
    public Text scoreText;
    public InputField inputName;

    public Button NameButton;
    public string SelectedName { get; private set; }

    List<string> playerNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //NameButton = Resources.Load("NameButton") as Button;
    }

    // Update is called once per frame
    void Update()
    {
        SavedData(DataPersist.instance.playerName);
    }
    
    public void Init()
    {
        //textName.text = "BestScore : " + theName + " :0 " + best;

        Button newButton = Instantiate(NameButton, transform);        
       
        newButton.onClick.AddListener(() =>
            {
                string buttonText = inputName.text;
                userName.text =buttonText;
                SelectedName = userName.text;               
                onNameChanged.Invoke(SelectedName);
            });
     }
    
    public string SendText(string name)
    {

        SelectedName = name;

        return SelectedName;
    }

    public void MenuText()
    {   //initialText.text = "BestScore : " ;
        userName.text = " "+ DataPersist.instance.playerName;
        if(DataPersist.instance.highScore < DataPersist.instance.bestScore)
        {
            scoreText.text = "  :  " + DataPersist.instance.bestScore;
        }
        else
        {

            scoreText.text = "  :  " + DataPersist.instance.highScore;
        }         
    }

    public void SavedData(string name)
    {

        if (!playerNames.Contains(name))
        {

            playerNames.Add(name);

            foreach (string item in playerNames)
            {
                Debug.Log("item" + item);
            }
        }
    
    }


}


