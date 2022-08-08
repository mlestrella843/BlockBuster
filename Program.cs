using System;
using System.Collections.Generic;
using System.Linq;

namespace Activity_4
{
    // TODO Create VHSTape class
    public class VHSTape
    {
        public string _name;
        public float _length;
        public bool _rented;
        public float _duration;

        //OTHER VARIABLES 
        float result_play = 0;
        float result_rewind = 0;
        float variable;
        int contador = 0;

        public VHSTape(string name, float length)
        { //initialize constructor function for VHSTape objects
            _name = name;
            _length = length;
           
        }

        /*
        public void ShowInfo()
        {
            Console.WriteLine("el nombre de la pelicula es: " + _name + " y la duracion es: " + _length);
        }
        */


        public void Play(float duration)
        {
            //define method to play a movie, if duration is longer than movie length, stop at the Length of the movie.
  
                _duration = duration;

                result_play = result_play + _duration;

            if (result_play < _length)
            {              
                _duration = result_play;
 
                //  Console.WriteLine(_name + " " + _duration);   ////DESACTIVATED OUTPUT 
            }

            else if (result_play > _length)
            {              
                _duration = _length;
             
                result_play = _length;

                //  Console.WriteLine(_name + " " + _duration);  ///DESACTIVATED OUTPUT 
            }

        }


        public void Rewind(float duration)
        {
            //define method for rewinding. If rewind results play time negative, stop at start of the movie, i.e. stop at "0.0" position.

            _duration = duration;

              if (contador == 0)
             {
            //result = _length - _duration; //LO ACABO DE DESACTIVAR

                result_rewind = result_play - _duration; //LO ACABO DE DESACTIVAR

                if (result_rewind > 0)
                { 
                    variable = result_rewind;
                    _duration = variable;

              
                    contador = contador + 1;

               
                    //  Console.WriteLine(_name + " " + _duration);  ///DESACTIVATED OUTPUT 
                }

                else if (result_rewind < 0)
                {
                    _duration= 0;
                    contador = contador + 1;
                  
               
                  //Console.WriteLine(_name + " " + _duration);  //DESACTIVATED OUTPUT 
                }

            }

            
            if (contador !=0)
            {

                result_rewind = variable - _duration;

                if (result_rewind > 0)
                {
                    variable = result_rewind;
                    _duration = variable;
                    contador = contador + 1;
                    
                  //  Console.WriteLine(_name + " " + _duration);   //DESACTIVATED OUTPUT 
                }

                else if (result_rewind < 0)
                {
                    _duration = 0;
                    contador = contador + 1;

                // Console.WriteLine(_name + " " + _duration);    //DESACTIVATED OUTPUT
                }

            }           
            
        }


        public void SetRented(bool rented)
        {
            //set a movie as rented by changing a boolean field value.
            _rented = rented;
            
        }

 }



    public class Blockbuster

    {

        //define necessary properties for fields and the lists to track movies is already defined for you.

        public string _address;

        public List<VHSTape> Movies = new List<VHSTape>();

        public Blockbuster(string address)
        {
            //initialize store address
            _address = address;
        }


        public void ShowBlockbuster()
        {
            Console.WriteLine("Direccion de la tienda: " + _address);
        }

        /* METHOD THAT I MADE TO SHOW THE VHSTAPE LIST
        public void ShowList()
        {
            foreach (var movieslist in Movies)
            {
                Console.WriteLine("In the list there are: " + movieslist._name  + " and her lenght are: " + movieslist._length);
            }
        }
        */


        public void AddMovie(VHSTape movie)
        {
            //Store adds a 'movie' type. So add the move to a list. (Store's movie list)

            Movies.Add(movie);

            foreach (var movieslist in Movies)
            {
                //  Console.WriteLine("The name of movie " + movieslist._name + " was added " + " length: " + movieslist._length); ////DESACTIVATED OUTPUT 
            }

        }


