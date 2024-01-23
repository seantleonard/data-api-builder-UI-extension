// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Configuration related to Cross Origin Resource Sharing (CORS).
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record CorsOptions
{
    /// <summary>
    /// List of allowed origins.
    /// </summary>
    public string[] Origins { get; set; }

    /// <summary>
    /// Whether to set Access-Control-Allow-Credentials CORS header.
    /// </summary>
    public bool AllowCredentials { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CorsOptions"/> class.
    /// </summary>
    /// <param name="origins">List of allowed origins.</param>
    /// <param name="allowCredentials">Whether to set Access-Control-Allow-Credentials CORS header.</param>
    public CorsOptions(string[] Origins, bool AllowCredentials = false)
    {
        this.Origins = Origins;
        this.AllowCredentials = AllowCredentials;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CorsOptions"/> class.
    /// </summary>
    public CorsOptions()
    {
        Origins = Array.Empty<string>();
        AllowCredentials = default!;
    }
}
