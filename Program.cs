// the ourAnimals array will store the following: 
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6]; // declaracion de la matriz, no esta inicilaizada.

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:

            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;


        case 2:

            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:

            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default: //Después de la cuarta iteración, a todas las características se les asigna una cadena vacía o de longitud cero.

            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }
    // inicicializa los valores de la matriz
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

// display the top-level menu options
do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // Console.WriteLine($"You selected menu option {menuSelection}.");
    // Console.WriteLine("Press the Enter key to continue");

    // // pause code execution
    // readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ") // Esto indica que el bloque de código se ejecutará cuando el animal actual 
                                                  //tenga características definidas.
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);

                    }
                }

            }

            Console.WriteLine("Press enter the key to continue");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;

                } // me va contar el numero de animales que tengo.

            }
            Console.WriteLine(petCount);

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            // escribir nuevos datos en la matriz ourAnimals
            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validentry = false;
                do
                {
                    Console.WriteLine("\n\rEnter a 'Dog' or 'Cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                    }
                    if (animalSpecies.Contains("dog") || (animalSpecies.Contains("cat")))
                    // if (animalSpecies != "dog" && animalSpecies != "cat") de esta forma debo agregar otra linea para validentry = false
                    {
                        validentry = true;
                    }

                } while (!validentry);

                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                Console.WriteLine(animalID);

                // get the pet's age. can be ? at initial entry.
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or ? if unknown");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalAge = readResult;
                    }

                    if (animalAge != "?")
                    {
                        validentry = int.TryParse(animalAge, out petAge);

                    }
                    else
                    {
                        validentry = true;
                    }

                } while (!validentry);

                do
                {
                    Console.WriteLine("Enter a Physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }

                    }

                } while (animalPhysicalDescription == "");
                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("enter a description of the pet's personality (like or dislike tricks)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPersonalityDescription == "");
                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine(" enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (animalNickname == "");
                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount++; Console.WriteLine(petCount); //es para imprimir petcount y comprobar codigo
                if (petCount < maxPets) // comprueba si tengo espacio para otras mascotas
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("we have reached our limits on the number of pets that we can manage");
                Console.WriteLine("Press enter the key to continue");
                readResult = Console.ReadLine();
            }
            
            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete
            Console.WriteLine("Challenge project -  Please check back to see the progress.");
            Console.WriteLine("Press enter the key to continue");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            Console.WriteLine("Challegnge project -  Please check back to see the progress.");
            Console.WriteLine("Press enter the key to continue");
            readResult = Console.ReadLine();
            break;

        case "5":
            //Edit an animal’s age
            Console.WriteLine("Under construction is cooming soon -  Please check back to see the progress.");
            Console.WriteLine("Press enter the key to continue");
            readResult = Console.ReadLine();
            break;

        case "6":
            //Edit an animal’s personality description
            Console.WriteLine("Under construction is cooming soon -  Please check back to see the progress.");
            Console.WriteLine("Press enter the key to continue");
            readResult = Console.ReadLine();
            break;

        case "7":
            //Display all cats with a specified characteristic
            Console.WriteLine("Under construction is cooming soon -  Please check back to see the progress.");
            Console.WriteLine("Press enter the key to continue");
            readResult = Console.ReadLine();
            break;

        case "8":
            //Display all dogs with a specified characteristic
            Console.WriteLine("Under construction is cooming soon -  Please check back to see the progress.");
            Console.WriteLine("Press enter the key to continue");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit"); // si se escribe "exit" esto se evalua conmo false y se rompe el ciclo.