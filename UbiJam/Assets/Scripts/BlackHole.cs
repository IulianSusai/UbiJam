using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    private List<Planet> planetList;
    private Planet hookedPlanet;
    private void Start() {
        RegisterEvents();
    }

    private void OnDestroy() {
        UnregisterEvents();
    }

    public void SetPlanets(List<Planet> _pList) {
        planetList = _pList;
    }

    private void OnTap() {
        hookedPlanet = GetClosePlanet();
        hookedPlanet.ChangeDirection();
    }
    private void OnHold() { 
    }
    private void OnEndTap() {
        if (hookedPlanet != null) {
            hookedPlanet.ChangeDirection();
        }
    }

    private Planet GetClosePlanet() {
        if(planetList.Count > 0) {
            Planet closePlanet = planetList[0];
            float closeDist = Vector3.Distance(closePlanet.transform.position, transform.position);
            foreach (Planet p in planetList) {
                float currentDist = Vector3.Distance(p.transform.position, transform.position);
                if(currentDist >= closeDist) {
                    closePlanet = p;
                }
            }
            return closePlanet;
        }
        return null;
    }

    private void RegisterEvents() {
        //ActionsController.Instance.onTap += OnTap;
        //ActionsController.Instance.onHold += OnHold;
        ActionsController.Instance.onEndTap += OnEndTap;
    }

    private void UnregisterEvents() {
        //ActionsController.Instance.onTap -= OnTap;
        //ActionsController.Instance.onHold -= OnHold;
        ActionsController.Instance.onEndTap -= OnEndTap;
    }
    private void OnMouseDown() {
        Debug.LogError("HERE");
        ActionsController.Instance.SendOnTap(this);
    }

    private void OnMouseUp() {
        Debug.LogError("UP");
        ActionsController.Instance.SendOnEndTap();
    }

    private void OnMouseDrag() {
        ActionsController.Instance.SendOnHold(this);
    }

}
