using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.StrategyCharacter
{
    public abstract class AbstractCharacter
    {
        private IWeaponBehaviour _weaponBehaviour;

        public IWeaponBehaviour WeaponBehaviour
        {
            set { _weaponBehaviour = value; }
        }

        public void Attack()
        {
            Console.WriteLine($"Soy un {GetType().Name}");
            _weaponBehaviour.Attack();
        }
    }
}
