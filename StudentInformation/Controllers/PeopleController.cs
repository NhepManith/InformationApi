using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentInformation.Models;

namespace StudentInformation.Controllers
{
    [Route("api/[controller]")]

    [ApiController]


    public class PeopleController : ControllerBase
    {
        public static List<Person> _people = new List<Person>()
        {
            new Person{Id=0, Age=23, Name="Manith" , Email="manithnhep59@gmail.com"}
        };



        [HttpGet]

        public ActionResult<IEnumerable<Person>> GetAllPeople()
        {
            return _people;

        }

        [HttpGet("{id}")]

        public ActionResult<Person> GetPeopleByID(int id)
        {
            var findPeoplebyId = _people.FirstOrDefault(p => p.Id == id);
            if (findPeoplebyId == null)
            {
                return NotFound();
            }
            else
            {
                return findPeoplebyId;
            }
        }

        [HttpPost]

        public ActionResult<Person> AddNewPeople(Person Newpeople)
        {
            Newpeople.Id = _people.Count + 0;
            _people.Add(Newpeople);

            return CreatedAtAction(nameof(AddNewPeople), new { id = Newpeople.Id }, Newpeople);

        }

        [HttpPut("{id}")]
        public ActionResult<Person> UpdateInformation (int id, Person UpdateInformation)
        {
            var UpdateInfo = _people.FirstOrDefault(p => p.Id == id);
            if (UpdateInfo == null)
            {
                return NotFound();

            }

            UpdateInfo.Id = UpdateInformation.Id;
            UpdateInfo.Name = UpdateInformation.Name;
            UpdateInfo.Age = UpdateInformation.Age;
            UpdateInfo.Email = UpdateInformation.Email;

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Person> DeletePersonByiD ( int id)
        {
            var DeletByid = _people.FirstOrDefault(d => d.Id == id);

            if(DeletByid == null)
            {
                return NotFound();
            }
            else
            {
                _people.Remove(DeletByid);
                return DeletByid;
            }

        }



    }




    



}
