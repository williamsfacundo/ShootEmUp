using UnityEngine;

namespace ShootEmUp.ScriptsUtils 
{
    public static class Utils
    {
        private static Vector3 _aux = Vector3.zero;

        /*public static void DestroyScriptIfAnObjectIsNull(Object theObject, Object script, GameObject gameObject)
        {
            if (theObject == null)
            {
                Debug.LogError("You have a null object needed for the correct functioning of the script!");

                Debug.Log("Deleting script: " + gameObject.GetComponent<MonoBehaviour>() + "!");               

                MonoBehaviour.Destroy(script);
            }
        }*/

        public static Vector3 GetMouseWorldPosition(Vector3 screenPosition, UnityEngine.Camera mainCamera)
        {
            return mainCamera.ScreenToWorldPoint(screenPosition);
        }

        public static Vector3 GetMouseWorldPositionWithZeroZ()
        {
            _aux = GetMouseWorldPosition(Input.mousePosition, UnityEngine.Camera.main);

            _aux.z = 0f;

            return _aux;
        }

        public static float GetAngleFromVectorFloat(Vector3 direction) 
        {
            direction = direction.normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (angle < 0.0f) 
            {
                angle += 360.0f;
            }

            return angle;
        }
    }
}