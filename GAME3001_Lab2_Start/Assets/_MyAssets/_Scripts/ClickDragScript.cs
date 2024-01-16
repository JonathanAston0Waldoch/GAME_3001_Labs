using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragScript : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody2D currentDraggedObject;
    private Vector2 offset;
    
    void Update()
    {
     // first we check if player clicked on screen
     if(Input.GetMouseButtonDown(0))
        {
            //Raycast to check if the mouse is over a collider
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null) // did we click an object with a collider 
            {
                // Check if the clicked Gameobject has a rigidbody2D
                Rigidbody2D rb2d = hit.collider.GetComponent<Rigidbody2D>(); // try to get rigidbody2d from the gameobject from its collider 

                if(rb2d != null)
                {
                    // Start dragging only if no object is currently being dragged
                    isDragging = true;
                    currentDraggedObject = rb2d;

                    offset = rb2d.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                }
            }
        }
     else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            currentDraggedObject = null;
        }
        // Drag object according to mouse 
        if(isDragging && currentDraggedObject != null)
        {
            // move the dragged Gobject based on the mouse position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // according to mouse position on the screen 
            currentDraggedObject.MovePosition(mousePosition + offset);
        }
    }
}
