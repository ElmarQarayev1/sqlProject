using System;
namespace SqlProject
{
	public class Brands
	{
		public Brands()
		{
			_id++;
			Id = _id;
		}
		private static int _id;
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Year { get; set; }

        public override string ToString()
        {
			return $"{Id} {Name} {Year}";
        }
    }
}

