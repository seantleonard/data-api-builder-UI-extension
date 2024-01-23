// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.DataApiBuilder.Config.NamingPolicies;

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Contains the information needed to connect to the backend database.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record DataSource
{
    /// <summary>
    /// Type of database to use.
    /// </summary>
    public DatabaseType DatabaseType { get; set; }

    /// <summary>
    /// Connection string to access the database.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Custom options for the specific database. If there are no options, this could be null.
    /// </summary>
    public Dictionary<string, JsonElement>? Options { get; set; }

    /// <summary>
    /// Empty constructor for the mutable DataSource record.
    /// </summary>
    public DataSource()
    {
        DatabaseType = default!;
        ConnectionString = default!;
        Options = null;
    }

    /// <summary>
    /// Constructor for the mutable DataSource record.
    /// </summary>
    /// <param name="databaseType">Type of database to use.</param>
    /// <param name="connectionString">Connection string to access the database.</param>
    /// <param name="options">Custom options for the specific database. If there are no options, this could be null.</param>
    public DataSource(DatabaseType DatabaseType, string ConnectionString, Dictionary<string, JsonElement>? Options)
    {
        this.DatabaseType = DatabaseType;
        this.ConnectionString = ConnectionString;
        this.Options = Options;
    }

    /// <summary>
    /// Converts the <c>Options</c> dictionary into a typed options object.
    /// May return null if the dictionary is null.
    /// </summary>
    /// <typeparam name="TOptionType">The strongly typed object for Options.</typeparam>
    /// <returns>The strongly typed representation of Options.</returns>
    /// <exception cref="NotSupportedException">Thrown when the provided <c>TOptionType</c> is not supported for parsing.</exception>
    public TOptionType? GetTypedOptions<TOptionType>() where TOptionType : IDataSourceOptions
    {
        HyphenatedNamingPolicy namingPolicy = new();

        if (typeof(TOptionType).IsAssignableFrom(typeof(CosmosDbNoSQLDataSourceOptions)))
        {
            return Options is not null ?
                (TOptionType)(object)new CosmosDbNoSQLDataSourceOptions(
                Database: ReadStringOption(namingPolicy.ConvertName(nameof(CosmosDbNoSQLDataSourceOptions.Database))),
                Container: ReadStringOption(namingPolicy.ConvertName(nameof(CosmosDbNoSQLDataSourceOptions.Container))),
                Schema: ReadStringOption(namingPolicy.ConvertName(nameof(CosmosDbNoSQLDataSourceOptions.Schema))),
                // The "raw" schema will be provided via the controller to setup config, rather than parsed from the JSON file.
                GraphQLSchema: ReadStringOption(namingPolicy.ConvertName(nameof(CosmosDbNoSQLDataSourceOptions.GraphQLSchema))))
                : default;
        }

        if (typeof(TOptionType).IsAssignableFrom(typeof(MsSqlOptions)))
        {
            return (TOptionType)(object)new MsSqlOptions(
                SetSessionContext: ReadBoolOption(namingPolicy.ConvertName(nameof(MsSqlOptions.SetSessionContext))));
        }

        throw new NotSupportedException($"The type {typeof(TOptionType).FullName} is not a supported strongly typed options object");
    }

    private string? ReadStringOption(string option)
    {
        if (Options is not null && Options.TryGetValue(option, out JsonElement value))
        {
            return value.GetString();
        }

        return null;
    }

    private bool ReadBoolOption(string option)
    {
        if (Options is not null && Options.TryGetValue(option, out JsonElement value))
        {
            return value.GetBoolean();
        }

        return false;
    }

    [JsonIgnore]
    public string DatabaseTypeNotSupportedMessage => $"The provided database-type value: {DatabaseType} is currently not supported. Please check the configuration file.";
}

public interface IDataSourceOptions { }
