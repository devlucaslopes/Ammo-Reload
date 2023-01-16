using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TotalBullets;

    Player player;

    public static GameManager Instance;

    void Start()
    {
        Instance = this;
    }

    public void UpdateTotalBullets(int bullets)
    {
        TotalBullets.text = bullets.ToString("00");
    }
}
