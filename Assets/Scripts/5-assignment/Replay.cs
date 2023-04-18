using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour {

    GameObject player;
    public void LoadScene() {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player) {
            player.GetComponentInChildren<NumberField>().SetNumber(0);
        }
        SceneManager.LoadScene("a-level-1");
    }

}