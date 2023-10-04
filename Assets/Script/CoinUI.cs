using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    ResourceSO resource;

    private void Awake()
    {
        
    }
    //lấy sprite từ ResourceSO
    private void Start()
    {
        resource = CoinManager.Instance.GetResourceSO();
        transform.Find("Image").gameObject.GetComponent<Image>().sprite = resource.sprite;
        CoinManager.Instance.OnChangeCoin += Instance_OnChangeCoin;
        UpdateCoin();
    }

    private void Instance_OnChangeCoin(object sender, System.EventArgs e)
    {
        UpdateCoin();
    }

    //lấy số coin thu thập được từ dictionary trong CoinManager --> getCoin() in CoinManager
    private void Update()
    {

        
    }
    public void UpdateCoin()
    {
        TMP_Text text = transform.Find("Text").gameObject.GetComponent<TMP_Text>();
        string number = CoinManager.Instance.getCoin(resource).ToString();
        text.text = number;
    }

}
