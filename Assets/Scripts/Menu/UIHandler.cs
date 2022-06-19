using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
[DefaultExecutionOrder(1000)]

  
public class UIHandler : MonoBehaviour
{
    [SerializeField] Text bestText;
    public PressName PressName;
    // Start is called before the first frame update
   public void NewNameSelected(string name)
    {
        //Debug.Log(" Button Pressed" + name);
        DataPersist.instance.playerName = name;
       
    }

    void Start()
    {
        PressName.MenuText();
        PressName.Init();
        PressName.onNameChanged += NewNameSelected;
        //PressName.SavedData(DataPersist.instance.lastPlayer);
        //string loadName = PressName.SendText(DataPersist.instance.playerName);
        //Debug.Log("Menu" + loadName);
       
    }

    // Update is called once per frame
    void Update()
    {        
        
    }
   
    public void StartGame()
    {
        //if(SceneManager.GetActiveScene().name == "Menu")
        //{
        //    SceneManager.LoadScene("Main");
        //}
        //else
        //{
        //    SceneManager.LoadScene("Menu");
        //}
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        DataPersist.instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
         Application.Quit();
#endif

    }

   

}
