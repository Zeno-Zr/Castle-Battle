using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;

public class FirebaseManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public static FirebaseAuth auth;
    public static FirebaseUser User;
    public static DatabaseReference DBreference;

    //login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    //register variables
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    //User data variables
    [Header("UserData")]
    public TMP_Text usernameDisplayField;
    public TMP_InputField usernameField;
    public TMP_Text scoreField;
    public TMP_InputField scoreInputField;
    public GameObject scoreElement;
    public Transform scoreboardContent;
    public TMP_Text myUID;

    [Header("Friends")]
    public TMP_InputField friendsUIDField;
    public GameObject friendsScreenElements;

    static string CorrectEmail;
    static string CorrectPassword;

    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are available Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });

        if(CorrectEmail != null && CorrectPassword != null)
        {
            StartCoroutine(Login(CorrectEmail, CorrectPassword));
        }
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void ClearLoginRegisterFeilds()
    {
        emailLoginField.text = "";
        passwordLoginField.text = "";
        usernameRegisterField.text = "";
        emailRegisterField.text = "";
        passwordRegisterField.text = "";
        passwordRegisterVerifyField.text = "";
    }

    //Function for the login button
    public void LoginButton()
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
        FindObjectOfType<SFX>().Click();
    }

    //Function for the login button
    public void RegisterButton()
    {
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
        FindObjectOfType<SFX>().Click();
    }

    //Function for the add friends button
    public void AddFriendsButton()
    {
        StartCoroutine(UpdateFriendsList(friendsUIDField.text, true));
        FindObjectOfType<SFX>().Click();
    }

    public void RemoveFriendsButton(string placeholderUID)
    {
        StartCoroutine(UpdateFriendsList(placeholderUID, null));
        FindObjectOfType<SFX>().Click();
    }

    public void SignOutButton()
    {
        auth.SignOut();
        Debug.Log("User signed out");
        SceneManager.LoadScene("LoginRegister");
        CorrectEmail = null;
        CorrectPassword = null;
        //ClearLoginRegisterFeilds();
        FindObjectOfType<SFX>().Click();
    }

    public void SaveDataButton(int EndlessScore)
    {
        /*
        if(usernameField.text != null && usernameField.text != User.DisplayName)
        {
            StartCoroutine(UpdateUsernameAuth(usernameField.text));
            StartCoroutine(UpdateUsernameDatabase(usernameField.text));
        }
        */

        //TMP_Text scoreText = GameObject.Find("EndlessGameOver/Highscore").GetComponent<TMP_Text>();
        StartCoroutine(UpdateScore(EndlessScore));
        FindObjectOfType<SFX>().Click();
    }

    public void LoadFriendsSceneButton()
    {
        StartCoroutine(LoadUserData());
        StartCoroutine(LoadScoreboardData());
        FindObjectOfType<SFX>().Click();
    }

    public void CopyUID()
    {
        GUIUtility.systemCopyBuffer = myUID.text;
    }

    private IEnumerator Login(string _email, string _password)
    {
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if(LoginTask.Exception != null)
        {
            //handle errors
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);

            CorrectEmail = _email;
            CorrectPassword = _password;

            if(SceneManager.GetActiveScene().name == "FriendsAndAchievements")
            {
                LoadFriendsSceneButton();
            }

            if(SceneManager.GetActiveScene().name == "UploadScore")
            {
                usernameDisplayField.text = User.DisplayName;
            }
            
            if(SceneManager.GetActiveScene().name == "LoginRegister")
            {
                warningLoginText.text = "";
                confirmLoginText.text = "Logged In";

                yield return new WaitForSeconds(1);

                SceneManager.LoadScene("Menu");
            }
        }
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            //If the username field is blank show a wanring
            warningRegisterText.text = "Missing Username";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            warningRegisterText.text = "Password Does not Match!";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //wait until task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
            }
            else
            {
                //User has now been created
                //get result
                User = RegisterTask.Result;

                if (User != null)
                {
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing profile with username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //wait until task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //handle errors
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //Username is now set
                        //Return to login screen
                        UIManager.instance.LoginScreen();
                        warningRegisterText.text = "";
                    }
                }
            }
        }
    }

    private IEnumerator UpdateUsernameAuth(string _username)
    {
        //Create a user profile and set the username
        UserProfile profile = new UserProfile { DisplayName = _username };

        //Update user profile passing the profile with the username
        var ProfileTask = User.UpdateUserProfileAsync(profile);
        //Wait until completion
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

        if (ProfileTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
        }
        else
        {
            Debug.Log("Auth username updated");
        }
    }

    private IEnumerator UpdateUsernameDatabase(string _username)
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("username").SetValueAsync(_username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Database username updated");
        }
    }

    private IEnumerator UpdateFriendsList(string friends, bool? setFriendsStatus)
    {
        var DBTask = DBreference.Child("friends").Child(User.UserId).Child(friends).SetValueAsync(setFriendsStatus);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Friend list updated");
        }
        StartCoroutine(LoadScoreboardData());
    }

    private IEnumerator UpdateScore(int _score)
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("score").SetValueAsync(_score);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Score updated");
        }
    }

    private IEnumerator LoadUserData()
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            scoreField.text = "0";
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            scoreField.text = snapshot.Child("score").Value.ToString();
        }
        usernameDisplayField.text = User.DisplayName;
        myUID.text = User.UserId;
        Debug.Log("User Data Loaded");
    }

    private IEnumerator LoadScoreboardData()
    {
        var DBTask = DBreference.Child("users").OrderByChild("score").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        var PullFriendsList = DBreference.Child("friends").Child(User.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => PullFriendsList.IsCompleted);

        if (DBTask.Exception != null || PullFriendsList.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
            Debug.LogWarning(message: $"Failed to register task with {PullFriendsList.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;
            DataSnapshot friendsList = PullFriendsList.Result;
            Debug.Log("Data has been retrieved");

            //Destroy existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                if(friendsList.Child(childSnapshot.Key).Exists)
                {
                    string username = childSnapshot.Child("username").Value.ToString();
                    int score = int.Parse(childSnapshot.Child("score").Value.ToString());

                    Debug.Log("Creating Scoreboard Elements for " + username);

                    GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                    scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, score);
                    scoreboardElement.GetComponent<ScoreElement>().RecordFriendUID(childSnapshot.Key);
                }
            }
            friendsScreenElements.SetActive(false);
            friendsScreenElements.SetActive(true);
        }
    }

    //still requires: make add friends two sided
}
