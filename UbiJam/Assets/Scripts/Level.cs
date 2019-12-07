using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	[SerializeField] private BlackHole blackHole;
	[SerializeField] private List<Planet> planetList;

	private void Start() {
		blackHole.SetPlanets(planetList);
		foreach(Planet p in planetList) {
			p.InitWithHole(blackHole);
		}
	}

}
