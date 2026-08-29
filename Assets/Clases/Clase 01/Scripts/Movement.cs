using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private float moveSpeed = 0.1f;

    [Header("Rotacion")]
    [SerializeField] private KeyCode rotateRigth = KeyCode.Q;
    [SerializeField] private KeyCode rotateLeft = KeyCode.E;
    [SerializeField] private float rotateSpeed = 10f;

    [Header("Color")]
    [SerializeField] private KeyCode colorChange = KeyCode.R;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento
        if (Input.GetKey(moveUp))
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime);
        
        if (Input.GetKey(moveRight))
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
        
        if (Input.GetKey(moveDown))        
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);
        
        if (Input.GetKey(moveLeft))        
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);

        // Rotacion 
        if (Input.GetKeyDown(rotateRigth))        
            transform.Rotate(Vector3.forward * rotateSpeed);
        
        if (Input.GetKey(rotateLeft))        
            transform.Rotate(Vector3.forward * -rotateSpeed);


        // Color
        if (Input.GetKeyUp(colorChange))
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
    }
}
