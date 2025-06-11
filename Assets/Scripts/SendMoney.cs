using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System;
using System.Linq;

public class SendMoney : MonoBehaviour
{
    public GameManager GameManager;
    public UserInfoData UserInfo;
    private UIManager UIManager;

    public TMP_InputField Name;
    public TMP_Text Balance;

    public GameObject SignInNoticeUI;

    public TMP_Text SignInNoticeText;

    private UserInfoData userInfoData;
    public void SendingMoney()
    {
        if (EmptyCheck() == false)
        {
            foreach (var data in GameManager.Instance.userDatas.list)//로그인한 사람 데이터 불러오기
            {
                if (data.userName == Name.text)
                {
                    userInfoData = data;
                    break;
                }
            }
            Debug.Log(Balance.text);

            if (GameManager.Instance.userData.Balance >= int.Parse(Balance.text))
            {
                userInfoData.Balance += int.Parse(Balance.text);

                GameManager.Instance.userData.Balance -= int.Parse(Balance.text);
                UIManager.Refresh();

                GameManager.Instance.SaveUserData();
            }
            else
            {
                NotEnoughBalance();
                SignInNoticeUI.SetActive(true);
            }

        }
    }
    public bool EmptyCheck()
    {

        if (string.IsNullOrEmpty(Name.text) || string.IsNullOrEmpty(Balance.text))//공란
        {
            AllEmpty();
            SignInNoticeUI.SetActive(true);
            return true;
        }
        if (string.IsNullOrEmpty(Name.text) && string.IsNullOrEmpty(Balance.text))//공란
        {
            AllEmpty();
            SignInNoticeUI.SetActive(true);
            return true;
        }

        return false;
    }
    public void AllEmpty()
    {
        SignInNoticeText.text = $"{"입력정보를 확인해주세요"}";
    }
    public void NotEnoughBalance()
    {
        SignInNoticeText.text = $"{"잔액이 부족합니다"}";
    }
    public void NotTargetExsist()
    {
        SignInNoticeText.text = $"{" 존재하지 않는 대상입니다"}";
    }
  
}
