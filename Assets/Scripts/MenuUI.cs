using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public string playerName;
    public static MenuUI Instance;

    
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
    // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //LoadColor(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inputName(string inputPlayer){
        MenuUI.Instance.playerName= inputPlayer;
        Debug.Log(MenuUI.Instance.playerName);
    }


    private void StartGame(){
        SceneManager.LoadScene(1);
    }
}
