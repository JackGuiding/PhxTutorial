using UnityEngine;

namespace PhxEngine2D.Sample {

    public class SampleEntity : MonoBehaviour {

        // 物理引擎事件
        // 官方提供的生命周期, 它只对有Collider2D的物体生效
        // Collision 硬物与硬物
        void OnCollisionEnter2D(Collision2D other) {
            Debug.Log("OnCollisionEnter2D: " + other.gameObject.name);
        }
        
        void OnCollisionStay2D(Collision2D other) {
            Debug.Log("OnCollisionStay2D: " + other.gameObject.name);
        }

        void OnCollisionExit2D(Collision2D other) {
            Debug.Log("OnCollisionExit2D: " + other.gameObject.name);
        }

        // Trigger 其中有一个软物
        void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
        }

        void OnTriggerStay2D(Collider2D other) {
            Debug.Log("OnTriggerStay2D: " + other.gameObject.name);
        }

        void OnTriggerExit2D(Collider2D other) {
            Debug.Log("OnTriggerExit2D: " + other.gameObject.name);
        }

    }

}