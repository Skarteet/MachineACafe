using MachineACafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMachineACafe
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SertExpresso_ArgentBon_SansGlobelet_SansSucre()
        {
            //Etant donné 
            var machine = new Machine();
            machine.InsererMonnaie(40);

            //Etant donné 
            (Boisson? boisson, _, _) = machine.ChoixBoisson(EnumBoisson.Expresso);

            Assert.IsNotNull(boisson, "La machine n'a pas servit la boisson");
            Assert.IsTrue(boisson!.NbSucre == 0, "La boisson est sucrée");
            Assert.IsTrue(boisson!.IntoNewGobelet, "La machine n'a pas placé de nouveau gobelet");
            Assert.IsTrue(boisson.TypeBoisson == EnumBoisson.Expresso, "La machine n'a pas servit la bonne boisson");
        }

        [TestMethod]
        public void SertExpresso_ArgentBon_AvecGlobelet_SansSucre()
        {
            var machine = new Machine();
            machine.GobeletDetecte = true;
            machine.InsererMonnaie(30);

            (Boisson? boisson, _, _) = machine.ChoixBoisson(EnumBoisson.Expresso);

            Assert.IsNotNull(boisson, "La machine n'a pas servit la boisson");
            Assert.IsTrue(boisson!.NbSucre == 0, "La boisson est sucrée");
            Assert.IsFalse(boisson!.IntoNewGobelet, "La machine a placé un nouveau gobelet");
            Assert.IsTrue(boisson.TypeBoisson == EnumBoisson.Expresso, "La machine n'a pas servit la bonne boisson");
        }

        [TestMethod]
        public void SertExpresso_ArgentBon_AvecGlobelet_AvecUnSucre()
        {
            var machine = new Machine();
            machine.GobeletDetecte = true;
            machine.DemandeSucre = 1;
            machine.InsererMonnaie(30);

            (Boisson? boisson, _, _) = machine.ChoixBoisson(EnumBoisson.Expresso);

            Assert.IsNotNull(boisson, "La machine n'a pas servit la boisson");
            Assert.IsTrue(boisson!.NbSucre == 1, "La boisson n'est pas correctement sucrée");
            Assert.IsFalse(boisson!.IntoNewGobelet, "La machine a placé un nouveau gobelet");
            Assert.IsTrue(boisson.TypeBoisson == EnumBoisson.Expresso, "La machine n'a pas servit la bonne boisson");
        }

        [TestMethod]
        public void SertExpresso_ArgentAjustement_AvecGlobelet_SansSucre()
        {
            var machine = new Machine();
            machine.GobeletDetecte = true;
            machine.InsererMonnaie(20);
            machine.ChoixBoisson(EnumBoisson.Expresso);
            (Boisson? boisson, _, _) = machine.InsererMonnaie(10);

            Assert.IsNotNull(boisson, "La machine n'a pas servit la boisson");
            Assert.IsTrue(boisson!.NbSucre == 0, "La boisson est sucrée");
            Assert.IsFalse(boisson!.IntoNewGobelet, "La machine a placé un nouveau gobelet");
            Assert.IsTrue(boisson.TypeBoisson == EnumBoisson.Expresso, "La machine n'a pas servit la bonne boisson");
        }

        [TestMethod]
        public void SertExpresso_ArgentBon_AvecGlobelet_SansSucre_PlusDeGrain()
        {
            var machine = new Machine();
            machine.IsGrain = false;
            machine.GobeletDetecte = true;
            machine.InsererMonnaie(30);
            (Boisson? boisson, string message, int? rendu) = machine.ChoixBoisson(EnumBoisson.Expresso);

            Assert.IsNull(boisson, "La machine a servit une boisson");
            Assert.IsNotNull(message, "La machine n'a pas retourné de message");
            Assert.IsNotNull(rendu, "La machine n'a pas rendu d'argent");
            Assert.IsTrue(string.Format(Message.PlusDeGrainRenduArgent, 30) == message, "La machine n'a indiqué le rendu d'argent");
            Assert.IsTrue(rendu == 30, "La machine n'a pas rendu le bon montant");
        }

        [TestMethod]
        public void SertChocolat_ArgentBon_AvecGlobelet_SansSucre_PlusDeGrain()
        {
            var machine = new Machine();
            machine.IsGrain = false;
            machine.GobeletDetecte = true;
            machine.InsererMonnaie(30);
            (Boisson? boisson, _, _)  = machine.ChoixBoisson(EnumBoisson.Chocolat);

            Assert.IsNotNull(boisson, "La machine n'a pas servit la boisson");
            Assert.IsTrue(boisson!.NbSucre == 0, "La boisson est sucrée");
            Assert.IsFalse(boisson!.IntoNewGobelet, "La machine a placé un nouveau gobelet");
            Assert.IsTrue(boisson.TypeBoisson == EnumBoisson.Chocolat, "La machine n'a pas servit la bonne boisson");
        }

        [TestMethod]
        public void SertChocolat_ArgentBon_AvecGlobelet_SansSucre_PlusDeCacao()
        {
            var machine = new Machine();
            machine.IsCacao = false;
            machine.GobeletDetecte = true;
            machine.InsererMonnaie(30);
            (Boisson? boisson, string message, int? rendu) = machine.ChoixBoisson(EnumBoisson.Chocolat);

            Assert.IsNull(boisson, "La machine a servit une boisson");
            Assert.IsNotNull(message, "La machine n'a pas retourné de message");
            Assert.IsNotNull(rendu, "La machine n'a pas rendu d'argent");
            Assert.IsTrue(string.Format(Message.PlusDeGrainRenduArgent, 30) == message, "La machine n'a indiqué le rendu d'argent");
            Assert.IsTrue(rendu == 30, "La machine n'a pas rendu le bon montant");
        }

        [TestMethod]
        public void SertChocolat_ArgentSuperieur_SansGlobelet_SansSucre()
        {
            var machine = new Machine();
            machine.InsererMonnaie(70);

            (Boisson? boisson, _, int? rendu) = machine.ChoixBoisson(EnumBoisson.Chocolat);

            Assert.IsNotNull(boisson, "La machine n'a pas servit la boisson");
            Assert.IsTrue(boisson!.NbSucre == 0, "La boisson est sucrée");
            Assert.IsTrue(boisson!.IntoNewGobelet, "La machine n'a pas placé de nouveau gobelet");
            Assert.IsTrue(boisson.TypeBoisson == EnumBoisson.Chocolat, "La machine n'a pas servit la bonne boisson");
            Assert.IsNotNull(rendu, "La machine n'a pas rendu d'argent");
            Assert.IsTrue(rendu == 30, "La machine n'a pas rendu le bon montant");
        }

        [TestMethod]
        public void SertExpresso_SansArgent()
        {
            var machine = new Machine();

            (Boisson? boisson, string message, _) = machine.ChoixBoisson(EnumBoisson.Expresso);

            Assert.IsNull(boisson, "La machine a servit une boisson");
            Assert.IsNotNull(message, "La machine n'a pas retourné de message");
            Assert.IsTrue(string.Format(Message.PasAssezArgent, 40 - machine.Monnaie) == message, "La machine n'a pas demandé la somme manquante");
        }

        [TestMethod]
        public void Annulation_RendArgent()
        {
            var machine = new Machine();
            machine.InsererMonnaie(40);
            (string message, int rendu) = machine.Annulation();

            Assert.IsNotNull(message, "La machine n'a pas retourné de message");
            Assert.IsTrue(Message.Annulation == message, "La machine n'a indiqué l'annulation");
            Assert.IsTrue(rendu == 40, "La machine n'a pas rendu le bon montant");
        }
    }
}