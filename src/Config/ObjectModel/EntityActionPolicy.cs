// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This record is mutable.
/// </remarks>
public record EntityActionPolicy
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityActionPolicy"/> class.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="database">The database.</param>
    public EntityActionPolicy(string? Request = null, string? Database = null)
    {
        this.Request = Request;
        this.Database = Database;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityActionPolicy"/> class.
    /// </summary>
    /// <remarks>
    /// This record is mutable.
    /// </remarks>
    public EntityActionPolicy()
    {
        Request = default!;
        Database = default!;
    }

    /// <summary>
    /// Gets or sets the request.
    /// </summary>
    /// <value>
    /// The request.
    /// </value>
    public string? Request { get; set; }

    /// <summary>
    /// Gets or sets the database.
    /// </summary>
    /// <value>
    /// The database.
    /// </value>
    public string? Database { get; set; }

    public string ProcessedDatabaseFields()
    {
        if (Database is null)
        {
            throw new NullReferenceException("Unable to process the fields in the database policy because the policy is null.");
        }

        return ProcessFieldsInPolicy(Database);
    }

    /// <summary>
    /// Helper method which takes in the database policy and returns the processed policy
    /// without @item. directives before field names.
    /// </summary>
    /// <param name="policy">Raw database policy</param>
    /// <returns>Processed policy without @item. directives before field names.</returns>
    private static string ProcessFieldsInPolicy(string? policy)
    {
        if (policy is null)
        {
            return string.Empty;
        }

        string fieldCharsRgx = @"@item\.([a-zA-Z0-9_]*)";

        // processedPolicy would be devoid of @item. directives.
        string processedPolicy = Regex.Replace(policy, fieldCharsRgx, (columnNameMatch) =>
            columnNameMatch.Groups[1].Value
        );
        return processedPolicy;
    }
}
