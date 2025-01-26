// using Unity.VisualScripting;
// using UnityEngine;

// public class PlayerAttack : MonoBehaviour
// {
//     public int damage = 10;
//     public GameObject hitbox;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
       
//         if (Input.GetKey(KeyCode.Mouse0))
//         {
//             ToggleHitBox(true);
//         }
//         else if (Input.GetKeyUp(KeyCode.Mouse0))
//         {
//             ToggleHitBox(false);
//         }
//     }


//     void ToggleHitBox(bool value)
//     {
//         hitbox.SetActive(value);

//         if (value == true)
//         {

//         }
//     }


//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         // Verifica se o objeto atingido tem a tag "Enemy"
//         if (collision.CompareTag("Enemy"))
//         {
//             // Obt�m o script EnemyScript do objeto atingido
//             EnemyScript enemy = collision.GetComponent<EnemyScript>();

//             if (enemy != null)
//             {
//                 // Aplica dano ao inimigo
//                 enemy.TakeDamage(damage);
//             }

//             // Destroi o proj�til ap�s o impacto
//             Destroy(gameObject);
//         }
//     }



// }
