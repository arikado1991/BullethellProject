using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopBarUIPanelController : UIPanelController
{
    [SerializeField] TextMeshProUGUI mScoreText;
    [SerializeField] TextMeshProUGUI mHealthText;
    // Start is called before the first frame update
    void Start()
    {
        UIStackController.onLoadUIPanelRequestEvent.Invoke (this);
    }

    void OnEnable ()
    {
        GameEvaluator.onPlayerScoreChangeEvent.AddListener(OnPlayerScoreChangeEventHandler);
        PlayerShipStat.onPlayerHealthChangeEvent.AddListener(OnPlayerHealthChangeEventHandler);
    }

    void OnDisable()
    {
        GameEvaluator.onPlayerScoreChangeEvent.RemoveListener(OnPlayerScoreChangeEventHandler);
        PlayerShipStat.onPlayerHealthChangeEvent.RemoveListener(OnPlayerHealthChangeEventHandler);
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
