using System.Data.SqlClient;


string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-videogames;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);


try
{
    connessioneSql.Open();
    string insertQuery = "INSERT INTO videogames (name, overview,release_date,software_house_id) VALUES (@name, @overview,@release_date,1)";

    SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

    insertCommand.Parameters.Add(new SqlParameter("@name", "MonkeyIsland"));
    insertCommand.Parameters.Add(new SqlParameter("@overview", "bellissimo"));
    insertCommand.Parameters.Add(new SqlParameter("@release_date", DateTime.Today));


    int affectedRows = insertCommand.ExecuteNonQuery();

}catch(Exception e)
{
    Console.WriteLine(e.Message);
        
}
finally
{
    connessioneSql.Close();
}


return;











try
{
    connessioneSql.Open();

    Console.WriteLine("inserisci l'id del videogame:");
    int id = Convert.ToInt32(Console.ReadLine());

    string query = "SELECT * FROM videogames where id=@Id";

    // creo il comando ed eseguo la query
    SqlCommand cmd = new SqlCommand(query, connessioneSql);
    cmd.Parameters.Add(new SqlParameter("@Id", id));
   
    //reader 
    SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        string nome = reader.GetString(1);
        Console.WriteLine(nome);
    }
  

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    connessioneSql.Close();
}
