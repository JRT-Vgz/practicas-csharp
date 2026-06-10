using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.StrategyCharacter
{
    public class DeathKnight : AbstractCharacter
    {

        public DeathKnight(IWeaponBehaviour weaponBehaviour)
        {
            WeaponBehaviour = weaponBehaviour;
        }
    }
}
