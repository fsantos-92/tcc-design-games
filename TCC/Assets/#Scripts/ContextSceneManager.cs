using UnityEngine;
using UnityEngine.EventSystems;

public class ContextSceneManager : MonoBehaviour
{
	void Update()
	{
		if (Input.anyKeyDown)
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

	public void LoadIsMenuPrincipal()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

}
