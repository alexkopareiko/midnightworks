using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class UIManager : MonoBehaviour
{

    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField]
    private Image playerHealthBar;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;
    [SerializeField]
    private Button okWinButton;
    [SerializeField]
    private Button okLoseButton;


    private void Start()
    {
        okWinButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
        okLoseButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
    }

    public void SetPlayerHealthBar(float fillAmount)
    {
        playerHealthBar.fillAmount = fillAmount;
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);

    }
    
    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
