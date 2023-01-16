using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConatctApi_CRUD.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private List<Contact> contacts = new List<Contact> 
		{
			new Contact { Id = 1,FirstName="Ibrahim", LastName="Mohamed", ContactNo="659028688"},
			new Contact { Id = 2,FirstName="Ahmed", LastName="Jama", ContactNo="65476343"},
			new Contact { Id = 3,FirstName="Saed", LastName="Ali", ContactNo="98765432"}
		};

		[HttpGet]
		public ActionResult<List<Contact>> GetAll() 
		{
			// This will return all the objects in the list 
			return Ok(contacts);
		}

		[HttpGet("GetContactById/{id}")]
		public ActionResult<Contact> Get(int id) 
		{ 
			//1st we need to the get the object by the id
			var contact = contacts.Find(x => x.Id == id);

			//if the contact result id null we need to check it 1st 
			if (contact is null)
				return BadRequest("no contact found");

			//Then we will return the contact that we found 
			return Ok(contact);
		}

		[HttpPost]
		public ActionResult<List<Contact>> CreateContact(Contact contact)
		{
			//Adding new contact to our list 
			contacts.Add(contact);

			//return the list of the objects after adding the new object
			return Ok(contacts);
		}

		[HttpDelete("DeleteContact/{id}")]
		public ActionResult<List<Contact>> DeleteContact(int id) 
		{
			//we need to find the object that we want to delete 
			var contctToDelete = contacts.Find(x => x.Id == id);
			//then we need to check if the object is null and return a proper error
			if (contctToDelete == null)
				return BadRequest("no contact found");
			//we need to remove the object from the list 
			contacts.Remove(contctToDelete);
			//Then we will return the remaing objects
			return Ok(contacts);
		}
		
		
	}
}
