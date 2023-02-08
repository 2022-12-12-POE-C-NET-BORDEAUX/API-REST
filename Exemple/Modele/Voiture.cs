public class Voiture
{
	public string Marque { get; set; }
	public string Modele { get; set; }
	public string Couleur { get; set; }

	public Voiture()
	{

	}

	public Voiture(string marque, string modele, string couleur)
	{
		Marque = marque;
		Modele = modele;
		Couleur = couleur;
	}
}
