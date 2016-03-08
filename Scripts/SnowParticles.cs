using UnityEngine;
using System.Collections;
using AssemblyCSharp;

/// <summary>
/// Updates the snow particles to react to the wind.
/// </summary>
public class SnowParticles : MonoBehaviour {

	public ParticleSystem snow;
	public float speed;

	// Update is called once per frame
	void Update () {
		ParticleSystem.Particle[] p = new ParticleSystem.Particle[snow.particleCount+1];
		int l = snow.GetParticles(p);

		int i = 0;
		while (i < l) {
			p[i].velocity = new Vector3(-1*Util.percentDiff(-1*p[i].velocity.x,World.data.WindSpeed()*speed,0.05f),
				p[i].velocity.y, p[i].velocity.z);
			i++;
		}

		snow.SetParticles(p, l);  
	}
}
