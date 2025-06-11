using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UserInfoData UserInfoData;

    string path;
    public static GameManager Instance;
    public UserInfoData userData;
    public UIManager uiManager;


    public TMP_InputField SaveEdit;
    public TMP_InputField TakeoutEdit;

    public GameObject NoticeUI;
    public TextMeshProUGUI NoticeText;

    public UserDatas userDatas;

    public void addUser(UserInfoData user)
    {
        userDatas.list.Add(user);
        string json = JsonUtility.ToJson(userDatas, true);
        string path = Path.Combine(Application.dataPath + "/UserData/", "Userdatas.json");
        File.WriteAllText(path, json);

    }
    public void LoginAcc(UserInfoData uData)
    {
        userData = uData;
        uiManager.Refresh();
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //Debug.Log(userData.userName);
        //userData = new UserInfoData(userData.userName, userData.Cash, userData.Balance); //틀만들고 정보를 불러옴
    }

    public void Start()
    {
        
        //path = Path.Combine(Application.dataPath + "/UserData/", "Userdatas.json");       //파일을 하나 만들어서 그이름 대로 적으면 그 파일에 데이터 저장
        //Debug.Log(path);
        //LoadUserData();

        LoadAllUserDatas();
        //uiManager.Refresh();
    }

    public void LoadAllUserDatas()
    {
        string userdatasPath = Path.Combine(Application.dataPath + "/UserData/", "Userdatas.json");

        string loadJson = File.ReadAllText(userdatasPath);
        userDatas = JsonUtility.FromJson<UserDatas>(loadJson);
    }


    public void CustomIN()
    {
        int.TryParse(SaveEdit.text, out int Value);
        if (userData.Cash < Value)
        {
            NoticeUI.SetActive(true);
        }
        else
        {
            userData.Balance += Value;
            userData.Cash -= Value;
            uiManager.Refresh();
        }
    }
    public void CustomOut()//수동 입력
    {
        int.TryParse(SaveEdit.text, out int Value);
        if (userData.Balance < Value)
        {
            NoticeUI.SetActive(true);
        }
        else
        {
            userData.Cash += Value;
            userData.Balance -= Value;
            uiManager.Refresh();
        }
    }

    public void In(int Amount)//입금
    {
        Debug.Log("Amount" + Amount);
        if (userData.Cash < Amount)
        {
            NoticeUI.SetActive(true);
        }
        else
        {
            userData.Balance += Amount;
            userData.Cash -= Amount;
            uiManager.Refresh();
            SaveUserData();
        }
    }

    public void Out(int Amount)//출금
    {
        Debug.Log("Amount" + Amount);
        if (userData.Balance < Amount)
        {
            NoticeUI.SetActive(true);
        }
        else
        {
            userData.Cash += Amount;
            userData.Balance -= Amount;
            uiManager.Refresh();
            SaveUserData();
        }
    }

    public void SaveUserData()//데이터 저장
    {


        //UserInfoData.userName = userData.userName.ToString();
        //UserInfoData.Balance = userData.Balance;
        //UserInfoData.Cash = userData.Cash;
        //UserInfoData.iD = userData.iD;
        //UserInfoData.Password = userData.Password;


        //string json = JsonUtility.ToJson(UserInfoData, true);

        //File.WriteAllText(path, json);
        //UserInfoData userInfoData = userDatas.list.Find((user) => "s" == user.iD);
        //Debug.Log(userInfoData.Cash);
        path = Path.Combine(Application.dataPath + "/UserData/", "Userdatas.json");
        string json = JsonUtility.ToJson(userDatas, true);

        File.WriteAllText(path, json);

    }


    //public void LoadUserData()//데이터 불러오기
    //{
    //    string loadJson = File.ReadAllText(path);
    //    UserInfoData = JsonUtility.FromJson<UserInfoData>(loadJson);

    //    GameManager.Instance.userData.userName = UserInfoData.userName;
    //    GameManager.Instance.userData.Cash = UserInfoData.Cash;
    //    GameManager.Instance.userData.Balance = UserInfoData.Balance;

    //    GameManager.Instance.userData.iD = UserInfoData.iD;
    //    GameManager.Instance.userData.Password = UserInfoData.Password;

    //    Debug.Log($"저장{UserInfoData.userName},{UserInfoData.Cash}, {UserInfoData.Balance}");
    //}

}

