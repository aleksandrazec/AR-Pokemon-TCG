using System.Collections;
using UnityEngine;

public class ParticleCall : MonoBehaviour
{
    public ParticleSystem fire;

    public void showParticles()
    {
        fire.Play();
        StartCoroutine(StopAndDisable(fire, 3f));
    }

    IEnumerator StopAndDisable(ParticleSystem ps, float delay)
    {
        yield return new WaitForSeconds(delay);
        ps.Stop();

        // Wait until all particles die
        while (ps.IsAlive(true))
        {
            yield return null;
        }

        // Then disable or destroy
        gameObject.SetActive(false);
        // or Destroy(gameObject);
    }

}
