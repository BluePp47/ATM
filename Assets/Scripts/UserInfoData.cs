using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class UserInfoData
{
    public string userName;
    public int  Cash;
    public int  Balance;
    public string iD;
    public string Password;

    public UserInfoData(string UserName, int Cash, int Balance, string ID,string Pw) 
    {
       userName = UserName;
       this.Cash = Cash;
       this.Balance = Balance;
       this.iD = ID; 
       this.Password = Pw; 
    }
}

[System.Serializable]
public class UserDatas
{
    public List<UserInfoData> list = new List<UserInfoData>();
}


