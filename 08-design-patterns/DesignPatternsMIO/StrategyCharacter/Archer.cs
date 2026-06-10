using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.StrategyCharacter
{
    public class Archer : AbstractCharacter
    {
        public Archer(IWeaponBehaviour weaponBehaviour)
        {
            WeaponBehaviour = weaponBehaviour;
        }
    }
}