        public bool HasMovie(string name)
        {
            //Look for a movie name in the list of moves of the store.
            bool have = false;

            foreach (var movieslist in Movies)
            {
                if (movieslist._name == name)
                {
                    have = true;
                    //  Console.WriteLine("The movie " + name + "  exist in the store "); ////DESACTIVATED OUTPUT 
                }

            }

            return have;
        }


        public bool IsMovieAvailable(string name)
        {
            //check if movie is available. A movie is available if store have the movie in it's list and it is not rented yet.

            bool available = false;

            foreach (var movieslist in Movies)
            {
                if ( (movieslist._name == name) && (movieslist._rented == false) )
                {
                    available = true;

                    return available;
                }

                else if ((movieslist._name == name) && (movieslist._rented == true))
                {
                    //  Console.WriteLine("The movie" + movieslist._name + " is not available METHODS " + " return: " + available); ///DESACTIVATED OUTPUT 
                }
            }
            return available;

        }


        public VHSTape Rent(string name)
        {
            //In order to rent a movie, find the movie in store's movie list. If movie is there and not rented yet, set rent status True.
            //Otherwise, return null.
            foreach (var movieslist in Movies)
            {
                if (movieslist._name == name && movieslist._rented == false)
                {
                    movieslist.SetRented(true);
                 
                    return movieslist;
                }
            }
            return null;
        }



        public void Return(string name)
        {
            //In order to return a movie, find the movie in store's movie list. If movie is there and rent status is true, set rent status False.

            foreach (var movieslist in Movies)

            {
                if (movieslist._name == name && movieslist._rented == true)
                {
                    movieslist._rented = false;
                }

            }

        }



        public VHSTape GetRented(string name)
        {
            //This method returns already rented movie for playing or helping the Return method.     

            foreach (var movieslist in Movies)
            {
                //give logic to check if 'name' is in the list 'Movies' and the movie is already rented. 

                if (movieslist._name == name && movieslist._rented == true)
                {
                    return movieslist;
                }
            }
            return null;

        }

    }



    class Program
    {
        static void Main(string[] args)

