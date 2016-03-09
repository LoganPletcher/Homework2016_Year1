using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLass_Practice
{
    class Combat
    {
    }

    public class Finite_State_Machine
    {

        class Transition
        {
            Transition()
            {

            }
        }
        Enum m_currentstate;
        private List<Enum> m_States;

        public Finite_State_Machine(Enum cs)
        {
            m_currentstate = cs;
            m_States = new List<Enum>();
        }

        public bool AddState (Enum s)
        {
            if(m_States.Contains(s))
            {
                Console.WriteLine("The Finite State Machine already contains this state.");
                return false;
            }
            else if (!(s.GetType() == typeof(Enum)))
            {
                m_States.Add(s);
                Console.WriteLine("State " + s + " added.");
                return true;
            }
            else
            {
                Console.WriteLine(s + " is invalid as a state because it is not an Enum.");
                return false;
            }
        }

        public int info()
        {
            int count = 0;
            Console.WriteLine("The Finite State Machine is comprised of the following states: ");
            foreach (Enum s in m_States)
            {
                Console.WriteLine
                    ("State " + count + ": " + s);
                count++;
            }
            Console.WriteLine("The current state is " + m_currentstate);
            return count;
        }

        //
        //
        //
        //
        //
        public bool AddTransition(string transition)
        {
            Enum from = null;
            Enum to = null;
            return true;
        }

        Dictionary<Enum, List<Transition>> TransitionTable;

    }

}
