using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.StrategyCharacter
{
    public class Warrior : AbstractCharacter
    {

        public Warrior(IWeaponBehaviour weaponBehaviour)
        {
            WeaponBehaviour = weaponBehaviour;
        }
    }
}
