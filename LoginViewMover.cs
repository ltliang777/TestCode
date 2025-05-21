
using UnityEngine;

namespace Game
{
    public class LoginViewMover : MonoBehaviour
    {

        public float speed;
        public float max;
        public float min;
     
        void Update()
        {
            Vector3 pos = transform.localPosition;
            pos.x += speed * Time.deltaTime;
            if (pos.x > max || pos.x < min)
            {
                speed = -speed;
            }
            //Flog.Log(string.Format("{0},{1}",pos.x,speed));
            transform.localPosition = pos;
        }

    }


}
