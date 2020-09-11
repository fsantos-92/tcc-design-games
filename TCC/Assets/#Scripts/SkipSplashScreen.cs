using UnityEngine;
using UnityEngine.EventSystems;

public class SkipSplashScreen : MonoBehaviour, IPointerClickHandler
{
	void Update()
	{
		if (Input.anyKeyDown)
			UnityEngine.SceneManagement.SceneManager.LoadScene("GameContext");
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameContext");
	}
}
