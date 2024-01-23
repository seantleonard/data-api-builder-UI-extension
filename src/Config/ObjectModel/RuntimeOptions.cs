// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This record is mutable.
/// </remarks>
public record RuntimeOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RuntimeOptions"/> class.
    /// </summary>
    /// <param name="rest">The REST runtime options.</param>
    /// <param name="graphQL">The GraphQL runtime options.</param>
    /// <param name="host">The host options.</param>
    /// <param name="baseRoute">The base route.</param>
    /// <param name="telemetry">The telemetry options.</param>
    public RuntimeOptions(
        RestRuntimeOptions? Rest,
        GraphQLRuntimeOptions? GraphQL,
        HostOptions? Host,
        string? BaseRoute = null,
        TelemetryOptions? Telemetry = null)
    {
        this.Rest = Rest;
        this.GraphQL = GraphQL;
        this.Host = Host;
        this.BaseRoute = BaseRoute;
        this.Telemetry = Telemetry;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RuntimeOptions"/> class.
    /// </summary>
    public RuntimeOptions()
    {
        Rest = default!;
        GraphQL = default!;
        Host = default!;
        BaseRoute = default!;
        Telemetry = default!;
    }

    /// <summary>
    /// Gets or sets the REST runtime options.
    /// </summary>
    public RestRuntimeOptions? Rest { get; set; }

    /// <summary>
    /// Gets or sets the GraphQL runtime options.
    /// </summary>
    public GraphQLRuntimeOptions? GraphQL { get; set; }

    /// <summary>
    /// Gets or sets the host options.
    /// </summary>
    public HostOptions? Host { get; set; }

    /// <summary>
    /// Gets or sets the base route.
    /// </summary>
    public string? BaseRoute { get; set; }

    /// <summary>
    /// Gets or sets the telemetry options.
    /// </summary>
    public TelemetryOptions? Telemetry { get; set; }
}
