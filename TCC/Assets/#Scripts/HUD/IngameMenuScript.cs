using UnityEngine;

public class IngameMenuScript : MonoBehaviour
{
	public void OnBackToGameButton ()
	{
		gameObject.SetActive (false);
	}

	public void OnMainMenuButton ()
	{
		GameManager.LeaveRoom ();
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenu");
	}

	public void OnQuitButton ()
	{
		Application.Quit ();
	}

	public void OnWorldMapButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("WorldMap");
	}
}
