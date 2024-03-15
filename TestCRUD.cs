using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cat.itb.M6UF1EA3_MolanoArnau;

public class TestCRUD
{
    public static void MostrarDocumentosJSON() //mostrar el contingut JSON indented EX1
    {
        string filePath = @"../../../JSON/people.json";

        try
        {      
            string jsonContent = File.ReadAllText(filePath);

           
            JArray peopleArray = JArray.Parse(jsonContent);

            
            foreach (JObject person in peopleArray)
            {
                Console.WriteLine(person.ToString(Newtonsoft.Json.Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
        }

    }

    public static void AgregarAmigoJuliaYoung() //Agefeix un subdocument amb id 4 i camp name = Trinity Ford al camp friends de la persona Julia Young 
    {
        string filePath = @"../../../JSON/people.json";

        try
        {
            // Lee el contenido del archivo JSON
            string jsonContent = File.ReadAllText(filePath);

            // Parsea el contenido JSON
            JArray peopleArray = JArray.Parse(jsonContent);

            // Busca la persona llamada "Julia Young"
            JObject juliaYoung = null;
            foreach (JObject person in peopleArray)
            {
                if (person["name"].ToString() == "Julia Young")
                {
                    juliaYoung = person;
                    break;
                }
            }

            if (juliaYoung != null)
            {
                // Agrega un nuevo amigo al campo "friends" de Julia Young
                JObject nuevoAmigo = new JObject();
                nuevoAmigo["id"] = 4;
                nuevoAmigo["name"] = "Trinity Ford";
                juliaYoung["friends"].Last.AddAfterSelf(nuevoAmigo);
            }
            else
            {
                Console.WriteLine("No se encontró a Julia Young en el archivo JSON.");
                return;
            }

            // Escribe el archivo JSON modificado
            File.WriteAllText(filePath, JsonConvert.SerializeObject(peopleArray, Newtonsoft.Json.Formatting.Indented));
            Console.WriteLine("Se ha añadido un nuevo amigo a Julia Young en el archivo JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al modificar el archivo JSON: {ex.Message}");
        }


    }

    //Ex3

    public static void GuardarAdultsEnJSON()
    {
        string filePath = @"../../../JSON/people.json";
        string outputFilePath = "../../../JSON/adultPeopleArray.json";

        try
        {
            //Llegeix el contingut del fitxer JSON
            string jsonContent = File.ReadAllText(filePath);

            //Parseja el contingut JSON
            JArray peopleArray = JArray.Parse(jsonContent);

            //Filtrar les persones de mes de 25 anys
            JArray adultPeople = new JArray();
            foreach (JObject person in peopleArray)
            {
                int age = person["age"].Value<int>();
                if (age > 25)
                {
                    adultPeople.Add(person);
                }
                
            }

            //Guarda el select en un JSON nou
            File.WriteAllText(outputFilePath, adultPeople.ToString(Newtonsoft.Json.Formatting.Indented));
            Console.WriteLine("S'han guardat les persones majors de 25 a un nou JSON.");


        }catch (Exception ex)
        {
            Console.WriteLine($"Error al modificar el archivo JSON: {ex.Message}");
        }

    }

    /*Del fitxer "people.json" selecciona totes les persones que en el camp "randomArrayItem" tingui el valor
     "teacher". Guarda aquestes persones en un fitxer fitxer JSON anomenat "teachers.json". Els documents
     d’aquest fitxer JSON han d’estar dins d’un Array.*/

    public static void GuardarTeachersEnJSON()
    {

        string filePath = @"../../../JSON/people.json";
        string outputFilePath = "../../../JSON/teachers.json";

        try
        {
            //Llegeix el contingut del fitxer JSON
            string jsonContent = File.ReadAllText(filePath);

            //Parseja el contingut JSON
            JArray peopleArray = JArray.Parse(jsonContent);

            //Filtrar les persones de mes de 25 anys
            JArray teachers = new JArray();
            foreach (JObject person in peopleArray)
            {
                string randomArrayItem = person["randomArrayItem"].Value<string>();
                if (randomArrayItem == "teacher")
                {
                    teachers.Add(person);
                }

            }

            //Guarda el select en un JSON nou
            File.WriteAllText(outputFilePath, teachers.ToString(Newtonsoft.Json.Formatting.Indented));
            Console.WriteLine("S'han guardat les persones amb randomArrayItem = teacher a un nou JSON.");
        }

    }


}
