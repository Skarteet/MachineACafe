using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineACafe
{
    public class Boisson
    {
        public Boisson(EnumBoisson typeBoisson, bool gobeletDected, int nbSucre)
        {
            TypeBoisson = typeBoisson;
            IntoNewGobelet = !gobeletDected;
            NbSucre = nbSucre;
        }


        public EnumBoisson TypeBoisson { get; set; }

        public int NbSucre { get; set; }

        public bool IntoNewGobelet { get; set; }
    }
}
