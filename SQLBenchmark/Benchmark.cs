
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace SQLBenchmark;

[SimpleJob(RunStrategy.Throughput, iterationCount: 10, warmupCount: 1, id: "SqlBenchmarks")]
public class Benchmark
{
    private readonly IConfiguration _iConfiguration;

    public Benchmark()
    {
        // Build the configuration
        _iConfiguration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public static IEnumerable<string> ConnectionNames { get; set; } = new[] { "EF6Context" };

    private string? _connectionString;
    private string? _connName;
    [ParamsSource(nameof(ConnectionNames))]
    public string? ConnName
    {
        get => _connName;
        set
        {
            if (_connName == value)
            {
                return;
            }

            _connName = value;

            if (_connName == null) return;

            _connectionString = _iConfiguration.GetConnectionString(_connName);
        }
    }

    [Benchmark(Description = "Microsoft SQL Query")]
    public void GetBooksMicrosoftSql()
    {

        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException($"Connection string '{_connName}' not found.");
        }

        using (var sqlConn = new SqlConnection(_connectionString))
        {
            sqlConn.Open();
            using (var cmd = new SqlCommand("SELECT * FROM Books", sqlConn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Process each row
                        var title = reader["Title"].ToString();
                        var author = reader["Author"].ToString();
                        var price = (decimal)reader["Price"];
                        // Add your processing logic here
                    }
                }
            }
        }

    }

    [Benchmark(Description = "System SQL Query")]
    public void GetBooksSystemSql()
    {

        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException($"Connection string '{_connName}' not found.");
        }

        using (var sqlConn = new System.Data.SqlClient.SqlConnection(_connectionString))
        {
            sqlConn.Open();
            using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM Books", sqlConn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Process each row
                        var title = reader["Title"].ToString();
                        var author = reader["Author"].ToString();
                        var price = (decimal)reader["Price"];
                        // Add your processing logic here
                    }
                }
            }
        }

    }







}