using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // 실행할 게임 방식 코드 넘버
    private int gameCode = 0;


    [SerializeField]
    private int decimalMin = 0;
    [SerializeField]
    private int decimalMax = 31;
    
    public int DeciamlMax {get => decimalMax; set => decimalMax = value;}
    public int DecimalMin {get => decimalMin; set => decimalMin = value;}

    public int GameCode {get => gameCode;}


    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }else{
            Destroy(this);
        }
    }

    public void GameCodeNumberSetting(int index){
        gameCode = index;
    }

    public void GameStart(){
        SceneManager.LoadScene("01.InGame");
    }

}
