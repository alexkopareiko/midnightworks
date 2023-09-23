using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
