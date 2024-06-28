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
    public Text infoLog;

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
                Debug.Log("Response = " + responseText);
                info.text = "Response = " + responseText;
                
            }
        }
    }
}
