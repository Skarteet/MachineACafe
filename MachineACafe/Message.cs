using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineACafe
{
    public static class Message
    {
        public static string PasAssezArgent { get => "Veuillez insérer {0}cts."; }
        public static string SelectionnezBoisson { get => "Veuillez sélectionner une boisson."; }
        public static string PlusDeGrainRenduArgent { get => "Plus de grain dans la machine, rendu de {0}cts."; }
        public static string Annulation { get => "Annulation"; }
    }
}
