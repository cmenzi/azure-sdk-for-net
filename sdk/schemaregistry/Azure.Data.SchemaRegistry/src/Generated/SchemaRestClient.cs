// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.SchemaRegistry.Models;

namespace Azure.Data.SchemaRegistry
{
    internal partial class SchemaRestClient
    {
        private string endpoint;
        private string apiVersion;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of SchemaRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The Schema Registry service endpoint, for example my-namespace.servicebus.windows.net. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public SchemaRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2020-09-01-preview")
        {
            this.endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            this.apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateGetByIdRequest(string schemaId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/$schemagroups/getSchemaById/", false);
            uri.AppendPath(schemaId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain; charset=utf-8");
            return message;
        }

        /// <summary> Gets a registered schema by its unique ID.  Azure Schema Registry guarantees that ID is unique within a namespace. </summary>
        /// <param name="schemaId"> References specific schema in registry namespace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaId"/> is null. </exception>
        public async Task<ResponseWithHeaders<string, SchemaGetByIdHeaders>> GetByIdAsync(string schemaId, CancellationToken cancellationToken = default)
        {
            if (schemaId == null)
            {
                throw new ArgumentNullException(nameof(schemaId));
            }

            using var message = CreateGetByIdRequest(schemaId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new SchemaGetByIdHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StreamReader streamReader = new StreamReader(message.Response.ContentStream);
                        string value = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets a registered schema by its unique ID.  Azure Schema Registry guarantees that ID is unique within a namespace. </summary>
        /// <param name="schemaId"> References specific schema in registry namespace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaId"/> is null. </exception>
        public ResponseWithHeaders<string, SchemaGetByIdHeaders> GetById(string schemaId, CancellationToken cancellationToken = default)
        {
            if (schemaId == null)
            {
                throw new ArgumentNullException(nameof(schemaId));
            }

            using var message = CreateGetByIdRequest(schemaId);
            _pipeline.Send(message, cancellationToken);
            var headers = new SchemaGetByIdHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StreamReader streamReader = new StreamReader(message.Response.ContentStream);
                        string value = streamReader.ReadToEnd();
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateQueryIdByContentRequest(string groupName, string schemaName, SerializationType serializationType, string schemaContent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/$schemagroups/", false);
            uri.AppendPath(groupName, true);
            uri.AppendPath("/schemas/", false);
            uri.AppendPath(schemaName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Serialization-Type", serializationType.ToString());
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            request.Content = new StringRequestContent(schemaContent);
            return message;
        }

        /// <summary> Gets the ID referencing an existing schema within the specified schema group, as matched by schema content comparison. </summary>
        /// <param name="groupName"> Schema group under which schema is registered.  Group&apos;s serialization type should match the serialization type specified in the request. </param>
        /// <param name="schemaName"> Name of the registered schema. </param>
        /// <param name="serializationType"> Serialization type for the schema being registered. </param>
        /// <param name="schemaContent"> String representation (UTF-8) of the registered schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupName"/>, <paramref name="schemaName"/>, or <paramref name="schemaContent"/> is null. </exception>
        public async Task<ResponseWithHeaders<SchemaId, SchemaQueryIdByContentHeaders>> QueryIdByContentAsync(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            if (schemaName == null)
            {
                throw new ArgumentNullException(nameof(schemaName));
            }
            if (schemaContent == null)
            {
                throw new ArgumentNullException(nameof(schemaContent));
            }

            using var message = CreateQueryIdByContentRequest(groupName, schemaName, serializationType, schemaContent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new SchemaQueryIdByContentHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SchemaId value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SchemaId.DeserializeSchemaId(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets the ID referencing an existing schema within the specified schema group, as matched by schema content comparison. </summary>
        /// <param name="groupName"> Schema group under which schema is registered.  Group&apos;s serialization type should match the serialization type specified in the request. </param>
        /// <param name="schemaName"> Name of the registered schema. </param>
        /// <param name="serializationType"> Serialization type for the schema being registered. </param>
        /// <param name="schemaContent"> String representation (UTF-8) of the registered schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupName"/>, <paramref name="schemaName"/>, or <paramref name="schemaContent"/> is null. </exception>
        public ResponseWithHeaders<SchemaId, SchemaQueryIdByContentHeaders> QueryIdByContent(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            if (schemaName == null)
            {
                throw new ArgumentNullException(nameof(schemaName));
            }
            if (schemaContent == null)
            {
                throw new ArgumentNullException(nameof(schemaContent));
            }

            using var message = CreateQueryIdByContentRequest(groupName, schemaName, serializationType, schemaContent);
            _pipeline.Send(message, cancellationToken);
            var headers = new SchemaQueryIdByContentHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SchemaId value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SchemaId.DeserializeSchemaId(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateRegisterRequest(string groupName, string schemaName, SerializationType serializationType, string schemaContent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/$schemagroups/", false);
            uri.AppendPath(groupName, true);
            uri.AppendPath("/schemas/", false);
            uri.AppendPath(schemaName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Serialization-Type", serializationType.ToString());
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            request.Content = new StringRequestContent(schemaContent);
            return message;
        }

        /// <summary>
        /// Register new schema. If schema of specified name does not exist in specified group, schema is created at version 1. If schema of specified name exists already in specified group, schema is created at latest version + 1.
        /// 
        /// </summary>
        /// <param name="groupName"> Schema group under which schema should be registered.  Group&apos;s serialization type should match the serialization type specified in the request. </param>
        /// <param name="schemaName"> Name of schema being registered. </param>
        /// <param name="serializationType"> Serialization type for the schema being registered. </param>
        /// <param name="schemaContent"> String representation (UTF-8) of the schema being registered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupName"/>, <paramref name="schemaName"/>, or <paramref name="schemaContent"/> is null. </exception>
        public async Task<ResponseWithHeaders<SchemaId, SchemaRegisterHeaders>> RegisterAsync(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            if (schemaName == null)
            {
                throw new ArgumentNullException(nameof(schemaName));
            }
            if (schemaContent == null)
            {
                throw new ArgumentNullException(nameof(schemaContent));
            }

            using var message = CreateRegisterRequest(groupName, schemaName, serializationType, schemaContent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new SchemaRegisterHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SchemaId value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SchemaId.DeserializeSchemaId(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Register new schema. If schema of specified name does not exist in specified group, schema is created at version 1. If schema of specified name exists already in specified group, schema is created at latest version + 1.
        /// 
        /// </summary>
        /// <param name="groupName"> Schema group under which schema should be registered.  Group&apos;s serialization type should match the serialization type specified in the request. </param>
        /// <param name="schemaName"> Name of schema being registered. </param>
        /// <param name="serializationType"> Serialization type for the schema being registered. </param>
        /// <param name="schemaContent"> String representation (UTF-8) of the schema being registered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupName"/>, <paramref name="schemaName"/>, or <paramref name="schemaContent"/> is null. </exception>
        public ResponseWithHeaders<SchemaId, SchemaRegisterHeaders> Register(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            if (schemaName == null)
            {
                throw new ArgumentNullException(nameof(schemaName));
            }
            if (schemaContent == null)
            {
                throw new ArgumentNullException(nameof(schemaContent));
            }

            using var message = CreateRegisterRequest(groupName, schemaName, serializationType, schemaContent);
            _pipeline.Send(message, cancellationToken);
            var headers = new SchemaRegisterHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SchemaId value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SchemaId.DeserializeSchemaId(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
