namespace ShootEmUp.Gameplay.Weapon.Shooting 
{
    public class WeaponSingleShooting : WeaponShootingAction
    {
        private bool _bulletWasShot;

        public override void ShootMechanic() 
        {
            if (CanShoot()) 
            {
                _bulletWasShot = ShootBullet();

                if (_bulletWasShot) 
                {
                    ResetTimer();
                }
                else 
                {
                    Identity.ShootingAction.NextShotAvailableTimer = 0.0f;
                }
            }
        }        
    }
}