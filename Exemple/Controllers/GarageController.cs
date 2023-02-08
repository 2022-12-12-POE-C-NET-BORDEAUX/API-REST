using Microsoft.AspNetCore.Mvc;

namespace Exemple.Controllers;

[ApiController]
[Route("Nicolas")]
public class GarageController : ControllerBase
{
	public static List<Voiture> Voitures = new List<Voiture>(){
				new Voiture("Ford", "Mustang", "Rouge"),
				new Voiture("Renault", "Clio", "Bleu"),
				new Voiture("Peugeot", "308", "Noir"),
				new Voiture("Citroen", "C3", "Blanc"),
				new Voiture("Fiat", "Panda", "Vert"),
	};

	public GarageController()
	{
	}


	[HttpGet]
	public List<Voiture> Get()
	{
		return Voitures;// URL
	}

	[HttpGet]
	[Route("{id}")]
	public Voiture Get(int id)
	{
		return Voitures[id - 1];
	}

	[HttpPost]
	public List<Voiture> Post(Voiture tmp)
	{
		Voitures.Add(tmp);
		return Voitures;
	}

	[HttpPut]
	[Route("{id}")]
	public Voiture Put(int id, [FromBody] Voiture tmp)
	{
		//selectionner la voiture a modifier
		Voitures[id - 1] = tmp;
		return Voitures[id - 1];
	}

	[HttpDelete]
	[Route("{id}")]
	public string Delete(int id)
	{
		Voitures.RemoveAt(id - 1);
		return "Voiture supprimée";
	}

}
