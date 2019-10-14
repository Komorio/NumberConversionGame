using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{

    /// <summary>
    /// Code : 0
    ///
    /// 문제가 10진수 정답이 2진수
    /// </summary>

    public void DecimalToBinary(){
        GameManager.instance.GameCodeNumberSetting(0);
        GameManager.instance.GameStart();
    }

    /// <summary>
    /// Code : 1
    ///
    /// 문제가 2진수 정답이 10진수
    /// </summary>


    public void BinaryToDecimal(){
        GameManager.instance.GameCodeNumberSetting(1);
        GameManager.instance.GameStart();
    }
}
