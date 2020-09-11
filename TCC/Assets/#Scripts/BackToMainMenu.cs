using UnityEngine;

public class BackToMainMenu : MonoBehaviour {
	void Update()
	{
		if (Input.anyKey)
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
	public void LoadIsMenuPrincipal()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
