using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
	public GameManager Game_Manager;
	public Button yourButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Game_Manager.SceneTransition("MainGameScene");
		//SceneManager.LoadScene("MainGameScene", LoadSceneMode.Single);
	}
}
