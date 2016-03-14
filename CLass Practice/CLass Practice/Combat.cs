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

        public class Transition
        {
            public string m_TransitionName;
            public Enum m_firstState;
            public Enum m_secondState;
            public Transition(Enum S1, Enum S2)
            {
                m_firstState = S1;
                m_secondState = S2;
                m_TransitionName = (S1 + "->" + S2);
                Console.WriteLine("Transition " + m_TransitionName + " created.");
            }
        }
        Enum m_currentstate;
        private List<Enum> m_States;

        public Finite_State_Machine(Enum cs)
        {
            m_currentstate = cs;
            m_States = new List<Enum>();
            m_Transitions = new List<Transition>();
        }

        public bool ChangeStates(string t)
        {
            bool startingState = false;
            bool validTransition = false;
            foreach(Transition T in m_Transitions)
            {
                if (T.m_TransitionName == t)
                {
                    validTransition = true;
                }
                if (Convert.ToString(m_currentstate) == Convert.ToString(T.m_firstState))
                {
                    startingState = true;
                }
                if (((validTransition == true) && (startingState == true)))
                {
                    Console.WriteLine
                        ("Transition is valid. Changing current state from " + m_currentstate + " to " + T.m_secondState + ".");
                    m_currentstate = T.m_secondState;
                    return true;
                }
            }
            Console.WriteLine("No such transition exists. Make sure there are no typos and that the transition and states exist.");
            return false;
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
            count = 0;
            Console.WriteLine("The Finite State Machine contains the following transitions: ");
            foreach (Transition t in m_Transitions)
            {
                Console.WriteLine
                    ("Transition " + count + ": " + t.m_TransitionName);
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
        public bool AddTransition(Enum f, Enum t)
        {
            Enum from = f;
            Enum to = t;
            Transition transition = new Transition(f, t);
            m_Transitions.Add(transition);
            return true;
        }

        private List<Transition> m_Transitions;
        Dictionary<Enum, List<Transition>> TransitionTable;
    }

}
