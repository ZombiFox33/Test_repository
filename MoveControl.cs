using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UIElements;
//using UnityEditor.Tilemaps;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MoveControl : MonoBehaviour
{
    [Header("передвижение")]
    public float DirectionX = 0;
    public float DirectionY = 0;
    [Range (0,10)]
    public float Speed = 2;
    [Header("прочее")]
    [SerializeField]
    private int Counter;
    [Space(50)]
    public Rigidbody2D rb;
    public TextMeshProUGUI ShowCounter;
    [HideInInspector]
    public bool isFloor;
    public Button buttonNext;
    public Button buttonPrev;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ShowCounter.text = $"Колличество собранных звёзд: {Counter}";
        buttonPrev.gameObject.SetActive(false);
        buttonNext.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        DirectionX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(DirectionX, 0);
        transform.Translate(movement * Speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFloor == true)
            {
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
                isFloor = false;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "floor")
        {
            isFloor = true;
        }
        if (collision.gameObject.tag == "Vrag") 
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "stars")
        {
            Destroy(collider.gameObject);
            Counter++;
            ShowCounter.text = $"Колличество собранных звёзд: {Counter}";
        }
        if (collider.gameObject.tag == "Char")
        {
            buttonPrev.gameObject.SetActive(true);
            buttonNext.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Char")
        {
            buttonPrev.gameObject.SetActive(false);
            buttonNext.gameObject.SetActive(false);
        }
    }
}
