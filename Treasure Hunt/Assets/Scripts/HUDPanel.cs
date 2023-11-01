using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPanel : MonoBehaviour
{
    [SerializeField] private Image panelImage = null;
    [SerializeField] private GameObject ScoreText = null;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Actions.StartGame += ShowHUD;
    }
    private void OnDisable()
    {
        Actions.StartGame -= ShowHUD;
    }
    private void Start()
    {
        panelImage.enabled = false;
        ScoreText.SetActive(false);
    }
    private void ShowHUD()
    {
        panelImage.enabled = true;
        ScoreText.SetActive(true);
    }
}