        {
            var store = new Blockbuster("Calgary, Alberta, Canada.");
            string command = "";
            while (command != "exit")
            {
                command = Console.ReadLine();
                var cmdArgs = command.Split();
                if (cmdArgs.Length == 0)
                    continue;

                if (cmdArgs[0] == "add")
                {
                    var name1 = string.Join(" ", cmdArgs.Skip(1).Take(cmdArgs.Length - 2));
                    var length1 = float.Parse(cmdArgs.Last());
                    // TODO Make new VHSTape object and add it to store

                    VHSTape pelicula1 = new VHSTape(name1, length1);

                    store.AddMovie(pelicula1);
                  //  store.ShowList();

                }


                else if (cmdArgs[0] == "find")
                {
                    var name = string.Join(" ", cmdArgs.Skip(1).Take(cmdArgs.Length - 1));
                    bool hasMovie; // TODO Set hasMovie to indicate if store has the given movie

                    hasMovie = store.HasMovie(name);

                    if (hasMovie)
                    {
                        Console.WriteLine("Store has " + name);          
                    }
                    else
                    {  
                        Console.WriteLine("Store doesn't have " + name);
                    }
                }


                else if (cmdArgs[0] == "available")
                {
                    var name = string.Join(" ", cmdArgs.Skip(1).Take(cmdArgs.Length - 1));
                    bool available;// TODO Set available to indicate if store has the movie available to rent

                    available = store.IsMovieAvailable(name);

                    if (available)
                    {
                        Console.WriteLine(name + " is available" );
                    }
                    else
                    {
                        Console.WriteLine(name + " is rented");
                    }
                }


                 else if (cmdArgs[0] == "rent")
                {
                    var name = string.Join(" ", cmdArgs.Skip(1).Take(cmdArgs.Length - 1));
                    VHSTape movie; //=Call your store's rent function and save the object in the movie variable

                    movie = store.Rent(name);

                    Console.WriteLine(name + " is " + (movie._rented? "rented" : "available"));
                }



                else if (cmdArgs[0] == "play")
                {
                    var name = string.Join(" ", cmdArgs.Skip(1).Take(cmdArgs.Length - 2));
                    var duration = float.Parse(cmdArgs.Last());
                    var movie = store.GetRented(name);

                    store.GetRented(name);

                    // TODO Call your VHSTape's play function

                    movie.Play(duration);

                    Console.WriteLine(movie._name + ": " + movie._duration);

                }


                else if (cmdArgs[0] == "rewind")
                {
                    var name = string.Join(" ", cmdArgs.Skip(1).Take(cmdArgs.Length - 2));
                    var duration = float.Parse(cmdArgs.Last());
                    var movie = store.GetRented(name);
                    // TODO Call your VHSTape's rewind function

                    movie.Rewind(duration);


                    Console.WriteLine(movie._name + ": " + movie._duration);
                }

                else if (cmdArgs[0] == "return")
                {
                    var name = string.Join(" ", cmdArgs.Skip(1).Take(cmdArgs.Length - 1));
                    var movie = store.GetRented(name);
                    // TODO Call your store's return function with the given movie name

                    store.Return(name);

                    Console.WriteLine(name + ": " + (movie._rented ? "rented" : "available"));
                }

                //Console.ReadKey();




                /* PROOF OF METHODS
                 * 
                 * 
                 * 
                 *          //Console.WriteLine("this is a Complete List");
                            //store.ShowList();

                            //Instation of a new Blockbuster in Alberta
                            Blockbuster tienda1 = new Blockbuster("Calgary, Alberta, Canada");

                            //Instation of three movies
                            VHSTape pelicula1 = new VHSTape("SpongeBob", 23);
                            VHSTape pelicula2 = new VHSTape("Al Paccino and The Goodfather", 45);
                            VHSTape pelicula3 = new VHSTape("Alice in the Wonderland", 30);

                            //variable type bool for status for Rent or not
                            bool status = false;

                            ////////// PROOF OF METHODS OF CLASS VHSTAPE///////////
                            pelicula1.ShowInfo();
                            tienda1.ShowBlockbuster();

                            Console.WriteLine("  ");

                            pelicula2.ShowInfo();
                            tienda1.ShowBlockbuster();

                            Console.WriteLine("  ");

                            pelicula3.ShowInfo();
                            tienda1.ShowBlockbuster();


                            Console.WriteLine("  ");
                            //Method PLAY
                            pelicula1.Play(23);
                            pelicula2.Play(45);
                            pelicula3.Play(30);

                            Console.WriteLine("  ");
                            //METHOD REWIND
                            pelicula3.Rewind(30);

                            //METHOD SET RENTED
                            Console.WriteLine("  ");
                            pelicula3.SetRented(status);

                            ////////////PROOF OF METHODS OF CLASS BLOCKBUSTER///////////

                            //METHOD ADD MOVIE
                            Console.WriteLine("  ");
                            tienda1.AddMovie(pelicula1);
                            Console.WriteLine("  ");
                            tienda1.AddMovie(pelicula2);
                            Console.WriteLine("  ");
                            tienda1.AddMovie(pelicula3);

                            //METHOD HAS MOVIE
                            Console.WriteLine("  ");
                            tienda1.HasMovie("SpongeBob");


                            //METHOD IS AVAILABLE?
                            Console.WriteLine("  ");
                            tienda1.IsMovieAvailable("Alice in the Wonderland");

                            //METHOD RENT
                            Console.WriteLine("  ");
                            tienda1.Rent("Alice in the Wonderland");

                            //METHOD SET RENTED
                            Console.WriteLine("  ");
                            pelicula3.SetRented(status);


                            //METHOD RENT
                            Console.WriteLine("  ");
                            tienda1.Rent("Alice in the Wonderland");


                            //METHOD GET RENT
                            Console.WriteLine("  ");
                            tienda1.GetRented("Alice in the Wonderland");


                */









            }


        }


    }


}