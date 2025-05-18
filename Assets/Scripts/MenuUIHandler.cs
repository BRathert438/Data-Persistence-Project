using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    [SerializeField]
    public InputField nameInput;

    public void StartNew()
    {

        SessionManager.Instance.playerName = nameInput.text;

        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {

#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();

#else

        Application.Quit();

#endif

    }

}