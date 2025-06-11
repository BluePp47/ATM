using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI Cash;
    public TextMeshProUGUI Balance;
    
    public TMP_InputField ID; 
    public TMP_InputField PassWord;


    public void Refresh()
    {
        //로그인한 유저데이터를 유저데이터에 넣어주기
        userName.text = GameManager.Instance.userData.userName;
        Balance.text  = GameManager.Instance.userData.Balance.ToString();
        Cash.text     = GameManager.Instance.userData.Cash.ToString(); // "N0"는  돈단위처럼끊어서 표시해줌

        ID.text = GameManager.Instance.userData.iD;
        PassWord.text = GameManager.Instance.userData.Password;

        //userdata 넣어주기
    }
}
