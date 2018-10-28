﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialisation de la variable random
            Random aleatoire = new Random();

            // initialisation de la taille de l'ecosysteme
            Ecosysteme MonEcosyst = new Ecosysteme(100,100);

            // initialisation des occupant de l'ecosysteme
            List<Nuisible> nuisibles = new List<Nuisible>();
            Nuisible remi = new Rat();
            Nuisible fred = new Rat();
            Nuisible titou = new Pigeon();
            Nuisible pigey = new Pigeon();
            Nuisible pigeyotot = new Pigeon();
            Nuisible ZGefrey = new Zombie();

            nuisibles.Add(remi);
            nuisibles.Add(fred);
            nuisibles.Add(titou);
            nuisibles.Add(pigey);
            nuisibles.Add(pigeyotot);
            nuisibles.Add(ZGefrey);



            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("-- Debut de l'initialisation des positions -- ");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("\n");

            int i = 0;
            // initialisation des positions
            foreach (Nuisible nuisible in nuisibles)
            {
                i = i + 1;
                int minPos = 0;
                int maxPosX = MonEcosyst.LimiteX + 1;
                int maxPosY = MonEcosyst.LimiteY + 1;
                //Console.WriteLine(maxPosX);
                int tempx = aleatoire.Next(minPos, maxPosX);
                int tempy = aleatoire.Next(minPos, maxPosY);
                //Console.WriteLine(tempy);
                //Console.WriteLine(tempx);
                nuisible.PositionX = tempx;
                nuisible.PositionY = tempy;
                nuisible.Nom = i.ToString();
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("La position initial de " + nuisible.Nom + " est : " + nuisible.PositionX + "X" + nuisible.PositionY + "Y");
            }

            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("-- Fin de l'initialisation des positions -- ");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine ("\n");

            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("-- Nous allons faire des tests experimental sur fred -- ");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("\n");

            Console.WriteLine("Fred est : " + fred.Etat);
            fred = null;


            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("-- Nous avons tuer fred, dommage. -- ");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("\n");





            // TEST DE BOUCLE D'EVOLUTION DE L'ECOSYSTEME
            int nombreTics = 10;
            for(int z = 0; z < nombreTics; z++)
            {


                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("-- Debut des deplacement des nuisibles pour ce tour -- ");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("\n");

                int orientation;
                // Fait bouger tout le monde
                foreach (Nuisible nuisible in nuisibles)
                {
                    orientation = aleatoire.Next(0, 8); 
                    nuisible.Deplacement(MonEcosyst.LimiteX, MonEcosyst.LimiteY, orientation);
                    Console.WriteLine("--------------------------------- ");
                    Console.WriteLine("La position final de " + nuisible.Nom + " est : " + nuisible.PositionX + "X" + nuisible.PositionY + "Y");
                    //Console.WriteLine("La position final de " + nuisible.Nom + " est : " + nuisible.PositionX + "X" + nuisible.PositionY + "Y  ayant pour orientation " + orientation + " et se deplace a une vitesse de " + nuisible.VitesseDeplacement);

                }

                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("-- Fin des deplacement des nuisibles pour ce tour -- ");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("\n");



                var beauaffich = z + 1;
                Console.WriteLine("Vous venez de terminer le tour numero : " + beauaffich);
                Console.ReadLine();
            }



            // Affichage des positions
            //Console.WriteLine(remi.PositionX);
            //Console.WriteLine(fred.PositionX);
            //Console.WriteLine(titou.PositionX);
            //Console.WriteLine(ZGefrey.PositionX);
            // Affichage des etats
            //Console.WriteLine(ZGefrey.Etat);
            //Console.WriteLine(titou.Etat);
            //Console.WriteLine("\n");

            // Test des collisions
            foreach (Nuisible nuisible in nuisibles)
            {
                IEnumerable<Nuisible> memePos = nuisibles.Where((x) => x != nuisible && x.PositionX == nuisible.PositionX && x.PositionY == nuisible.PositionY);

                var test1 = memePos.ToArray();

                //Console.WriteLine("L'objet numero : " + nuisible.Nom + " est en colision avec : " + test1.Length + " Objet(s) ");
                for (int y = 0; y < test1.Length; y++)
                {
                    //Console.WriteLine("C'est l'objet : " + test1[y].Nom + " positionner en " + test1[y].PositionX + "X" + test1[y].PositionY + "Y");
                }
               // Console.WriteLine("\n");
            }

            






            if (titou.PositionY == ZGefrey.PositionY && titou.PositionX == ZGefrey.PositionX)
                {
                    //Console.WriteLine("Zgefrey est au meme endroit que titou");
                }

                


            Console.ReadLine();
        }
    }
}
