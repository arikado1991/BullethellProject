using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameMainController : MonoBehaviour
{
    [SerializeField] EndgamePopupUIPanelController endGamePopupPanel;
    void OnEnable()
    {
        GameEvaluator.onGameEndEvent.AddListener (OnGameEndEventHandler);
        PlayerShipStat.onPlayerDestroyedEvent.AddListener (OnPlayerDestroyedEventHandler);
        GameEvaluator.onNormalScoreEvent.AddListener(OnNormalScoreEventHandler);
        GameEvaluator.onNewHighscoreEvent.AddListener(OnNewHighscoreEventHandler);
        GameEvaluator.onLevelClearEvent.AddListener(OnLevelClearEventHandler);
    }

    void OnGameEndEventHandler() 
    {
        UIStackController.onLoadUIPanelRequestEvent.Invoke(endGamePopupPanel);
    }

    public void OnNewHighscoreEventHandler(int newHighscore, int prevHighscore)
    {
        endGamePopupPanel.content.text = string.Format("New highscore {0}\n Previous {1}", newHighscore, prevHighscore);
    }

    public void OnNormalScoreEventHandler (int currentScore, int prevHighscore)
    {
        endGamePopupPanel.content.text = string.Format("Highscore {1}\nYour score {0}", currentScore, prevHighscore);
      
    }

    private void OnPlayerDestroyedEventHandler(PlayerShipStat player) 
    {
        endGamePopupPanel.title.text = "Game Over";
    }

    void OnLevelClearEventHandler()
    {
        endGamePopupPanel.title.text = "Cleared";
    }
}
