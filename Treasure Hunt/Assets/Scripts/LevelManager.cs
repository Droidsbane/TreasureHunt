using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager = null;
    [SerializeField] private Transform[] coinSpawns = null;
    [SerializeField] private PlayerController player = null;
    [SerializeField] private Transform playerSpawn = null;

    private float timer;
    private const float RESET_TIME = 3;
    private bool startGame;


    private void OnEnable()
    {
        Actions.StartGame += StartLevel;
    }

    private void OnDisable()
    {
        Actions.StartGame -= StartLevel;
    }

    private void Start()
    {
        startGame = false;
        timer = RESET_TIME;
    }

    private void StartLevel()
    {
        startGame = true;
        Instantiate(player, playerSpawn.position, playerSpawn.rotation);
    }

    private void Update()
    {
        if (!startGame) { return; }
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            var coin = coinManager.GetCoin();
            if (coin != null)
            {
                var rand = Random.Range(0, coinSpawns.Length);
                coin.transform.position = coinSpawns[rand].position;
                coin.transform.rotation = coinSpawns[0].rotation;
                var temp = new List<GameObject>();

                for (int i = 0; i < coinManager.Coins.Count; i++)
                {
                    if (coinManager.Coins[i].activeInHierarchy)
                    {
                        temp.Add(coinManager.Coins[i]);
                    }
                }
                coin.SetActive(true);

                for (int i = 0; i < temp.Count; i++)
                {
                    if (coin.transform.position == temp[i].transform.position)
                    {
                        coin.SetActive(false);
                    }
                }
            }
            timer = RESET_TIME;
        }
    }
}
