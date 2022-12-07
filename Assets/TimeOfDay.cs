using UnityEngine;

namespace Environment
{
    public class TimeOfDay : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject blackoutObj;
        [SerializeField] private Camera colorCameraBackground;

        [SerializeField] private Gradient gradientForBlackout;
        [SerializeField] private Gradient gradientForCamera;
        
        [SerializeField] private float dayDuratioin;
        
        [Range(0,1)]
        public float timeOfDay;
        private bool isNight;

        private void Start()
        {
            blackoutObj.GetComponent<Renderer>().enabled = true;
        }

        private void Update()
        {
            blackoutObj.transform.position = playerTransform.position;

            if (!isNight)
            {
                timeOfDay += Time.deltaTime / dayDuratioin;

                SetColorFromGradient();
                
                if (timeOfDay >= 1f) isNight = !isNight;
            }
            else
            {
                timeOfDay -= Time.deltaTime / dayDuratioin;
                
                SetColorFromGradient();
                
                if (timeOfDay <=0f) isNight = !isNight;
            }
        }

        private void SetColorFromGradient()
        {
            blackoutObj.GetComponent<Renderer>().material.color = gradientForBlackout.Evaluate(timeOfDay);
            colorCameraBackground.backgroundColor = gradientForCamera.Evaluate(timeOfDay);
        }
    }
}
