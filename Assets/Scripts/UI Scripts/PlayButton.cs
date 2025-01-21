using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private GameObject menuManager;
    [SerializeField] private GameObject levelManager;
    // Start is called before the first frame update
    public void LevelsOpen(){
        menuManager.SetActive(false);
        levelManager.SetActive(true);
    }

    public void MenuOpen(){
        menuManager.SetActive(true);
        levelManager.SetActive(false);
    }
}
