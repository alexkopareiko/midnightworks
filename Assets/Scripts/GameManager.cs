using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] 
    private GameObject player;

    private StarterAssetsInputs starterAssetsInputs;

    private int enemiesCount = 0;


    private void Start()
    {
        starterAssetsInputs = player.GetComponent<StarterAssetsInputs>();
        enemiesCount = GameObject.FindObjectsOfType<Enemy>().Length;

        starterAssetsInputs.SetCursorState(true);

    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void MinusEnemy()
    {
        enemiesCount--;
        if(enemiesCount <= 0)
        {
            Win();
        }
    }

    private void Win()
    {
        UIManager.instance.ShowWinScreen();
        starterAssetsInputs.SetCursorState(false);
        Helpers.AddPPWinCount();
    }

    public void Die()
    {
        UIManager.instance.ShowLoseScreen();
        Helpers.AddPPLoseCount();
        starterAssetsInputs.SetCursorState(false);
    }
}
