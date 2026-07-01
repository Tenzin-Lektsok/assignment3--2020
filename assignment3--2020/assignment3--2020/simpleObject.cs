using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3Template
{
    class SO
    {
        public int key;

        // Simple object used in the priority queue simulation.
        // The queue priority is passed separately into enqueue().
        public SO(int inputkey)
        {
            key = inputkey;
        }

        public override string ToString()
        {
            return "SO key: " + key;
        }
    }
}