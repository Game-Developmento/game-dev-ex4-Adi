using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BorderCollision2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    /*
    * https://forum.unity.com/threads/question-about-bounds-extents-and-how-it-is-used.1086905/
    * Extents is half of the width or height of the box, so it can be used to find the edges from the center point.
    */
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            Bounds screen_bounds = this.GetComponent<BoxCollider2D>().bounds;
            Vector2 border_center = screen_bounds.center;
            Vector2 border_extents = screen_bounds.extents; 
            Vector3 player_pos = other.transform.position;

            // caclulate bounds
            float left_edge = border_center.x - border_extents.x;
            float right_edge = border_center.x + border_extents.x;
            float bottom_edge = border_center.y - border_extents.y;
            float top_edge = border_center.y + border_extents.y;
            
            // check if player is out of bounds
            if(player_pos.x < left_edge) {
                player_pos.x = right_edge;
            } else if(player_pos.x > right_edge) {
                player_pos.x = left_edge;
            } else if(player_pos.y < bottom_edge) {
                player_pos.y = top_edge;
            } else if(player_pos.y > top_edge) {
                player_pos.y = bottom_edge;
            }
            other.transform.position = player_pos;
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}
