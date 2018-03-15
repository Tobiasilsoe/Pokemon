using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Move> moves = new List<Move>();
            moves.Add(new Move("Ember"));
            moves.Add(new Move("Fireblast"));
            moves.Add(new Move("Bubble"));
            moves.Add(new Move("Bite"));
            moves.Add(new Move("Cut"));
            moves.Add(new Move("mega drain"));
            moves.Add(new Move("Razorleaf"));

            List<Pokemon> roster = new List<Pokemon>();
            roster.Add(new Pokemon("Charmander", 3, 52, 43, 39, Elements.Fire, moves.GetRange(0,2) ));
            roster.Add(new Pokemon("Squirtle", 2, 48, 65, 44, Elements.Water, moves.GetRange(2,2) ));
            roster.Add(new Pokemon("Bulbasaur", 3, 49, 49, 45, Elements.Grass, moves.GetRange(4,3) ));


            // INITIALIZE YOUR THREE POKEMONS HERE

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlease enter a command");
                switch (Console.ReadLine())
                {
                    case "list":

                        foreach (Pokemon Pokemon in roster)
                        {
                            Console.WriteLine("{0}", Pokemon.Name);
                        }
                        // PRINT THE POKEMONS IN THE ROSTER HERE
                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.Write("Choose who should fight - Charmander Squirtle Bulbasaur \n You have to choose two pokemons ");

                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();
                        Regex regex = new Regex("(?<pokemonOne>(Charmander|Squirtle|Bulbasaur)) (?<pokemonTwo>(Charmander|Squirtle|Bulbasaur))");
                        
                        Match match = regex.Match(input);
                        Console.WriteLine(match.Groups["pokemonOne"].Value);
                        Console.WriteLine(match.Groups["pokemonTwo"].Value);



                        if (match.Groups["pokemonOne"].Value != match.Groups["pokemonTwo"].Value && match.Success)
                        {

                           
                            //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                          
                          
                            
                            Pokemon enemy = null;
                            Pokemon player = null;
                            string pokemon1 = match.Groups["pokemonOne"].Value;
                            string pokemon2 = match.Groups["pokemonTwo"].Value;
                           
                            player = roster.Find(x => x.Name == pokemon1);
                            enemy = roster.Find(x => x.Name == pokemon2);


                            //if everything is fine and we have 2 pokemons let's make them fight
                            if (player != null && enemy != null && player != enemy)
                            {
                                Console.WriteLine("A wild " + enemy.Name + " appears!");
                                Console.Write(player.Name + " I choose you! ");
                                var move = -1;
                                //BEGIN FIGHT LOOP
                                while (player.Hp > 0 && enemy.Hp > 0)
                                {
                                    //PRINT POSSIBLE MOVES
                                    bool toggle = true;
                                    while (toggle)
                                    {
                                        
                                        Console.Write("What move should we use? (");
                                        Console.WriteLine("Write the number you want for your attack");
                                        if (pokemon1 == "Charmander")
                                        {
                                            for (int i = 0; i < player.Moves.Count; i++)
                                            {
                                                Console.WriteLine(player.Moves[i].Name + " {0}", i);

                                            }
                                            string attackInput = Console.ReadLine();
                                            if (attackInput == "0" || attackInput == "1")
                                            {
                                               
                                                toggle = false;
                                                if (attackInput == "0")
                                                {
                                                    move = 0;
                                                }
                                                else if (attackInput == "1")
                                                {
                                                    move = 1;
                                                }
                                            }
                                        }
                                        else if (pokemon1 == "Squirtle")
                                        {
                                            for (int i = 0; i < player.Moves.Count; i++)
                                            {
                                                Console.WriteLine(player.Moves[i].Name + " {0}", i);
                                            }
                                            string attackInput = Console.ReadLine();
                                            if (attackInput == "0" || attackInput == "1")
                                            {
                                                
                                                toggle = false;
                                                if (attackInput == "0")
                                                {
                                                    move = 0;
                                                }
                                                else if (attackInput == "1")
                                                {
                                                    move = 1;
                                                }
                                            }
                                        }
                                        else if (pokemon1 == "Bulbasaur")
                                        {
                                            for (int i = 0; i < player.Moves.Count; i++)
                                            {
                                                Console.WriteLine(player.Moves[i].Name + " {0}", i);
                                            }
                                            string attackInput = Console.ReadLine();
                                            if (attackInput == "0" || attackInput == "1"||attackInput == "2")
                                            {
                                                
                                                if(attackInput == "0")
                                                {
                                                    move = 0;
                                                }
                                                else if (attackInput == "1")
                                                {
                                                    move = 1;
                                                }else if (attackInput == "2")
                                                {
                                                    move = 2;
                                                }
                                                    toggle = false;
                                            }
                                        }
                                    }
                                    enemy.ApplyDamage(player.Attack(enemy));

                                    int damage = player.Attack(enemy);

                                    


                                    //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                    
                                    
                                    //CALCULATE AND APPLY DAMAGE
                                    //int damage = -1;

                                    //print the move and damage
                                    Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");

                                    //if the enemy is not dead yet, it attacks
                                    if (enemy.Hp > 0)
                                    {
                                        //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                        Random rand = new Random();
                                        /*the C# random is a bit different than the Unity random
                                         * you can ask for a number between [0,X) (X not included) by writing
                                         * rand.Next(X) 
                                         * where X is a number 
                                         */
                                        int enemyMove= -1;

                                        if(pokemon2 == "Charmander")
                                        {
                                            int enemyMove1 = rand.Next(0, 2);
                                            if (enemyMove1 == 0)
                                            {
                                                enemyMove = 0;
                                            }else if(enemyMove1 == 1)
                                            {
                                                enemyMove = 1;
                                            }
                                        }else if (pokemon2 == "Squirtle")
                                        {
                                            int enemyMove1 = rand.Next(0, 2);
                                            if (enemyMove1 == 0)
                                            {
                                                enemyMove = 0;
                                            }
                                            else if (enemyMove1 == 1)
                                            {
                                                enemyMove = 1;
                                            }
                                        }
                                        else if (pokemon2 == "Bulbasaur")
                                        {
                                            int enemyMove1 = rand.Next(0, 3);
                                            if (enemyMove1 == 0)
                                            {
                                                enemyMove = 0;
                                            }
                                            else if (enemyMove1 == 1)
                                            {
                                                enemyMove = 1;
                                            }
                                            else if (enemyMove1 == 2)
                                            {
                                                enemyMove = 2;
                                            }
                                        }


                                        int enemyDamage = enemy.Attack(player);
                                        player.ApplyDamage(enemy.Attack(player));

                                        //print the move and damage
                                        Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                    }
                                }
                                //The loop is over, so either we won or lost
                                if (enemy.Hp <= 0)
                                {
                                    Console.WriteLine(enemy.Name + " faints, you won!");
                                }
                                else
                                {
                                    Console.WriteLine(player.Name + " faints, you lost...");
                                }
                            }
                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER
                        foreach (Pokemon Pokemon in roster)
                        {
                            Pokemon.Restore();
                        }
                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
