namespace alien_ship
{
    internal class Program
    {
        public static void find_ships(Alien_ship[] ships, int speed, int damage, bool friendly)
        {
            int x = 0;
            foreach (var ship in ships)
            {
                if (ship.Speed >= speed && ship.Damage >= damage && ship.Friendly == friendly)
                {
                    Console.WriteLine("\nName: " + ship.Name + "\nSpeed: " + ship.Speed + "\nDamage: " + ship.Damage + "\nFriendly: " + ship.Friendly);
                    x++;
                }
                
            }
            if(x==0)
            { Console.WriteLine("no ship found"); }// says if no ship is found fitting find_ship input

        }
        static void Main(string[] args)
        {

            Alien_ship[] ships = new Alien_ship[10];//array of 10 ships

            StreamReader file = new StreamReader("../../resources/ships.txt");//open streamreader
            {
                for (int i = 0; i < ships.Length; i++) //loop through the file storing groups to temp
                {
                    string tempName = file.ReadLine();
                    int tempHP = Convert.ToInt32(file.ReadLine());
                    int tempSpeed = Convert.ToInt32(file.ReadLine());
                    int tempDamage = Convert.ToInt32(file.ReadLine());
                    bool tempFriendly = Convert.ToBoolean(file.ReadLine());
                    ships[i] = new Alien_ship(tempName, tempHP, tempSpeed, tempDamage, tempFriendly);//instantiate new alienship from temp
                }
            }
            file.Close();//close the file

            find_ships(ships, 0,0,true);
        }
        
    }
    public class Space_object
    {
        public string Name { get; set; }//creates a way to get or set name
        public int Hit_points { get; set; }//creates a way to get or set HP
        public Space_object(string name, int hit_points)//creates space objects and its attributes
        {
            Name = name;
            Hit_points = hit_points;
        }
    }
    public class Alien_ship : Space_object// inherits all attributes from space object
    {
        public int Speed { get; set; }//creates a way to get or set speed
        public int Damage { get; set; }//creates a way to get or set damage
        public bool Friendly { get; set; }//creates a way to get or set whether its friendly or not

        public Alien_ship(string name, int hit_points, int speed, int damage, bool friendly)
            : base(name, hit_points)
        {
            Speed = speed;
            Damage = damage;
            Friendly = friendly;
        }
    }

}
