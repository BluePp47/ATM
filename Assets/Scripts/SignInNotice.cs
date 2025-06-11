using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System;

public class SignInNotice : MonoBehaviour
{
    public GameManager GameManager;
    public UserInfoData UserInfo;


    public TMP_InputField ID;
    public TMP_InputField Name;
    public TMP_InputField PassWord;
    public TMP_InputField PassWordConfirm;

    public GameObject SignInNoticeUI;//로그인창 알림
    public GameObject MiniNotice;
    public GameObject PopUpSignUPUI;

    public TMP_Text MiniNoticeText;
    public TMP_Text SignInNoticeText;

    public void SignUp()
    {
        if (IsEmpty()== false)
        {
            UserInfoData userInfoData = new UserInfoData(Name.text,50000,50000,ID.text,PassWord.text);

            GameManager.Instance.addUser(userInfoData);
            PopUpSignUPUI.SetActive(false);
        }
    }

    public bool IsEmpty()//공란체크
    {

        if (string.IsNullOrEmpty(ID.text))
        {
            IDEmpty();
            SignInNoticeUI.SetActive(true);
            MiniNotice.SetActive(true);
            return true;
        }
        if (Name.text == "")
        {
            NameEmpty();
            SignInNoticeUI.SetActive(true);
            MiniNotice.SetActive(true);
            return true;
        }
        if (PassWord.text == "")
        {
            PasswordEmpty();
            SignInNoticeUI.SetActive(true);
            MiniNotice.SetActive(true);
            return true;
        }
        if (PassWordConfirm.text == "")
        {
            PassConfirmEmpty();
            SignInNoticeUI.SetActive(true);
            MiniNotice.SetActive(true);
            return true;
        }
        if(PassWord.text != PassWordConfirm.text)
        {
            DefferPassKey();
            SignInNoticeUI.SetActive(true);
            MiniNotice.SetActive(true);
            return true;
        }
        // GameManager.Instance.userDatas.list.Find((user) => ID.text == user.iD);// 리스트 안에있는 항목을 찾음
        // UserInfoData data = GameManager.Instance.userDatas.list.Find((user) => ID.text == user.iD);
        // Debug.Log(data);
        bool IsUser = GameManager.Instance.userDatas.list.Exists((user) => ID.text == user.iD);
        Debug.Log(IsUser);

        if (GameManager.Instance.userDatas.list.Exists((user) => ID.text == user.iD))
        {
            ExistedID();
            SignInNoticeUI.SetActive(true);
            MiniNotice.SetActive(true);
            return true;
        }
        return false;
    }

    // 아이디가 같은게 있는지 확인

    //C# 리스트에서 값찾기
    public void IDEmpty()
    {
        MiniNoticeText.text = $"{"아이디가 빈칸입니다"}";
        SignInNoticeText.text = $"{"아이디가 빈칸입니다"}";
    }
    public void NameEmpty()
    {
        MiniNoticeText.text = $"{"이름이 빈칸입니다"}";
        SignInNoticeText.text = $"{"이름이 빈칸입니다"}";
    }
    public void PasswordEmpty()
    {
        MiniNoticeText.text = $"{"비밀번호가 빈칸입니다"}";
        SignInNoticeText.text = $"{"비밀번호가 빈칸입니다"}";
    }
    public void PassConfirmEmpty()
    {
        MiniNoticeText.text = $"{"비밀번호 재입력이 빈칸입니다"}";
        SignInNoticeText.text = $"{"비밀번호 재입력이 빈칸입니다"}";
    }
    public void DefferPassKey()
    {

        MiniNoticeText.text = $"{"비밀번호와 비밀번호 확인이 서로 다릅니다"}";
        SignInNoticeText.text = $"{"비밀번호와 비밀번호 확인이 서로 다릅니다"}";
    }
    public void ExistedID()
    {
        MiniNoticeText.text = $"{"이미 존재하는 아이디입니다"}";
        SignInNoticeText.text = $"{"이미 존재하는 아이디입니다"}";
    }
}
// 매개변수로 받아서 메세지만 가져오기