using UnityEngine;

namespace ShootEmUp.Configurations 
{
    public class SetCursor : MonoBehaviour
    {
        [SerializeField] private Texture2D _cursorTexture;

        [SerializeField] private Vector2 _cursorTextureOffset;

        private void Awake()
        {
            Cursor.visible = true;

            Cursor.SetCursor(_cursorTexture, _cursorTextureOffset, CursorMode.Auto);
        }        
    }
}