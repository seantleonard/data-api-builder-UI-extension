// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Represents the options for configuring Application Insights.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record ApplicationInsightsOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationInsightsOptions"/> class.
    /// </summary>
    /// <param name="enabled">Indicates whether Application Insights is enabled.</param>
    /// <param name="connectionString">The connection string for Application Insights.</param>
    public ApplicationInsightsOptions(bool Enabled = false, string? ConnectionString = null)
    {
        this.Enabled = Enabled;
        this.ConnectionString = ConnectionString;
    }

    /// <summary>
    /// Gets or sets a value indicating whether Application Insights is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the connection string for Application Insights.
    /// </summary>
    public string? ConnectionString { get; set; }
}
