using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour
{
    public GameObject   noticeUI;
    public class Deposit
    {
        public int dipOne = 10000;
        public int dipTwo = 30000;
        public int dipThree = 50000;
    }
    public class SelfSave
    {
        public UserInfoData UserInfo;
    }

    public class Notice
    {
        public UserInfoData Balance;
        public UserInfoData Cash;
        private GameObject noticeUI;

        public Deposit Deposit;
        public void Not_EnoughSave()
        {
            if (Cash.Cash < Deposit.dipOne)
            {
                noticeUI.SetActive(true);
            }

            if (Cash.Cash < Deposit.dipTwo)
            {
                noticeUI.SetActive(true);
            }

            if (Cash.Cash < Deposit.dipThree)
            {
                noticeUI.SetActive(true);
            }

        }

        public void Not_EnoughTakeout()
        {
            if (Balance.Balance < Deposit.dipOne)
            {
                noticeUI.SetActive(true);
            }

            if (Balance.Balance < Deposit.dipTwo)
            {
                noticeUI.SetActive(true);
            }

            if (Balance.Balance < Deposit.dipThree)
            {
                noticeUI.SetActive(true);
            }
        }

    }
}
