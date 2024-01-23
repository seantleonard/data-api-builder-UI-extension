// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// The CosmosDB NoSQL connection options.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record CosmosDbNoSQLDataSourceOptions : IDataSourceOptions
{
    /// <summary>
    /// Name of the default CosmosDB database.
    /// </summary>
    public string? Database { get; set; }

    /// <summary>
    /// Name of the default CosmosDB container.
    /// </summary>
    public string? Container { get; set; }

    /// <summary>
    /// Path to the GraphQL schema file.
    /// </summary>
    public string? Schema { get; set; }

    /// <summary>
    /// Raw contents of the GraphQL schema.
    /// </summary>
    public string? GraphQLSchema { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CosmosDbNoSQLDataSourceOptions"/> class.
    /// </summary>
    /// <param name="database">Name of the default CosmosDB database.</param>
    /// <param name="container">Name of the default CosmosDB container.</param>
    /// <param name="schema">Path to the GraphQL schema file.</param>
    /// <param name="graphQLSchema">Raw contents of the GraphQL schema.</param>
    public CosmosDbNoSQLDataSourceOptions(string? Database, string? Container, string? Schema, string? GraphQLSchema)
    {
        this.Database = Database;
        this.Container = Container;
        this.Schema = Schema;
        this.GraphQLSchema = GraphQLSchema;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CosmosDbNoSQLDataSourceOptions"/> class.
    /// </summary>
    public CosmosDbNoSQLDataSourceOptions()
    {
        Database = default!;
        Container = default!;
        Schema = default!;
        GraphQLSchema = default!;
    }
}
