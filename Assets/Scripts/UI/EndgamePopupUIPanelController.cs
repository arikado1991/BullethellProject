using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EndgamePopupUIPanelController : UIPanelController
{
    // Start is called before the first frame update
    [SerializeField] public TextMeshProUGUI title;
    [SerializeField] public TextMeshProUGUI content;

    public void OnMainMenuButtonClick ()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
