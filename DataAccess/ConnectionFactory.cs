
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess;
public class ConnectionFactory
{
    private static ConnectionFactory? _instance;
    private readonly string _connectionString;

    private ConnectionFactory(string connectionstring)
    {
         _connectionString = connectionstring;
    }

    //getter for one and only instance of ConnectionFactory
    public static ConnectionFactory GetInstance(string connectionstring)
    {
        //chek if its already made
        if(_instance == null)
        {
            _instance = new ConnectionFactory(connectionstring);
        }  
        
        return _instance;
    }

    public SqlConnection GetConnection()
    {
        
        return new SqlConnection(_connectionString);
        
    }
}
