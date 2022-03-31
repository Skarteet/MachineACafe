using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineACafe
{

    public class Machine
    {
        public int Monnaie { get; set; }
        public bool GobeletDetecte { get; set; }
        public int DemandeSucre { get; set; }
        public bool IsGrain { get; set; }
        public bool IsCacao { get; set; }
        public EnumBoisson? BoissonSelected { get; set; }

        public Machine()
        {
            IsGrain = true;
            IsCacao = true;
        }

        public (Boisson?, string, int?) InsererMonnaie(int monnaie)
        {
            Monnaie += monnaie;
            return SertBoisson();
        }

        public (Boisson?, string, int?) ChoixBoisson(EnumBoisson enumBoisson)
        {
            BoissonSelected = enumBoisson;
            return SertBoisson();
        }

        private (Boisson?, string, int?) SertBoisson()
        {
            int? monnaieRendu = null;
            if (BoissonSelected == null)
                return (null, Message.SelectionnezBoisson, null);


            if ((!IsGrain && BoissonSelected == EnumBoisson.Expresso)
                || (!IsCacao && BoissonSelected == EnumBoisson.Chocolat))
            {
                monnaieRendu = Monnaie;
                ResetMachine();
                return (null, string.Format(Message.PlusDeGrainRenduArgent, monnaieRendu), monnaieRendu);
            }

            int neededAmount = GobeletDetecte ? 30 : 40;

            if (Monnaie < neededAmount)
                return (null, string.Format(Message.PasAssezArgent, neededAmount - Monnaie), null);

            Boisson boisson = new Boisson(BoissonSelected.Value, GobeletDetecte, DemandeSucre);
            if (Monnaie > 40)
                monnaieRendu = Monnaie - 40;

            ResetMachine();
            return (boisson, string.Empty, monnaieRendu);
        }

        public (string, int) Annulation()
        {
            var monnaieRendu = Monnaie;
            ResetMachine();
            return (Message.Annulation, monnaieRendu);
        }

        public void ResetMachine()
        {
            GobeletDetecte = false;
            Monnaie = 0;
            DemandeSucre = 0;
            BoissonSelected = null;
        }
    }
}
