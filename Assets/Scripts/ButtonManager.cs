using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button StartBtn;
    public Button ExitBtn;
    public InputField playerNameInput;
    private string playerName = null;

    

    // Start is called before the first frame update
    void Start()
    {
        Button StartB = StartBtn.GetComponent<Button>();
        StartB.onClick.AddListener(StartBtnClick);

        Button ExitB = ExitBtn.GetComponent<Button>();
        ExitB.onClick.AddListener(ExitBtnClick);

        playerName = playerNameInput.GetComponent<InputField>().text;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartBtnClick()
    {
        Debug.Log("You have clicked the sbutton!");
        InputName();
        Debug.Log("등록한이름: "+PlayerPrefs.GetString("CurrentPlayerName"));
        SceneManager.LoadScene("Start");
    }

    void ExitBtnClick()
    {
        Debug.Log("You have clicked the ebutton!");
        //UnityEditor.EditorApplication.isPlaying=false;  
        Application.Quit();
    }

    //클릭하면
    public void InputName()
    {

        playerName = playerNameInput.text;
        if(playerName == "")
        {
            playerName = "NoName";
        }

        PlayerPrefs.SetString("CurrentPlayerName", playerName);
        PlayerPrefs.Save();
        //GameManager.instance.ScoreSet(GameManager.instance.score, playerName);
    }

}
