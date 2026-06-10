using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.StrategyCharacter.Weapon_Strategies
{
    internal class SwordBehaviour : IWeaponBehaviour
    {
        public void Attack()
        {
            Console.WriteLine("Ataco con mi espada y hago sangrados");
        }
    }
}
