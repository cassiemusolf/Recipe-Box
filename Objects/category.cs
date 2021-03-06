using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBox
{
    public class Category
    {
        private int _id;
        private string _name;

        public Category(string Name, int Id = 0)
        {
            _id = Id;
            _name = Name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public override bool Equals(System.Object otherCategory)
        {
            if (!(otherCategory is Category))
            {
                return false;
            }
            else
            {
                Category newCategory = (Category) otherCategory;
                bool idEquality = (this.GetId() == newCategory.GetId());
                bool nameEquality = (this.GetName()== newCategory.GetName());
                return (idEquality && nameEquality);
            }
        }

        public static List<Category> GetAll()
        {
            List<Category> CategoryList = new List<Category>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM categories;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int categoryId = rdr.GetInt32(0);
                string categoryName = rdr.GetString(1);
                Category newCategory = new Category(categoryName, categoryId);
                CategoryList.Add(newCategory);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return CategoryList;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO categories(name) OUTPUT INSERTED.id VALUES (@Name);", conn);

            SqlParameter categoryNameParam = new SqlParameter("@Name", this.GetName());

            cmd.Parameters.Add(categoryNameParam);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }
        }

        public static Category Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd  = new SqlCommand("SELECT * FROM categories WHERE id= @CategoryId;", conn);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@CategoryId";
            idParam.Value = id.ToString();
            cmd.Parameters.Add(idParam);

            SqlDataReader rdr = cmd.ExecuteReader();

            int foundCategoryId = 0;
            string foundName = null;

            while(rdr.Read())
            {
                foundCategoryId = rdr.GetInt32(0);
                foundName = rdr.GetString(1);
            }

            Category foundCategory = new Category(foundName, foundCategoryId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return foundCategory;
        }

        public void Update(string newName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE categories SET name = @NewName OUTPUT INSERTED.name WHERE id = @CategoryId;", conn);

            SqlParameter newNameParameter = new SqlParameter();
            newNameParameter.ParameterName = "@NewName";
            newNameParameter.Value = newName;
            cmd.Parameters.Add(newNameParameter);

            SqlParameter idParameter = new SqlParameter();
            idParameter.ParameterName = "@CategoryId";
            idParameter.Value = this.GetId();
            cmd.Parameters.Add(idParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                this._name = rdr.GetString(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void AddRecipe(Recipe newRecipe)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd  =  new SqlCommand ("INSERT INTO categories_recipe (recipe_id,category_id) VALUES (@RecipeId, @CategoryId);",conn);

            SqlParameter categoryParameter = new SqlParameter("@CategoryId", this.GetId());
            SqlParameter recipeParameter = new SqlParameter ("@RecipeId", newRecipe.GetId());

            cmd.Parameters.Add(categoryParameter);
            cmd.Parameters.Add(recipeParameter);

            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }

        public List<Recipe> GetRecipe()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT recipe.* FROM categories JOIN categories_recipe ON (categories.id = categories_recipe.category_id) JOIN recipe ON(categories_recipe.recipe_id = recipe.id) WHERE categories.id = @CategoryId;", conn);

            SqlParameter categoryParameter = new SqlParameter("@CategoryId", this.GetId().ToString());
            cmd.Parameters.Add(categoryParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            List<Recipe> RecipeList = new List<Recipe>{};

            while(rdr.Read())
            {
                int matchedRecipeId = rdr.GetInt32(0);
                string matchedrecipeName = rdr.GetString(1);
                string matchedIngredient = rdr.GetString(2);
                string matchedInstructions = rdr.GetString(3);
                string matchedCookTIme =  rdr.GetString(4);
                int matchedRating = rdr.GetInt32(5);
                string matchedUrl = rdr.GetString(6);
                Recipe newRecipe = new Recipe(matchedrecipeName, matchedIngredient, matchedInstructions, matchedCookTIme, matchedRating, matchedUrl, matchedRecipeId);
                RecipeList.Add(newRecipe);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return RecipeList;
        }

        public void DeleteCategory()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM categories WHERE id = @CategoryId;", conn);

            cmd.Parameters.Add(new SqlParameter("@CategoryId", this.GetId()));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM categories;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
