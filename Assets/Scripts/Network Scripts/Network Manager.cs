using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using System.Text;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{
    public GameObject accountMenu;
    public GameObject myaccountMenu;
    public GameObject signupMenu;
    public GameObject signinMenu;
    public GameObject mainMenu;
    private static NetworkManager _instance;
    private string serverUrl = "http://localhost:5000";
    public string currentUsername;
    public int currentDungeonDifficulty;

    public static NetworkManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("NetworkManager");
                _instance = obj.AddComponent<NetworkManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public TMP_InputField SignUpUsernameInput;
    public TMP_InputField SignUpPasswordInput;
    public TMP_Text SignUpResultText;
    public TMP_InputField SignInUsernameInput;
    public TMP_InputField SignInPasswordInput;
    public TMP_Text SignInResultText;
    public TMP_Text DeleteResultText;

    public void clearText()
    {
        SignUpUsernameInput.text = "";
        SignUpPasswordInput.text = "";
        SignUpResultText.text = "";
        SignInUsernameInput.text = "";
        SignInPasswordInput.text = "";
        SignInResultText.text = "";
        DeleteResultText.text = "";
    }
    
    // ========== Sign Up ==========
    public void RegisterUser()
    {
        string username = SignUpUsernameInput.text;
        string password = SignUpPasswordInput.text;
        StartCoroutine(SignUp(username, password));
    }

    private IEnumerator SignUp(string username, string password)
    {
        string jsonData = $"{{\"username\":\"{username}\",\"password\":\"{password}\",\"dungeonDifficulty\":1}}";
        using (UnityWebRequest request = new UnityWebRequest(serverUrl + "/api/user/signup", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                currentUsername = username;
                currentDungeonDifficulty = 1;
                SignUpResultText.text = "Signup successful";
                yield return new WaitForSeconds(1);
                mainMenu.SetActive(true);
                signupMenu.SetActive(false);
                clearText();
            }
            else
            {
                SignUpResultText.text = "Signup failed: " + request.downloadHandler.text;
            }
        }
    }

    // ========== Login ==========
    public void LoginUser()
    {
        string username = SignInUsernameInput.text;
        string password = SignInPasswordInput.text;
        StartCoroutine(Login(username, password));
    }

    private IEnumerator Login(string username, string password)
    {
        string jsonData = $"{{\"username\":\"{username}\",\"password\":\"{password}\"}}";
        using (UnityWebRequest request = new UnityWebRequest(serverUrl + "/api/user/login", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                currentUsername = username;
                SignInResultText.text = "Login successful";
                yield return new WaitForSeconds(1);
                mainMenu.SetActive(true);
                signinMenu.SetActive(false);
                clearText();
            }
            else
            {
                SignInResultText.text = "Login failed: " + request.downloadHandler.text;
            }
        }
    }

    // ========== Save Dungeon Difficulty ==========
    public void SaveDungeonDifficulty()
    {
        StartCoroutine(SaveDifficultyRequest());
    }

    private IEnumerator SaveDifficultyRequest()
    {
        string jsonData = $"{{\"username\":\"{currentUsername}\",\"dungeonDifficulty\":{currentDungeonDifficulty}}}";
        using (UnityWebRequest request = new UnityWebRequest(serverUrl + "/api/user/dungeon", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            Debug.Log(request.result == UnityWebRequest.Result.Success
                ? "Dungeon difficulty saved"
                : "Save failed: " + request.downloadHandler.text);
        }
    }

    // ========== Delete User ==========
    public void DeleteUser()
    {
        StartCoroutine(DeleteUserRequest());
    }

    private IEnumerator DeleteUserRequest()
    {
        using (UnityWebRequest request = UnityWebRequest.Delete(serverUrl + "/api/user/" + currentUsername))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                DeleteResultText.text = "User deleted";
                yield return new WaitForSeconds(1);
                Logout();
                clearText();
            }
            else
            {
                DeleteResultText.text = "Delete failed: " + request.downloadHandler.text;
            }
        }
    }

    // ========== Logout ==========
    public void Logout()
    {
        currentUsername = null;
        currentDungeonDifficulty = 0;
        Debug.Log("User logged out");
        myaccountMenu.SetActive(false);
        accountMenu.SetActive(true);
    }
}
