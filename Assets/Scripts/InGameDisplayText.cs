using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
public class InGameDisplayText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mHealthText;
    [SerializeField]  TextMeshProUGUI mScoreText;
    [SerializeField] TextMeshProUGUI mGameOverText;

    [SerializeField] Text mText;

    // Start is called before the first frame update
    void OnEnable()
    {
       
        PlayerShipStat.onPlayerDestroyedEvent.AddListener (OnPlayerDestroyedEventHandler);
        PlayerShipStat.onPlayerHealthChangeEvent.AddListener (OnPlayerHealthChangeEventHandler);
        PlayerShipStat.onPlayerScoreChangeEvent.AddListener (OnPlayerScoreChangeEventHandler);
        mText = gameObject.GetComponent<Text>();
    }
    void OnDisable()
    {
        PlayerShipStat.onPlayerDestroyedEvent.RemoveListener (OnPlayerDestroyedEventHandler);
         PlayerShipStat.onPlayerHealthChangeEvent.RemoveListener (OnPlayerHealthChangeEventHandler);
        PlayerShipStat.onPlayerScoreChangeEvent.RemoveListener (OnPlayerScoreChangeEventHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerDestroyedEventHandler (PlayerShipStat playerStat)
    {
        mGameOverText.gameObject.SetActive(true);
    }

    public void OnPlayerHealthChangeEventHandler (int pPlayerHealth)
    {
        mHealthText.text = string.Format ("Life: {0}", pPlayerHealth.ToString());
    }

    public void OnPlayerScoreChangeEventHandler  (int pScore) 
    {
        mScoreText.text = string.Format("Score: {0}", pScore.ToString());
    }
}
