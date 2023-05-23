using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public static bool AILose;
    public float playerhpValue, enemyhpValueMax, enemyhpValueCurrent;
    public Image PlayerHP, EnemyHP;
    public Animator animLoseAI;
    public GameObject winScreen;
    public float winScreenDelay = 2f; // Kazanma ekran�n�n g�r�nt�lenme gecikmesi s�resi

    private void Start()
    {
        AILose = false;
        EnemyHP.fillAmount = enemyhpValueMax;
        enemyhpValueCurrent = enemyhpValueMax;
    }

    private void Update()
    {
        EnemyHP.fillAmount = enemyhpValueCurrent / enemyhpValueMax;

        if (enemyhpValueCurrent <= 0f)
        {
            animLoseAI.SetTrigger("AILose");
            AILose = true;
            Invoke("ShowWinScreen", winScreenDelay);
        }
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
}
