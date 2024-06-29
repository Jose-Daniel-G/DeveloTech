using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;

public class UnityLoginLogutRegister : MonoBehaviour
{
    [Space]
    public string baseUrl = "http://localhost/www/UnityLoginLogoutRegister/";

    [Header("Crear Cuenta")]
    [Space]
    public InputField username;
    public InputField password;
    public InputField confirmPassword;
    public Text info;

    [Header("Login")]
    [Space]
    public InputField usernameLog;
    public InputField passwordLog;
    // public Text infoLog;

    private string currentUsername;
    private string ukey = "accountUsername";

    void Start()
    {
        currentUsername = "";

        if (PlayerPrefs.HasKey(ukey))
        {
            if (PlayerPrefs.GetString(ukey) != "")
            {
                currentUsername = PlayerPrefs.GetString(ukey);
                // info.text = "Has iniciado sesión = " + currentUsername;
            }else{
                info.text = "No has iniciado sesión. ";
            }
                // info.text = "No has iniciado sesión. ";
        }
    }

    public void AccountRegister()
    {
        string user = username.text;
        string pass = password.text;
        string confirmPass = confirmPassword.text;
        StartCoroutine(RegisterNewAccount(user, pass));
    }

    public void AccountLogin()
    {
        string user = usernameLog.text;
        string pass = passwordLog.text;
        StartCoroutine(LoginAccount(user, pass));
    }

    public void AccountLogout(){
        currentUsername = "";
        PlayerPrefs.SetString(ukey, currentUsername);
        info.text = "Has cerrado sesión. ";
    }

    IEnumerator RegisterNewAccount(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Response = " + responseText);
                info.text = "Response = " + responseText;
            }
        }
    }

    IEnumerator LoginAccount(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", username);
        form.AddField("loginPassword", password);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                if (responseText == "1")
                {
                    PlayerPrefs.SetString(ukey, username);
                    info.text = "Inicio de sesión exitoso del usuario " + username;
                    SceneManager.LoadSceneAsync("MainMenu");
                }
                else
                {
                    info.text = "Inicio de sesión fallido " + username;
                    // PlayerPrefs.SetString("accountUsername", "");
                }
                // Debug.Log("Response = " + responseText);
                // info.text = "Response = " + responseText;

            }
        }
    }
}
