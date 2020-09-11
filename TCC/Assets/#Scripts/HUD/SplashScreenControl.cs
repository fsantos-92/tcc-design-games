using UnityEngine;

public class SplashScreenControl : MonoBehaviour
{
	void Update()
	{
		if(Input.anyKey)
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameContext");
	}
	public void LoadIsMenuPrincipal()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameContext");
	}
}
