using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataPersist : MonoBehaviour
{
    
    public static DataPersist instance;

    public string playerName;
    public string lastPlayer;
    public int bestScore;
    public int highScore;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null)
        {

            Destroy(gameObject);
        }
        

        LoadData();
        //Debug.Log(" Button Pressed" + playerName);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(" highScore" + highScore);
    }

    [System.Serializable]
    class NameData
    {
        public string yourName;
        public int yourScore;
    }
   
    public void SaveData() 
    {
        NameData data = new NameData();

        data.yourName = playerName;
        data.yourScore = bestScore;
        

        string newjson = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/mysavefile.json" , newjson);
    
    }
    public void LoadData() 
    {
        string path = Application.persistentDataPath + "/mysavefile.json";
        if (File.Exists(path))
        {
            string newjson = File.ReadAllText(path);
            NameData data = JsonUtility.FromJson<NameData>(newjson);
            playerName = data.yourName;           
            bestScore =  data.yourScore;
            lastPlayer = playerName;
            //highScore = bestScore;
        }

    }
}
