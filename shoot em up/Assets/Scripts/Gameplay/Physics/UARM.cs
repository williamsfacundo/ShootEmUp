namespace ShootEmUp.Gameplay.Physics 
{
    public static class UARM
    {
        public static float CalculatePositionRelatedToTime(float initialPosition, float initialVelocity, float aceleration,float time) 
        {
            return initialPosition + (initialVelocity * time) + (aceleration * 0.5f) * (time * time); 
        }
    }
}