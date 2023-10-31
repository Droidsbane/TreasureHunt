using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject coin = null;

    private List<GameObject> coins;
    public List<GameObject> Coins => coins;
    private int amountCoins;

    private void Start()
    {
        coins = new List<GameObject>();
        amountCoins = 20;

        for (int i = 0; i < amountCoins; i++)
        {
            coins.Add(Instantiate(coin, transform));
            coins[i].SetActive(false);
        }
    }

    public GameObject GetCoin()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            if (!coins[i].activeInHierarchy)
            {
                return coins[i];
            }
        }
        return null;
    }
}
