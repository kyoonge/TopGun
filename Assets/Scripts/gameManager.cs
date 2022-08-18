using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public Text scoreText, myrank;
    public Text[] rank = new Text[5];
    public int score = 0;
    private int[] bestScore = new int[5];
    private string[] bestName = new string[5];
    public GameObject rankPrint;
    public Button MenuBtn;

    void Awake()
    {
        Time.timeScale = 1;
        if (!instance)
            instance = this;
        scoreText.text = score.ToString();
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
        //Debug.Log(score);
    }

    public void Ranking()
    {

    }

    public void GameOver()
    {
        string name = PlayerPrefs.GetString("CurrentPlayerName");
        myrank.text = name + " " + score;

        Button MenuB = MenuBtn.GetComponent<Button>();
        MenuB.onClick.AddListener(MenuBtnClick);

        Time.timeScale = 0;
        //랭킹호출
        //Debug.Log("호출할이름: " + name);
        ScoreSet(score, name);
        rankPrint.SetActive(true);
    }

    //랭킹계산
    void ScoreSet(int currentScore, string currentName)
    {
        //Debug.Log("currentName: " + currentName);
        //일단 현재에 저장하고 시작
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);
        //Debug.Log("계산"+ PlayerPrefs.GetInt("CurrentPlayerScore").ToString());

        int tmpScore = 0;
        string tmpName = "";

        for (int i = 0; i < 5; i++)
        {
            //저장된 최고점수와 이름을 가져오기
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");
            //Debug.Log("[랭킹출력] 이름: " + bestName[i]+ "점수: " + bestScore[i]);

            //현재 점수가 랭킹에 오를 수 있을 때
            while (bestScore[i] < currentScore)
            {
                //자리바꾸기!
                tmpScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                //랭킹에 저장
                PlayerPrefs.SetInt(i + "BestScore", currentScore);
                //PlayerPrefs.SetString(i.ToString() + "BestName", currentName);
                PlayerPrefs.SetString(i + "BestName", currentName);

                //다음 반복을 위한 준비
                currentScore = tmpScore;
                currentName = tmpName;
            }
        }
        //랭킹에 맞춰 점수와 이름 저장과 출력
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i + "BestName", bestName[i]);
            //PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
            Debug.Log("[랭킹] "+ PlayerPrefs.GetString(i + "BestName") + PlayerPrefs.GetInt(i+"BestScore"));
            rank[i].text = bestName[i] + " " + bestScore[i].ToString();
        }
    }

    void MenuBtnClick()
    {
        Debug.Log("You have clicked the menubutton!");
        SceneManager.LoadScene("Menu");
    }





}
