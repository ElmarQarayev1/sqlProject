using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SqlProject
{
	public class BrandServices:Brands
	{
		public void BrandCreate()
		{
			Name:
			Console.WriteLine("brandin adini daxil edin:");

			string name = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(name))
			{
				Console.WriteLine("duzgun daxil edin!");
				goto Name;
			}
		Year:
			Console.WriteLine("brandin ilini daxil edin:");
			string DateTimeStr = Console.ReadLine();
			DateTime year;
			if(!DateTime.TryParse(DateTimeStr, out year))
			{
				Console.WriteLine("duzgun daxil edin!");
			}
			
			InsertBrands(name, year);

        }

        public void InsertBrands(string name,DateTime year)
		{
            string connectionStr = "Server=localhost;Database=products;User ID=sa;Password=reallyStrongPwd123;";

            using (SqlConnection connection = new SqlConnection(connectionStr))
			{
				connection.Open();
				string query = "insert into brands(NAME,YEAR) values (@name,@year)";
				using (SqlCommand command= new  SqlCommand(query,connection))
				{
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@year", year);
                    command.ExecuteNonQuery();
                }
			}
        }


		public void ShowALlBrands()
		{
			Console.WriteLine("All Brands");

			foreach (var item in GetAllGroups())
			{
				Console.WriteLine(item);

			}
		}
        public void ShowOneBrand()
        {
            Id:
            Console.WriteLine("Id daxil edin:");
            string idStr = Console.ReadLine();
            int id;

            if(!int.TryParse(idStr,out id))
            {

                Console.WriteLine("duzgun daxil edin!");
                goto Id;
            }
            var brand = GetBrandById(id);

            if (brand == null) Console.WriteLine("brand tapilmadi!");

            else Console.WriteLine(brand);
        }

		public List<Brands> GetAllGroups()
		{
			List<Brands> brands = new List<Brands>();

            string connectionStr = "Server=localhost;Database=products;User ID=sa;Password=reallyStrongPwd123;";

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select id,name,year from brands";
				SqlCommand command = new SqlCommand(query, connection);

				using (SqlDataReader sqlDataReader= command.ExecuteReader())
				{
                    while (sqlDataReader.Read())
                    {
                        Brands brands1 = new Brands
                        {
                            Id = sqlDataReader.GetInt32(0),
                            Name = sqlDataReader.GetString(1),
                            Year = sqlDataReader.GetDateTime(2)
                        };
                        brands.Add(brands1);
                    }
                }
				return brands;
                
            }
        }

        Brands GetBrandById(int id)
        {
            Brands brand = null;

            string connectionStr = "Server=localhost;Database=products;User ID=sa;Password=reallyStrongPwd123;";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select TOP(1) * from brands where Id=@id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader sqlReader = command.ExecuteReader())
                {
                    if (!sqlReader.HasRows) return null;
                    while (sqlReader.Read())
                    {
                        brand = new Brands();
                        brand.Id = sqlReader.GetInt32(sqlReader.GetOrdinal("Id"));
                       brand.Name = sqlReader.GetString(sqlReader.GetOrdinal("Name"));
                        brand.Year = sqlReader.GetDateTime(sqlReader.GetOrdinal("Year"));
                    }
                }
            }
            return brand;
        }
        
        public void DeleteOneBrand()
        {
        Id:
            Console.WriteLine("Id daxil edin:");
            string idStr = Console.ReadLine();
            int id;

            if (!int.TryParse(idStr, out id))
            {
                Console.WriteLine("duzgun daxil edin!");
                goto Id;
            }
           
                DeleteBrand(id);
            
        }
        public void DeleteBrand(int id)
        {
            string connectionStr = "Server=localhost;Database=products;User ID=sa;Password=reallyStrongPwd123;";

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "delete from brands where id=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                   
                    command.ExecuteNonQuery();
                }

            }
        }

        public void UptadeOneBrand()
        {
        Id:
            Console.WriteLine("deyismek istediyiniz id ni daxil edin:");
            string idStr = Console.ReadLine();
            int id;
            if(!int.TryParse(idStr,out id))
            {
                Console.WriteLine("duzgun daxil edin!");
                goto Id;
            }
            var brand = GetBrandById(id);
            if (brand == null) Console.WriteLine("sizin axtardiginiz brand tapilmadi!");
            else
            {
                Console.WriteLine("sizin deyisdireceyiniz id :" + GetBrandById(id));
            NewName:
                Console.WriteLine("yeni adini daxil edin:");
                string newName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    Console.WriteLine("duzgun daxil edin!");
                    goto NewName;
                }
                UptadeBrand(id, newName);
            }     
        }
        public void UptadeBrand(int id,string newName)
        {
            string connectionStr = "Server=localhost;Database=products;User ID=sa;Password=reallyStrongPwd123;";

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "update brands set name=@name where id=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name",newName);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}

