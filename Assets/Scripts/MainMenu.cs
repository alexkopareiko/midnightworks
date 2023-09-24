using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button startBtn;
    [SerializeField]
    private Button exitBtn;
    [SerializeField]
    private TMP_Text winCountText;
    [SerializeField]
    private TMP_Text loseCountText;

    private void Start()
    {
        winCountText.text = Helpers.GetPPWinCount().ToString();
        loseCountText.text = Helpers.GetPPLoseCount().ToString();

        startBtn.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        exitBtn.onClick.AddListener(() => Application.Quit());

    }
}
