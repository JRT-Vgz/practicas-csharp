using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsMIO.StrategyCharacter.Weapon_Strategies
{
    internal class BowBehaviour : IWeaponBehaviour
    {
        public void Attack()
        {
            Console.WriteLine("Ataco con mi arco y hindereo");
        }
    }
}
