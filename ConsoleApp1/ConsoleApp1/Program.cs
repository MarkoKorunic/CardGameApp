using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Active entities:");
                foreach (var entity in Root.LiveEntities)
                {
                    Console.WriteLine(entity.entityId);
                }
                Console.WriteLine("Press F1 to attack. Press F2 to end round. Press F5 to exit game.");
                var userKey = Console.ReadKey();
                if (userKey.Key == ConsoleKey.F1)
                {
                    Console.WriteLine();
                    EntityAttack();
                }
                if (userKey.Key == ConsoleKey.F2)
                {
                    Console.WriteLine();
                    RoundEnd();
                }
                if (userKey.Key == ConsoleKey.F5)
                {
                    Console.Clear();
                    Console.ReadKey();
                    break;
                }

                else
                {
                    Console.Clear();
                    continue;

                }


            }

        }

        public static void EntityAttack()
        {

            GameMechanics gameMechanics = new GameMechanics();
            Console.WriteLine("Enter sourceId for attack source.");
            var sourceId = Console.ReadLine();
            var sourceEntity = Root.LiveEntities.SingleOrDefault(entity => entity.entityId == sourceId);
            if (EntityValid(sourceEntity) == false)
            {
                return;
            }
            if (EntityDisplayCheck(sourceEntity) == false)
            {
                return;
            }

            Console.WriteLine("Enter targetId for attack target.");
            var targetId = Console.ReadLine();
            var targetEntity = Root.LiveEntities.SingleOrDefault(entity => entity.entityId == targetId);
            if (EntityValid(targetEntity) == false)
            {
                return;
            }
            if (EntityDisplayCheck(targetEntity) == false)
            {
                return;
            }

            if (gameMechanics.AttackCheck(sourceEntity, targetEntity) == true)
            {
                gameMechanics.AttackProcess(sourceEntity, targetEntity);
                JsonAccess.JsonEntitiesSave(Root.Entities);
            }



        }

        public static void RoundEnd()
        {
            Console.WriteLine("End round? Press Y to confirm. Press N to go back.");
            var userKey = Console.ReadKey();
            if (userKey.Key == ConsoleKey.N)
            {
                return;
            }

            if (userKey.Key == ConsoleKey.Y)
            {
                GameMechanics.AttackReset();
                return;
            }

            //attackReady se mora prebaciti na false napadaću.
            //sustav mora spremiti novo stanje entiteta u board.json i vratiti EntityAttackedMessage(na konzolu) sa sljedećim poljima: sourceId, targetId i value.
            //Napadi se simuliraju u rundama, svaki entitet može(ali ne mora) napasti jednom po rundi.

        }



        public static void ModifierDisplay(Modifier modifier)
        {
            Console.WriteLine(modifier.modifierType + ":" + modifier.value);
        }

        public static bool EntityDisplayCheck(Entity entity)
        {
            while (true)
            {
                var result = true;
                Console.WriteLine("NAME:" + entity.entityId + " /ATT:" + entity.attack + " /HP:" + entity.health + " /TYPE:" + entity.entityType);
                foreach (var modifier in entity.modifiers)
                {
                    ModifierDisplay(modifier);
                }
                Console.WriteLine("Press B to abort attack. Press F1 to proceed.");


                var userKey = Console.ReadKey();
                if (userKey.Key == ConsoleKey.B)
                {
                    Console.Clear();
                    result = false;
                    return result;
                }

                if (userKey.Key == ConsoleKey.F1)
                {
                    result = true;
                    return result;
                }

                Console.Clear();
            }
        }
        public void RoundCounter()
        {

        }

        public static bool EntityValid(Entity entity)
        {
            bool result = false;
            if (entity == null)
            {
                Console.WriteLine("Invalid entity ID.");
                Console.ReadKey();
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

    }
    
}
