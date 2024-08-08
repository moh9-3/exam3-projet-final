// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;

public class Etudiant
{
    public int NumeroEtudiant { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }

    public Etudiant(int numeroEtudiant, string nom, string prenom)
    {
        NumeroEtudiant = numeroEtudiant;
        Nom = nom;
        Prenom = prenom;
    }
}

public class Cours
{
    public int NumeroCours { get; set; }
    public string Code { get; set; }
    public string Titre { get; set; }

    public Cours(int numeroCours, string code, string titre)
    {
        NumeroCours = numeroCours;
        Code = code;
        Titre = titre;
    }
}

public class Notes
{
    public int NumeroEtudiant { get; set; }
    public int NumeroCours { get; set; }
    public double Note { get; set; }

    public Notes(int numeroEtudiant, int numeroCours, double note)
    {
        NumeroEtudiant = numeroEtudiant;
        NumeroCours = numeroCours;
        Note = note;
    }
}

public class GestionEtudiants
{
    private List<Etudiant> etudiants = new List<Etudiant>();

    public void AjouterEtudiant(Etudiant etudiant)
    {
        etudiants.Add(etudiant);
    }

    public void AfficherEtudiants()
    {
        foreach (var etudiant in etudiants)
        {
            Console.WriteLine($"Numéro: {etudiant.NumeroEtudiant}, Nom: {etudiant.Nom}, Prénom: {etudiant.Prenom}");
        }
    }

    public Etudiant TrouverEtudiant(int numeroEtudiant)
    {
        return etudiants.Find(e => e.NumeroEtudiant == numeroEtudiant);
    }

    public void EnregistrerEtudiants()
    {
        foreach (var etudiant in etudiants)
        {
            string fileName = $"{etudiant.NumeroEtudiant}.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Numéro: {etudiant.NumeroEtudiant}");
                writer.WriteLine($"Nom: {etudiant.Nom}");
                writer.WriteLine($"Prénom: {etudiant.Prenom}");
            }
        }
    }

    public void AfficherFichierEtudiant(int numeroEtudiant)
    {
        string fileName = $"{numeroEtudiant}.txt";
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Fichier non trouvé.");
        }
    }
}

public class GestionCours
{
    private List<Cours> cours = new List<Cours>();

    public void AjouterCours(Cours cours)
    {
        this.cours.Add(cours);
    }

    public void AfficherCours()
    {
        foreach (var cours in this.cours)
        {
            Console.WriteLine($"Numéro: {cours.NumeroCours}, Code: {cours.Code}, Titre: {cours.Titre}");
        }
    }
}

public class GestionNotes
{
    private List<Notes> notes = new List<Notes>();

    public void AjouterNotes(Notes note)
    {
        notes.Add(note);
    }

    public void AfficherNotes()
    {
        foreach (var note in notes)
        {
            Console.WriteLine($"Numéro Étudiant: {note.NumeroEtudiant}, Numéro Cours: {note.NumeroCours}, Note: {note.Note}");
        }
    }

    public List<Notes> TrouverNotesParEtudiant(int numeroEtudiant)
    {
        return notes.FindAll(n => n.NumeroEtudiant == numeroEtudiant);
    }

    public void EnregistrerNotes()
    {
        foreach (var note in notes)
        {
            string fileName = $"{note.NumeroEtudiant}_notes.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Numéro Étudiant: {note.NumeroEtudiant}");
                writer.WriteLine($"Numéro Cours: {note.NumeroCours}");
                writer.WriteLine($"Note: {note.Note}");
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        GestionEtudiants gestionEtudiants = new GestionEtudiants();
        GestionCours gestionCours = new GestionCours();
        GestionNotes gestionNotes = new GestionNotes();

        string choix;
        do
        {
            Console.WriteLine("Choisissez une option:");
            Console.WriteLine("1. Ajouter un étudiant");
            Console.WriteLine("2. Ajouter un cours");
            Console.WriteLine("3. Ajouter une note");
            Console.WriteLine("4. Afficher les étudiants");
            Console.WriteLine("5. Afficher les cours");
            Console.WriteLine("6. Afficher les notes");
            Console.WriteLine("7. Afficher le relevé de notes d'un étudiant");
            Console.WriteLine("8. Enregistrer les données");
            Console.WriteLine("9. Quitter");
            choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    try
                    {
                        Console.Write("Numéro d'étudiant: ");
                        int numeroEtudiant = int.Parse(Console.ReadLine());
                        Console.Write("Nom: ");
                        string nom = Console.ReadLine();
                        Console.Write("Prénom: ");
                        string prenom = Console.ReadLine();

                        Etudiant etudiant = new Etudiant(numeroEtudiant, nom, prenom);
                        gestionEtudiants.AjouterEtudiant(etudiant);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erreur: Veuillez entrer un numéro valide.");
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Write("Numéro du cours: ");
                        int numeroCours = int.Parse(Console.ReadLine());
                        Console.Write("Code: ");
                        string code = Console.ReadLine();
                        Console.Write("Titre: ");
                        string titre = Console.ReadLine();

                        Cours cours = new Cours(numeroCours, code, titre);
                        gestionCours.AjouterCours(cours);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erreur: Veuillez entrer un numéro valide.");
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Write("Numéro d'étudiant: ");
                        int numeroEtudiantNote = int.Parse(Console.ReadLine());
                        Console.Write("Numéro du cours: ");
                        int numeroCoursNote = int.Parse(Console.ReadLine());
                        Console.Write("Note: ");
                        double note = double.Parse(Console.ReadLine());

                        Notes notes = new Notes(numeroEtudiantNote, numeroCoursNote, note);
                        gestionNotes.AjouterNotes(notes);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erreur: Veuillez entrer des valeurs valides.");
                    }
                    break;

                case "4":
                    gestionEtudiants.AfficherEtudiants();
                    break;

                case "5":
                    gestionCours.AfficherCours();
                    break;

                case "6":
                    gestionNotes.AfficherNotes();
                    break;

                case "7":
                    try
                    {
                        Console.Write("Entrez le numéro de l'étudiant: ");
                        int numeroEtudiantReleve = int.Parse(Console.ReadLine());
                        Etudiant etudiantReleve = gestionEtudiants.TrouverEtudiant(numeroEtudiantReleve);
                        List<Notes> notesReleve = gestionNotes.TrouverNotesParEtudiant(numeroEtudiantReleve);

                        if (etudiantReleve != null)
                        {
                            Console.WriteLine($"Relevé de notes pour {etudiantReleve.Nom} {etudiantReleve.Prenom}:");
                            foreach (var noteReleve in notesReleve)
                            {
                                Console.WriteLine($"Cours: {noteReleve.NumeroCours}, Note: {noteReleve.Note}");
                            }
                            gestionEtudiants.AfficherFichierEtudiant(numeroEtudiantReleve);
                        }
                        else
                        {
                            Console.WriteLine("Étudiant non trouvé.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erreur: Veuillez entrer un numéro valide.");
                    }
                    break;

                case "8":
                    gestionEtudiants.EnregistrerEtudiants();
                    gestionNotes.EnregistrerNotes();
                    Console.WriteLine("Données enregistrées.");
                    break;

                case "9":
                    Console.WriteLine("Au revoir!");
                    break;

                default:
                    Console.WriteLine("Option invalide. Veuillez réessayer.");
                    break;
            }
        } while (choix != "9");
    }
}