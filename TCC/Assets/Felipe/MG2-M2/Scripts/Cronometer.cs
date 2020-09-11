using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometer : MonoBehaviour {
	private float gameTime      = 0;
	private int   sign          = 1;
	public  bool  startFromZero = true;
	public  float startTime     = 121;
	public  Text  cron;


	public void Start() {
		gameTime = startTime;
		
	}


	public void Update () {
		gameTime        = gameTime - sign * Time.deltaTime;
		int minutes     = (int)(gameTime / 60);
		int seconds     = (int)(gameTime % 60);
		cron.text       = string.Format("{0:00}:{1:00}", minutes, seconds);

		if (gameTime <= 0) {

		}

	}
	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "relogio") {
			gameTime += 25;
			GameObject.Destroy (hit.gameObject);
		}
	}

	private void Reset(){
		SceneManager.LoadScene (0);		// ajustar pra começar o minigame novamente
	}

}
