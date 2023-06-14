using UnityEngine;
using UnityEngine.SceneManagement;
public enum MenuName
{
    Main,
    GamePlay,
}
public class MenuManager : MonoBehaviour
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {

            case MenuName.Main:

                // go to MainMenu scene
                SceneManager.LoadScene("MenuScene");
                break;

            case MenuName.GamePlay:
                SceneManager.LoadScene("FileExScene");
                break;
        }

    }
}
