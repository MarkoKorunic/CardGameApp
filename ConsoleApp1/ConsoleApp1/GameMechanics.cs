using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GameMechanics
    {
        public void AttackProcess(Entity sourceEntity, Entity targetEntity)
        {

            int sourceEntityModAttack = sourceEntity.attack + AttackModifier(targetEntity);
            int targetEntityModAttack = targetEntity.attack + AttackModifier(sourceEntity);
            Console.WriteLine(sourceEntity.entityId + " attacks " + targetEntity.entityId + ".");
            Console.ReadKey();
            targetEntity.health = targetEntity.health - sourceEntityModAttack;
            sourceEntity.health = sourceEntity.health - targetEntityModAttack;

            if (sourceEntity.health <= 0 && targetEntity.health <= 0)
            {
                Console.WriteLine(sourceEntity.entityId + " attacked " + targetEntity.entityId + " for " + sourceEntityModAttack + " damage and it died.");
                Console.WriteLine(targetEntity.entityId + " retaliated " + targetEntityModAttack + " damage to " + sourceEntity.entityId + " and it died.");
                Console.ReadKey();
            }
            if (sourceEntity.health <= 0 && targetEntity.health > 0)
            {
                Console.WriteLine(sourceEntity.entityId + " attacked " + targetEntity.entityId + " for " + sourceEntityModAttack + " damage. It now has " + targetEntity.health + " HP.");
                Console.WriteLine(targetEntity.entityId + " retaliated " + targetEntityModAttack + " damage to " + sourceEntity.entityId + " and it died.");
                Console.ReadKey();

            }
            if (sourceEntity.health > 0 && targetEntity.health <= 0)
            {
                Console.WriteLine(sourceEntity.entityId + " attacked " + targetEntity.entityId + " for " + sourceEntityModAttack + " damage and it died.");
                Console.WriteLine(targetEntity.entityId + " retaliated " + targetEntityModAttack + " damage to " + sourceEntity.entityId + ". It now has " + sourceEntity.health + " HP.");
                Console.ReadKey();


            }
            if (sourceEntity.health > 0 && targetEntity.health > 0)
            {
                Console.WriteLine(sourceEntity.entityId + " attacked " + targetEntity.entityId + " for " + sourceEntityModAttack + " damage. It now has " + targetEntity.health + " HP.");
                Console.WriteLine(targetEntity.entityId + " retaliated " + targetEntityModAttack + " damage to " + sourceEntity.entityId + ". It now has " + sourceEntity.health + " HP.");
                Console.ReadKey();

            }


            sourceEntity.attackReady = false;


        }

        public bool AttackCheck(Entity sourceEntity, Entity targetEntity)
        {
            if (sourceEntity.entityId == targetEntity.entityId)
            {
                Console.Clear();
                Console.WriteLine("Error : Entity cant attack itself.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return false;

            }

            else if (sourceEntity.entityType == EntityType.Creature && targetEntity.entityType == EntityType.Avatar)
            {
                Console.WriteLine("Error: Creature can't attack avatar.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return false;
            }

            else if (sourceEntity.attackReady == false)
            {
                Console.WriteLine("Error: Attacking entity already attacked.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return false;
            }

            return true;

        }



        public static void AttackReset()
        {
            Root.LiveEntities.ForEach(e => e.attackReady = true);
        }


        public static int AttackModifier(Entity entity)
        {
            int result = 0;
            foreach (var modifier in entity.modifiers)
            {
                int midResult = 0;
                if (modifier.modifierType == ModifierType.Armour)
                {
                    midResult -= modifier.value;
                }

                if (modifier.modifierType == ModifierType.Vulnerability)
                {
                    midResult += modifier.value;
                }

                result = midResult;
            }


            return result;

        }
    }
}
