using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
public class InGameDisplayText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mHealthText;
    [SerializeField] TextMeshProUGUI mScoreText;
    [SerializeField] TextMeshProUGUI mGameOverText;
    [SerializeField] TextMeshProUGUI mWaveClearedText;
    [SerializeField] TextMeshProUGUI mHighscoreText;

    // Start is called before the first frame update
    void OnEnable()
    {
       
       // PlayerShipStat.onPlayerDestroyedEvent.AddListener (OnPlayerDestroyedEventHandler);
        //PlayerShipStat.onPlayerHealthChangeEvent.AddListener (OnPlayerHealthChangeEventHandler);
        //GameEvaluator.onPlayerScoreChangeEvent.AddListener (OnPlayerScoreChangeEventHandler);
        //GameEvaluator.onLevelClearEvent.AddListener(OnPlayerClearWave);
       // GameEvaluator.onNewHighscoreEvent.AddListener(OnNewHighscoreEventHandler);
     //   GameEvaluator.onNormalScoreEvent.AddListener(OnNormalScoreEventHandler);
    }
    void OnDisable()
    {
        //PlayerShipStat.onPlayerDestroyedEvent.RemoveListener(OnPlayerDestroyedEventHandler);
      //  PlayerShipStat.onPlayerHealthChangeEvent.RemoveListener(OnPlayerHealthChangeEventHandler);
      //  GameEvaluator.onPlayerScoreChangeEvent.RemoveListener(OnPlayerScoreChangeEventHandler);
       // GameEvaluator.onLevelClearEvent.RemoveListener(OnPlayerClearWave);
       // GameEvaluator.onNewHighscoreEvent.RemoveListener(OnNewHighscoreEventHandler);
       // GameEvaluator.onNormalScoreEvent.RemoveListener(OnNormalScoreEventHandler);
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
    public void OnPlayerClearWave()
    {
        mWaveClearedText.gameObject.SetActive(true);
    }

    public void OnNewHighscoreEventHandler(int newHighscore, int prevHighscore)
    {
        mHighscoreText.text = string.Format("New highscore {0}\n Previous {1}", newHighscore, prevHighscore);
        mHighscoreText.gameObject.SetActive(true);
    }

    public void OnNormalScoreEventHandler (int currentScore, int prevHighscore)
    {
        mHighscoreText.text = string.Format("Highscore {1}\nYour score {0}", currentScore, prevHighscore);
        mHighscoreText.gameObject.SetActive(true);
    }
}
