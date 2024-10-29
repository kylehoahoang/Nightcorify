using UnityEngine;
using UnityEngine.UI;

public class CircularPath : MonoBehaviour
{
    public Animator animator;
    public float radius = 2f; // Radius of the circular path
    public float speed = 2f; // Speed of movement along the circular path
    private float angle = 0f; // Current angle on the circular path
    
    public bool toggle = false;

    private float defaultX;
    private float defaultY;

    public Toggle toggleBtn;

    private Image buttonImage;

    void Start()
    {
        Transform transform = gameObject.transform;

        Vector3 position = transform.position;

        defaultX = position.x;
        defaultY = position.y;

        buttonImage = toggleBtn.GetComponent<Image>();
    }

    void Update()
    {
        if (toggle)
        {
            // Increment the angle based on the speed
            angle += speed * Time.deltaTime;
            // Cap the angle at 360 degrees
            angle %= 360f;
            //Debug.Log(angle);

            // Calculate the position on the circular path using trigonometry
            // Calculate the position on the circular path using trigonometry
            float x = (Mathf.Cos(angle * Mathf.Deg2Rad) * radius) + defaultX;
            float y = (Mathf.Sin(angle * Mathf.Deg2Rad) * radius) + defaultY;

            // Set the position of the GameObject to the calculated position
            transform.position = new Vector2(x, y);

            if (angle > 250 && angle < 290) // Right
            {
                animator.SetBool("rightMovement", true);
                animator.SetBool("leftMovement", false);
                animator.SetBool("upMovement", false);
                animator.SetBool("downMovement", false);
            }
            else if (angle > 70 && angle < 110) // Left
            {
                animator.SetBool("rightMovement", false);
                animator.SetBool("leftMovement", true);
                animator.SetBool("upMovement", false);
                animator.SetBool("downMovement", false);
            }
            else if (angle > 340 || (angle > 0 && angle < 20)) // Up
            {
                animator.SetBool("rightMovement", false);
                animator.SetBool("leftMovement", false);
                animator.SetBool("upMovement", true);
                animator.SetBool("downMovement", false);
            }
            else if (angle > 290 && angle < 340) // Up Right
            {
                animator.SetBool("rightMovement", true);
                animator.SetBool("leftMovement", false);
                animator.SetBool("upMovement", true);
                animator.SetBool("downMovement", false);
            }
            else if (angle > 20 && angle < 70) // Up Left
            {
                animator.SetBool("rightMovement", false);
                animator.SetBool("leftMovement", true);
                animator.SetBool("upMovement", true);
                animator.SetBool("downMovement", false);
            }
            else if (angle > 160 && angle < 200) // Down
            {
                animator.SetBool("rightMovement", false);
                animator.SetBool("leftMovement", false);
                animator.SetBool("upMovement", false);
                animator.SetBool("downMovement", true);
            }
            else if (angle > 200 && angle < 250) // Down Right
            {
                animator.SetBool("rightMovement", true);
                animator.SetBool("leftMovement", false);
                animator.SetBool("upMovement", false);
                animator.SetBool("downMovement", true);
            }
            else if (angle > 110 && angle < 160) // Down Left
            {
                animator.SetBool("rightMovement", false);
                animator.SetBool("leftMovement", true);
                animator.SetBool("upMovement", false);
                animator.SetBool("downMovement", true);
            }
        }
    }

    public void togglemove()
    {
        if (toggle)
        {
            toggle = false;
            animator.SetBool("rightMovement", false);
            animator.SetBool("leftMovement", false);
            animator.SetBool("upMovement", false);
            animator.SetBool("downMovement", false);
            animator.SetBool("gyrating", false);
            toggleBtn.GetComponent<Image>().color = new Color(0.45f, 0.54f, 0.62f ) ;
        }
        else{
            toggle = true;
            animator.SetBool("gyrating", true);
            toggleBtn.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
    }
}
