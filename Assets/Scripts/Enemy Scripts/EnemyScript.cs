// using UnityEngine;

// public class EnemyScript : MonoBehaviour
// {
//     [Header("Configura��es do Inimigo")]
//     public int enemyLife = 100; // Vida inicial do inimigo
//     public int damageValue = 10; // Valor de dano causado pelo inimigo

//     // M�todo para aplicar dano ao inimigo
//     public void TakeDamage(int damage)
//     {
//         enemyLife -= damage;

//         Debug.Log($"Inimigo tomou {damage} de dano. Vida restante: {enemyLife}");

//         // Verifica se a vida do inimigo chegou a zero ou menos
//         if (enemyLife <= 0)
//         {
//             Die();
//         }
//     }

//     // M�todo chamado quando o inimigo morre
//     private void Die()
//     {
//         Debug.Log("Inimigo morreu!");
//         Destroy(gameObject); // Destroi o GameObject associado ao inimigo
//     }

    
// }
