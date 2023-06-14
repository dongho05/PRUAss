using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    GameObject prefabCircle;


    // Start is called before the first frame update
    public void HandlePlayButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.GamePlay);
    }
    public void HandleMainMenuButtonOnClickEvent()
    {

        SceneManager.LoadScene("MenuScene");
    }

}
