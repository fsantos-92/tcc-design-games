public class ParticlesController : UnityEngine.MonoBehaviour
{
	private UnityEngine.ParticleSystem particle;

	void Awake()
	{
		particle = GetComponent<UnityEngine.ParticleSystem>();
		enabled = false;
	}

	void OnEnable()
	{
		particle.Play();
		StartCoroutine(ParticleControl());
	}

	System.Collections.IEnumerator ParticleControl()
	{
		yield return new UnityEngine.WaitForSeconds(particle.main.duration);
		particle.Clear();
		enabled = false;
	}
}
