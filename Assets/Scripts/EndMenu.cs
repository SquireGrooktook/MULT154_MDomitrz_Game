using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
	public GameManager Game_Manager;
	public Button yourButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		Game_Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void TaskOnClick()
	{
		Game_Manager.score = 0;
		Game_Manager.SceneTransition("MainGameScene");
		//SceneManager.LoadScene("MainGameScene", LoadSceneMode.Single);
	}
}
