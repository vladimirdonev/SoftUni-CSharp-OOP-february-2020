namespace WildFarm.Models
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
           
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract void Feed(Food food);

        public abstract string AnimalSound();
        
    }
}
