using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    public int time;
    public float speed;
    public int item;

    public Text counterStarsText;
    public Text timeText;
    public Image timeImage;

    public Text pausetext;
    public Text gameOverText;

    public Button pausedButton;

    string starsNumber = "20";

    bool paused = false;

    public GameObject panel;

    public GameObject mainMenu;
    public GameObject loginMenu;
    public GameObject UpdateMenu;
    public GameObject createMenu;

    public InputField userNameLogin;
    public InputField passwordLogin;
    public Button startLogin;
    public Button updateLogin;
    public Text errorLogin;

    public InputField userNameCreate;
    public InputField passwordCreate;
    public InputField speedCreate;
    public InputField TimeCreate;
    public InputField ItemCreate;
    public Text ErrorCreate;

    public InputField userNameUpdate;
    public InputField speedUpdate;
    public InputField TimeUpdate;
    public InputField ItemUpdate;
    public InputField ScoreUpdate;

    private int ID;

    public Text ErrorUpdate;

    [Serializable]
    public class User
    {
        public int ID;
        public string UserName;
        public string Password;
        public float Speed;
        public int Time;
        public int Item;
        public int Score;
  
    }

    // Use this for initialization
    void Start () {
        timeText.text = time.ToString();
        StartCoroutine(UpdateTime());
        initializeMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void initializeMenu()
    {
        Time.timeScale = 0;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void CounterStars()
    {
        counterStarsText.text = (Int32.Parse(counterStarsText.text) + item).ToString();
        if (counterStarsText.text == starsNumber) 
            GameOver(false);
    }

    IEnumerator UpdateTime()
    {
        while (Int32.Parse(timeText.text) > 0)
        {
            yield return new WaitForSeconds(1f);

            timeText.text = (Int32.Parse(timeText.text) - 1).ToString();

            if (timeText.text == "10")
                ChangeImagenColor(timeImage, Color.red);
            if (timeText.text == "9")
                timeText.transform.Translate(new Vector3(7.5f, 0, 0));
            if (timeText.text == "0")
                GameOver(true);
        }        
    }
    
    void ChangeImagenColor(Image image, Color color)
    {
        image.GetComponent<Image>().color = color;
    }

    public void PauseButton()
    {
        if (paused)
        {
            Time.timeScale = 1;
            pausetext.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pausetext.gameObject.SetActive(true);
        }
        paused = !paused;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        pausedButton.interactable = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(bool timeOut)
    {
        Time.timeScale = 0;
        pausedButton.interactable = false;
        if (timeOut)
            gameOverText.gameObject.SetActive(true);
        else
        {
            gameOverText.text = "YOU WIN!";
            gameOverText.gameObject.SetActive(true);
        }            
    }
    public void startGame(float speed, int time, int item)
    {
        loginMenu.SetActive(false);
        UpdateMenu.SetActive(false);
        createMenu.SetActive(false);
        panel.SetActive(false);

        Time.timeScale = 1;

        this.speed = speed;
        timeText.text = time.ToString();
        this.item = item;

        
    }
    public void LoginMenu()
    {
        mainMenu.SetActive(false);
        loginMenu.SetActive(true);
    }

    public void StartLogin()
    {
        string url = "http://127.0.0.1/services/getUser.php?userName="+userNameLogin.text+"&password="+passwordLogin.text;
        StartCoroutine(getUserLoginJsonObject(url));

    }

    private IEnumerator getUserLoginJsonObject(string url)
    {
        WWW www = new WWW(url);
        yield return www;

        string json = www.text.Trim();
        json = json.TrimStart('[');
        json = json.Remove(json.Length - 1);
    
        User user;
        Debug.Log(json);
        user = JsonUtility.FromJson<User>(json);
        Debug.Log("postjson" + user.Speed);
        Debug.Log(user.Speed);
        try
        {
            if (errorLogin.IsActive())
                errorLogin.gameObject.SetActive(false);
            startGame(user.Speed, user.Time, user.Item);
        }
        catch
        {
            errorLogin.gameObject.SetActive(true);
        }

    }

    public void UpdateLogin()
    {
        string url = "http://127.0.0.1/services/getUser.php?userName=" + userNameLogin.text + "&password=" + passwordLogin.text;
        StartCoroutine(getUserLoginJsonObjectToUpdate(url));
    }

    private IEnumerator getUserLoginJsonObjectToUpdate(string url)
    {
        WWW www = new WWW(url);
        yield return www;

        string json = www.text.Trim();
        json = json.TrimStart('[');
        json = json.Remove(json.Length - 1);

        User user;
        user = JsonUtility.FromJson<User>(json);
        try
        {
            if (errorLogin.IsActive())
                errorLogin.gameObject.SetActive(false);
            UpdateAccountMenu(user);
        }
        catch
        {
            errorLogin.gameObject.SetActive(true);
        }

    }

    public void UpdateAccountMenu(User user)
    {
        UpdateMenu.SetActive(true);
        loginMenu.SetActive(false);
        userNameUpdate.text = user.UserName;
        speedUpdate.text = user.Speed.ToString();
        TimeUpdate.text = user.Time.ToString();
        ScoreUpdate.text = user.Score.ToString();
        ItemUpdate.text = user.Item.ToString();

        ID = user.ID;

    }
    public void createAccount()
    {
        mainMenu.SetActive(false);
        UpdateMenu.SetActive(false);
        createMenu.SetActive(true);
        loginMenu.SetActive(false);
    }

    public void createAccountButton()
    {
        if(userNameCreate.text.Length != 0 && passwordCreate.text.Length != 0 && speedCreate.text.Length != 0 && TimeCreate.text.Length != 0 && ItemCreate.text.Length != 0)
        {
            if (ErrorCreate.IsActive())
                ErrorCreate.gameObject.SetActive(false);
            string url = "http://127.0.0.1/services/createUserAccount.php?UserName=" + userNameCreate.text + "&Password=" + passwordCreate.text + "&speed=" + speedCreate.text + "&Time=" + TimeCreate.text + "&Item=" + ItemCreate.text;
            StartCoroutine(createAccount(url));
        }
        else
        {
            ErrorCreate.gameObject.SetActive(true);
        }
    }
    private IEnumerator createAccount(string url)
    {
        Debug.Log(url);
        WWW www = new WWW(url);
        yield return www;

        if(www.text.Trim() == "Cuenta creada correctamente")
        {
            loginMenu.SetActive(true);
            createMenu.SetActive(false);
        }
        else
        {
            ErrorCreate.text = "Error con creación de cuenta";
            ErrorCreate.gameObject.SetActive(true);
        }

    }

    public void updateAccountButton()
    {
        if (userNameUpdate.text.Length != 0 && speedUpdate.text.Length != 0 && TimeUpdate.text.Length != 0 && ItemUpdate.text.Length != 0)
        {
            if (ErrorCreate.IsActive())
                ErrorCreate.gameObject.SetActive(false);
            string url = "http://127.0.0.1/services/updateUser.php?ID=" + ID + "&UserName=" + userNameUpdate.text + "&speed=" + speedUpdate.text + "&Time=" + TimeUpdate.text + "&Item=" + ItemUpdate.text;
            StartCoroutine(UpdateAccountDB(url));
        }
        else
        {
            ErrorCreate.gameObject.SetActive(true);
        }

    }
    private IEnumerator UpdateAccountDB(string url)
    {
        WWW www = new WWW(url);
        yield return www;

        loginMenu.SetActive(true);
        UpdateMenu.SetActive(false);

    }
}
