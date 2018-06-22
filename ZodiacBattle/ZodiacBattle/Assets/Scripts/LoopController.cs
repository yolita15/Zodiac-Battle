using UnityEngine;


public class LoopController : MonoBehaviour {

    public GameObject player;

    private float offsetY;

	public void Start () {
        this.offsetY = this.transform.position.y
           - this.player.transform.position.y;
	
	}
	public void Update () {
        var position = this.transform.position;
        position.y = this.player.transform.position.y + offsetY;
        this.transform.position = position;
	
	}
}
