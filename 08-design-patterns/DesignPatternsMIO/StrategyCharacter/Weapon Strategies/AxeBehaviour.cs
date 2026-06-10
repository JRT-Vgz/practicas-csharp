using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DesignPatternsMIO.StrategyCharacter.Weapon_Strategies
{
    public class AxeBehaviour : IWeaponBehaviour
    {
        public void Attack()
        {
            Console.WriteLine("Ataco con mi hacha y hago criticos");
        }
    }
}
