using UnityEngine;
using SQLite4Unity3d;
using System.IO;

public class DataService
{
    private SQLiteConnection _connection;

    public DataService(string DatabaseName)
    {
        var dbPath = Path.Combine(Application.streamingAssetsPath, DatabaseName);
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Database path: " + dbPath);
    }


    public void CreateDB()
    {
        _connection.DropTable<Attempt>();
        _connection.CreateTable<Attempt>();
    }

    public void AddAttempt(bool isCorrect)
    {
        var newAttempt = new Attempt
        {
            Correct = isCorrect ? 1 : 0,
            Incorrect = isCorrect ? 0 : 1
        };
        _connection.Insert(newAttempt);
    }
}

public class Attempt
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int Correct { get; set; }
    public int Incorrect { get; set; }
}
