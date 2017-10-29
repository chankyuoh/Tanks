using UnityEngine;


    public class Bullet : MonoBehaviour
    {
        public const float Lifetime = 7.5f; // bullets last this long
        private float _deathtime;

        public void Initialize (Vector2 velocity, float deathtime) {
            GetComponent<Rigidbody2D>().velocity = velocity;
            _deathtime = deathtime;
        }

        internal void Update () {
            if (Time.time > _deathtime)
            {
                Die();
            }
        }

        internal void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Bullet>() == null)
            {
                Die();
            }
        }

        private void Die () {
            Destroy(gameObject);
        }
    }

