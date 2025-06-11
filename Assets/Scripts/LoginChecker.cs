using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System;

public class LoginChecker : MonoBehaviour
{
    public GameManager GameManager;
    public UserInfoData UserInfo;
    public GameObject PopUpLogin;

    public TMP_InputField ID;
    public TMP_InputField PassWord;

    public SignInNotice SignInNotice;
    public GameObject SignInNoticeUI;

    public TMP_Text SignInNoticeText;

    //public List<TMP_InputField> checkInputFielder = new List<TMP_InputField>(); 
    //유동적으로 할경우 사용

    public void ChecKLog()//로그인 체크
    {
        bool IsUser = GameManager.Instance.userDatas.list.Exists((user) => ID.text == user.iD);
        //bool IsUserPW = GameManager.Instance.userDatas.list.Exists((userPw) => PassWord.text == userPw.Password);

        if (IsUser)
        {
            UserInfoData userInfoData = GameManager.Instance.userDatas.list.Find((user) => ID.text == user.iD);
            Debug.Log(userInfoData.iD);
            Debug.Log(userInfoData.Password);
            PopUpLogin.SetActive(false);

            GameManager.Instance.LoginAcc(userInfoData);


        }
        else
        {
            NotExistedID();
        }
    }

    public void NotExistedID()
    {
        SignInNoticeUI.SetActive(true);
        SignInNoticeText.text = $"{" 존재하지 않는 아이디입니다"}";
    }
}